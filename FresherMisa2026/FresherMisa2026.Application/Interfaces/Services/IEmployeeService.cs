using FresherMisa2026.Entities;
using FresherMisa2026.Entities.DTOs;
using FresherMisa2026.Entities.Employee;
using System;
using System.Collections.Generic;

namespace FresherMisa2026.Application.Interfaces.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        /// <summary>
        /// lấy ds nhân viên theo mã
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Employee> GetEmployeeByCodeAsync(string code);
        /// <summary>
        /// lấy ds nhân viên theo id phòng ban
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(Guid departmentId);
        /// <summary>
        /// lấy ds nhân viên theo id vị trí
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployeesByPositionIdAsync(Guid positionId);
        /// <summary>
        /// bộ lộc filter các trường dữ liệu và in ra ds nhân viên thỏa mãn điều kiện
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployeesByFilterAsync(EmployeeFilterRequest filter);
        Task<ServiceResponse> FilterPagingAsync(PagingOnlyRequest paging, EmployeeFilterRequest filter);
    }
}