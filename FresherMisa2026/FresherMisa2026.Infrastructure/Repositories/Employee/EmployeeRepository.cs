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

        public async Task<Employee> GetEmployeeByCode(string code)
        {
            string query = SQLExtension.GetQuery("Employee.GetByCode");
            var param = new Dictionary<string, object>
            {
                {"@EmployeeCode", code }
            };
            return await _dbConnection.QueryFirstOrDefaultAsync<Employee>(query, param, commandType: System.Data.CommandType.Text);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentId(Guid departmentId)
        {
            string query = SQLExtension.GetQuery("Employee.GetByDepartmentId");
            var param = new Dictionary<string, object>
            {
                {"@DepartmentID", departmentId }
            };
            return await _dbConnection.QueryAsync<Employee>(query, param, commandType: System.Data.CommandType.Text);
        }

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
            var conditions = new List<string>();
            var parameters = new DynamicParameters();

            if (filter.DepartmentId.HasValue)
            {
                conditions.Add("DepartmentID = @DepartmentId");
                parameters.Add("DepartmentId", filter.DepartmentId);
            }
            if (filter.PositionId.HasValue)
            {
                conditions.Add("PositionID = @PositionId");
                parameters.Add("PositionId", filter.PositionId);
            }
            if (filter.SalaryFrom.HasValue)
            {
                conditions.Add("Salary >= @SalaryFrom");
                parameters.Add("SalaryFrom", filter.SalaryFrom);
            }
            if (filter.SalaryTo.HasValue)
            {
                conditions.Add("Salary <= @SalaryTo");
                parameters.Add("SalaryTo", filter.SalaryTo);
            }
            if (filter.Gender.HasValue)
            {
                conditions.Add("Gender = @Gender");
                parameters.Add("Gender", filter.Gender);
            }
            if (filter.HireDateFrom.HasValue)
            {
                conditions.Add("HireDate >= @HireDateFrom");
                parameters.Add("HireDateFrom", filter.HireDateFrom);
            }
            if (filter.HireDateTo.HasValue)
            {
                conditions.Add("HireDate <= @HireDateTo");
                parameters.Add("HireDateTo", filter.HireDateTo);
            }

            var where = conditions.Count > 0
                ? "WHERE " + string.Join(" AND ", conditions)
                : "";

            var sql = $"SELECT * FROM Employee {where}";

        
            return await _dbConnection.QueryAsync<Employee>(sql, parameters);
        }
    }
}