using FresherMisa2026.Entities;
using FresherMisa2026.Entities.DTOs;
using FresherMisa2026.Entities.Employee;
using System;
using System.Collections.Generic;

namespace FresherMisa2026.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// lấy ds nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Employee> GetEmployeeByCode(string code);
        /// <summary>
        /// lấy ds nhân viên theo id phòng ban
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentId(Guid departmentId);
        /// <summary>
        /// lấy danh sách nv theo mã vị trí
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployeesByPositionId(Guid positionId);
        /// <summary>
        /// bộ lộc filter các trường dữ liệu và in ra ds nhân viên thỏa mãn điều kiện
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> FilterAsync(EmployeeFilterRequest filter);
        Task<(long Total, IEnumerable<Employee> Data)> FilterPagingAsync(PagingOnlyRequest paging, EmployeeFilterRequest filter);
    }
}
