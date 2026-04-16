using Dapper;
using FresherMisa2026.Application.Interfaces;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.Department;
using FresherMisa2026.Entities.Extensions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FresherMisa2026.Infrastructure.Repositories
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// Created By: dvhai (09/04/2026)
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : BaseModel
    {
        //Properties
        //string _connectionString = string.Empty;
        //IConfiguration _configuration;
        //protected IDbConnection _dbConnection = null;
        //protected string _tableName;
        //public Type _modelType = null;
        // ── fields ──────────────────────────────────────────────
        private readonly string _connectionString;
        private readonly IMemoryCache _cache;
        protected readonly string _tableName;
        protected readonly Type _modelType;

        // Cache duration: 5 phút theo yêu cầu
        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(5);

        // Cache key helpers – dùng tên bảng để tránh collision
        private string AllEntitiesCacheKey => $"cache_{_tableName}_all";
        private string EntityByIdCacheKey(Guid id) => $"cache_{_tableName}_{id}";

        //Constructor
        public BaseRepository(IConfiguration configuration , IMemoryCache cache)
        {
            //_configuration = configuration;
            //_connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            //_dbConnection = new MySqlConnection(_connectionString);
            //_modelType = typeof(TEntity);
            //_tableName = _modelType.GetTableName();
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
            _cache = cache;
            _modelType = typeof(TEntity);
            _tableName = _modelType.GetTableName();
        }

        /// <summary>
        /// Tạo connection mới mỗi lần dùng.
        /// MySqlConnector tự quản lý connection pool bên dưới.
        /// </summary>
        protected MySqlConnection CreateConnection() => new(_connectionString);

        /// <summary>
        /// Xóa cache liên quan đến một entity cụ thể
        /// </summary>
        private void InvalidateCache(Guid entityId)
        {
            _cache.Remove(EntityByIdCacheKey(entityId));
            _cache.Remove(AllEntitiesCacheKey);
        }

        /// <summary>
        /// Dispose connection
        /// </summary>
        /// Created By: dvhai (09/04/2026)
        public void Dispose()
        {
            //if (_dbConnection != null && _dbConnection.State == ConnectionState.Open)
            //{
            //    _dbConnection.Close();
            //    _dbConnection.Dispose();
            //}
        }

        /// <summary>
        /// Mở kết nối database
        /// </summary>
        //protected async Task OpenConnectionAsync()
        //{
        //    if (_dbConnection.State != ConnectionState.Open)
        //    {
        //        if (_dbConnection is MySqlConnection mySqlConnection)
        //        {
        //            await mySqlConnection.OpenAsync();
        //        }
        //        else
        //        {
        //            _dbConnection.Open();
        //        }
        //    }
        //}

        #region Method Get
        /// <summary>
        /// Lấy danh sách entity
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// Created By: dvhai (09/04/2026)
        public async Task<IEnumerable<BaseModel>> GetEntitiesAsync()
        {
            return await GetEntitiesUsingCommandTextAsync();
        }

        /// <summary>
        /// Lấy tất cả theo command text
        /// </summary>
        /// <returns></returns>
        /// CREATED BY: DVHAI (11/07/2021)
        private async Task<IEnumerable<TEntity>> GetEntitiesUsingCommandTextAsync()
        {
            // 1. Thử lấy từ cache trước
            if (_cache.TryGetValue(AllEntitiesCacheKey, out IEnumerable<TEntity>? cached))
                return cached!;

            // 2. Cache miss → query DB
            var query = new StringBuilder($"SELECT * FROM {_tableName}");
            if (_modelType.GetHasDeletedColumn())
                query.Append(" WHERE IsDeleted = FALSE");

            IEnumerable<TEntity> result;
            // "using" đảm bảo connection tự đóng & trả về pool
            await using var conn = CreateConnection();
            result = (await conn.QueryAsync<TEntity>(
                query.ToString(), commandType: CommandType.Text)).ToList();

            // 3. Lưu vào cache 5 phút
            _cache.Set(AllEntitiesCacheKey, result, CacheDuration);
            return result;
        }

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="entityId">Id của bản ghi</param>
        /// <returns>Bản ghi tìm thấy hoặc null</returns>
        /// CREATED BY: DVHAI (07/07/2021)
        public async Task<TEntity> GetEntityByIDAsync(Guid entityId)
        {
            return await GetEntitieByIdUsingCommandTextAsync(entityId.ToString());
        }

        /// <summary>
        /// Lấy bản ghi theo id dùng command text
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<TEntity> GetEntitieByIdUsingCommandTextAsync(string id)
        {
            var cacheKey = EntityByIdCacheKey(Guid.Parse(id));
            if (_cache.TryGetValue(cacheKey, out TEntity? cached))
                return cached!;

            var query = new StringBuilder($"SELECT * FROM {_tableName}");
            int whereCount = 0;

            var primaryKey = _modelType.GetKeyName();
            if (primaryKey != null)
            {
                query.Append($" WHERE {primaryKey} = @Id");
                whereCount++;
            }
            if (_modelType.GetHasDeletedColumn())
                query.Append(whereCount == 0 ? " WHERE IsDeleted = FALSE" : " AND IsDeleted = FALSE");

            await using var conn = CreateConnection();
            var result = await conn.QueryFirstOrDefaultAsync<TEntity>(
                query.ToString(), new { Id = id }, commandType: CommandType.Text);

            if (result != null)
                _cache.Set(cacheKey, result, CacheDuration);

            return result;
        }

        /// <summary>
        /// Xóa bản ghi theo id
        /// </summary>
        /// <param name="entityId">Id của bản ghi</param>
        /// <returns>Số bản ghi bị xóa</returns>
        /// CREATED BY: DVHAI (11/07/2021)
        public async Task<int> DeleteAsync(Guid entityId)
        {
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            await using var transaction = await conn.BeginTransactionAsync();
            try
            {
                var keyName = _modelType.GetKeyName();
                var dynamicParams = new DynamicParameters();
                dynamicParams.Add($"@v_{keyName}", entityId);

                var rowAffects = await conn.ExecuteAsync(
                    $"Proc_Delete{_tableName}ById",
                    param: dynamicParams,
                    transaction: transaction,
                    commandType: CommandType.StoredProcedure);

                await transaction.CommitAsync();
                InvalidateCache(entityId);
                return rowAffects;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Thêm bản ghi mới
        /// </summary>
        /// <param name="entity">Thông tin bản ghi</param>
        /// <returns>Số bản ghi thêm mới</returns>
        /// CREATED BY: DVHAI (11/07/2021)
        /// 
        public async Task<int> InsertAsync(TEntity entity)
        {
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            await using var transaction = await conn.BeginTransactionAsync();
            try
            {
                var parameters = MappingDbType(entity);

                var rowAffects = await conn.ExecuteAsync(
                    $"Proc_Insert{_tableName}",
                    param: parameters,
                    transaction: transaction,
                    commandType: CommandType.StoredProcedure);

                await transaction.CommitAsync();
                _cache.Remove(AllEntitiesCacheKey);
                return rowAffects;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Cập nhật thông tin bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi</param>
        /// <param name="entity">Thông tin bản ghi</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CREATED BY: DVHAI (11/07/2021)
        public async Task<int> UpdateAsync(Guid entityId, TEntity entity)
        {
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            await using var transaction = await conn.BeginTransactionAsync();
            try
            {
                var parameters = MappingDbType(entity);
                var keyName = _modelType.GetKeyName();
                entity.GetType().GetProperty(keyName)!.SetValue(entity, entityId);

                var rowAffects = await conn.ExecuteAsync(
                    $"Proc_Update{_tableName}",
                    param: parameters,
                    transaction: transaction,
                    commandType: CommandType.StoredProcedure);

                await transaction.CommitAsync();
                InvalidateCache(entityId);
                return rowAffects;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Lấy danh sách thực thể paging
        /// </summary>
        /// <param name="pageSize">Số bản ghi mỗi trang</param>
        /// <param name="pageIndex">Chỉ số trang</param>
        /// <param name="search">Từ khóa tìm kiếm</param>
        /// <param name="searchFields">Danh sách trường tìm kiếm</param>
        /// <param name="sort">Sắp xếp theo</param>
        /// <returns>Tổng số bản ghi và danh sách dữ liệu</returns>
        /// CREATED BY: DVHAI (07/07/2026)
        public async Task<(long Total,
            IEnumerable<TEntity> Data)> GetFilterPagingAsync(
            int pageSize,
            int pageIndex,
            string search,
            List<string> searchFields,string sort)
        {
            //  bắt đầu đo thời gian
            var sw = Stopwatch.StartNew();


            long total = 0;
            var data = Enumerable.Empty<TEntity>();

            await using var conn = CreateConnection();

            string store = string.Format("Proc_{0}_FilterPaging", _tableName);
            var parameters = new DynamicParameters();
            parameters.Add("@v_pageIndex", pageIndex);
            parameters.Add("@v_pageSize", pageSize);
            parameters.Add("@v_search", search);
            parameters.Add("@v_sort", sort);
            parameters.Add("@v_searchFields", JsonSerializer.Serialize(searchFields));

            using var reader = await conn.QueryMultipleAsync(
                new CommandDefinition(store, parameters, commandType: CommandType.StoredProcedure));

            data = (await reader.ReadAsync<TEntity>()).ToList();
            total = await reader.ReadFirstAsync<long>();

            // in ra thời gian sau khi query xong
            sw.Stop();
            Console.WriteLine($"[PERF] {_tableName}.FilterPaging » {sw.ElapsedMilliseconds}ms | total={total}");

            return (total, data);
        }

        /// <summary>
        /// Ánh xạ các thuộc tính sang kiểu dynamic
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <returns>Dan sách các biến động</returns>
            private DynamicParameters MappingDbType(TEntity entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                //1. Duyệt các thuộc tính trên entity và tạo parameters
                var properties = entity.GetType().GetProperties();

                foreach (var property in properties)
                {
                    var propertyName = property.Name;
                    var propertyValue = property.GetValue(entity);
                    var propertyType = property.PropertyType;

                    if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                        parameters.Add($"@v_{propertyName}", propertyValue, DbType.String);
                    else
                        parameters.Add($"@v_{propertyName}", propertyValue);
                }
            }
            catch (Exception ex)
            {
                // Log error but continue with empty parameters
                Console.WriteLine($"Error mapping entity properties: {ex.Message}");
            }
            //2. Trả về danh sách các parameter
            return parameters;
        }

        #endregion
    }
}
