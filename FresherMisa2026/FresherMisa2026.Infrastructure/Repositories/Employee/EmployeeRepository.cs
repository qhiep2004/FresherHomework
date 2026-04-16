using Dapper;
using FresherMisa2026.Application.Extensions;
using FresherMisa2026.Application.Interfaces.Repositories;
using FresherMisa2026.Entities.DTOs;
using FresherMisa2026.Entities.Employee;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Collections.Generic;

namespace FresherMisa2026.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
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
            return await _dbConnection.QueryFirstOrDefaultAsync<Employee>(query, param, commandType: System.Data.CommandType.Text);
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
            return await _dbConnection.QueryAsync<Employee>(query, param, commandType: System.Data.CommandType.Text);
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
            return await _dbConnection.QueryAsync<Employee>(query, param, commandType: System.Data.CommandType.Text);
        }
        /// <summary>
        /// lọc nhân viên theo các tiêu chí: phòng ban, chức vụ, mức lương, giới tính, ngày tuyển dụng
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> FilterAsync(EmployeeFilterRequest filter)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_DepartmentId", filter.DepartmentId);
            parameters.Add("p_PositionId", filter.PositionId);
            parameters.Add("p_SalaryFrom", filter.SalaryFrom);
            parameters.Add("p_SalaryTo", filter.SalaryTo);
            parameters.Add("p_Gender", filter.Gender);
            parameters.Add("p_HireDateFrom", filter.HireDateFrom);
            parameters.Add("p_HireDateTo", filter.HireDateTo);

            return await _dbConnection.QueryAsync<Employee>(
                "sp_FilterEmployee",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}