using FresherMisa2026.Entities.Department;
using FresherMisa2026.Entities.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherMisa2026.Application.Interfaces.Services
{
    public interface IDepartmentSerice : IBaseService<Department>
    {
        /// <summary>
        /// Lấy department theo code
        /// </summary>
        /// <returns></returns>
        /// Created By: dvhai (10/04/2026)
        Task<Department> GetDepartmentByCodeAsync(string code);
        /// <summary>
        /// lấy ds nhân viên theo code phòng ban
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentCode(string code);
        /// <summary>
        /// đếm sl nhân viên trong phòng ban theo mã phòng ban
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<int> GetEmployeeCountByDepartmentCode(string code);
    }
}
