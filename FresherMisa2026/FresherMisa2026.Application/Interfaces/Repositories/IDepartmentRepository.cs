using FresherMisa2026.Entities.Department;
using FresherMisa2026.Entities.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherMisa2026.Application.Interfaces.Repositories
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        /// <summary>
        /// lấy ds phòng ban theo mã phòng ban
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Department> GetDepartmentByCode(string code);
        /// <summary>
        /// lấy ds nhân viên theo mã phòng ban
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentCode(string code);
        /// <summary>
        /// đếm sl nv trong phòng ban theo mã phòng ban
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<int> GetEmployeeCountByDepartmentCode(string code);
    }
}
