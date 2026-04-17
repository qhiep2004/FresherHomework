using Dapper;
using FresherMisa2026.Application.Extensions;
using FresherMisa2026.Application.Interfaces.Repositories;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.DTOs;
using FresherMisa2026.Entities.Employee;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;

namespace FresherMisa2026.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration , IMemoryCache cache) : base(configuration, cache)
        {
        }
        // Override InsertAsync để bắt lỗi duplicate
        /// <summary>
        /// thêm 2 nv giống nhau cùng 1 time sẽ bị lỗi duplicate key, bắt lỗi này để trả về thông báo dễ hiểu hơn
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public new async Task<int> InsertAsync(Employee entity)
        {
            try
            {
                return await base.InsertAsync(entity);
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new Exception($"Mã nhân viên {entity.EmployeeCode} đã tồn tại");
            }
        }
        /// <summary>
        /// lấy ds nhân viên theo mã nhân viên 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeByCode(string code)
        {
            string query = SQLExtension.GetQuery("Employee.GetByCode");
            var param = new Dictionary<string, object>
            {
                {"@EmployeeCode", code }
            };
            await using var conn = CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<Employee>(query, param, commandType: System.Data.CommandType.Text);
        }
        /// <summary>
        /// lấy ds nhân viên theo id phòng ban
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentId(Guid departmentId)
        {
            string query = SQLExtension.GetQuery("Employee.GetByDepartmentId");
            var param = new Dictionary<string, object>
            {
                {"@DepartmentID", departmentId }
            };
            await using var conn = CreateConnection();
            return await conn.QueryAsync<Employee>(query, param, commandType: System.Data.CommandType.Text);
        }
        /// <summary>
        /// lấy ds nhân viên theo id vị trí 
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployeesByPositionId(Guid positionId)
        {
            string query = SQLExtension.GetQuery("Employee.GetByPositionId");
            var param = new Dictionary<string, object>
            {
                {"@PositionID", positionId }
            };
            await using var conn = CreateConnection();
            return await conn.QueryAsync<Employee>(query, param, commandType: System.Data.CommandType.Text);
        }
        /// <summary>
        /// lọc nhân viên theo các tiêu chí: phòng ban, chức vụ, mức lương, giới tính, ngày tuyển dụng
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> FilterAsync(EmployeeFilterRequest filter)
        {
            var sw = Stopwatch.StartNew();

            var parameters = new DynamicParameters();
            parameters.Add("p_DepartmentId", filter.DepartmentId);
            parameters.Add("p_PositionId", filter.PositionId);
            parameters.Add("p_SalaryFrom", filter.SalaryFrom);
            parameters.Add("p_SalaryTo", filter.SalaryTo);
            parameters.Add("p_Gender", filter.Gender);
            parameters.Add("p_HireDateFrom", filter.HireDateFrom);
            parameters.Add("p_HireDateTo", filter.HireDateTo);

            // Không cần paging → lấy tất cả
            parameters.Add("p_PageIndex", 1);
            parameters.Add("p_PageSize", int.MaxValue);
            await using var conn = CreateConnection();
            using (var reader = await conn.QueryMultipleAsync(
         "sp_FilterEmployee", parameters,
         commandType: System.Data.CommandType.StoredProcedure))
            {

                sw.Stop();
                // Log rõ để so sánh có/không index
                var icon = sw.ElapsedMilliseconds < 50 ? "" : sw.ElapsedMilliseconds < 200 ? "⚠️" : "❌";
                Console.WriteLine($"""
    ───────────────────────────────────────
    {icon} FilterEmployee
       Time   : {sw.ElapsedMilliseconds} ms
       Dept   : {filter.DepartmentId}
    ───────────────────────────────────────
    """);
                return (await reader.ReadAsync<Employee>()).ToList();
            }
        }
        /// <summary>
        /// phân trang cho bộ lọc filter
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<(long Total, IEnumerable<Employee> Data)> FilterPagingAsync(
    PagingOnlyRequest paging, EmployeeFilterRequest filter)
        {

            var sw = Stopwatch.StartNew();
            await using var conn = CreateConnection();

            var parameters = new DynamicParameters();

            // Filter params
            parameters.Add("p_DepartmentId", filter.DepartmentId);
            parameters.Add("p_PositionId", filter.PositionId);
            parameters.Add("p_SalaryFrom", filter.SalaryFrom);
            parameters.Add("p_SalaryTo", filter.SalaryTo);
            parameters.Add("p_Gender", filter.Gender);
            parameters.Add("p_HireDateFrom", filter.HireDateFrom);
            parameters.Add("p_HireDateTo", filter.HireDateTo);

            // Paging params
            parameters.Add("p_PageIndex", paging.PageIndex);
            parameters.Add("p_PageSize", paging.PageSize);

            using var reader = await conn.QueryMultipleAsync(
                "sp_FilterEmployee",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            var data = (await reader.ReadAsync<Employee>()).ToList();
            var total = await reader.ReadFirstAsync<long>();


            sw.Stop();
            // Log rõ để so sánh có/không index
            var icon = sw.ElapsedMilliseconds < 50 ? "" : sw.ElapsedMilliseconds < 200 ? "⚠️" : "❌";
            Console.WriteLine($"""
    ───────────────────────────────────────
    {icon} FilterEmployee
       Time   : {sw.ElapsedMilliseconds} ms
       Total  : {total} rows
       Dept   : {filter.DepartmentId}
       Page   : {paging.PageIndex} / size={paging.PageSize}
    ───────────────────────────────────────
    """);


            return (total, data);
        }
    }
}