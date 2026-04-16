using FresherMisa2026.Application.Interfaces.Services;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.DTOs;
using FresherMisa2026.Entities.Employee;
using Microsoft.AspNetCore.Mvc;

namespace FresherMisa2026.WebAPI.Controllers
{
    [ApiController]
    public class EmployeesController : BaseController<Employee>
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(
            IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        /// <summary>
        /// tìm kiếm nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("Code/{code}")]
        public async Task<ActionResult<ServiceResponse>> GetByCode(string code)
        {
            var response = new ServiceResponse();
            response.Data = await _employeeService.GetEmployeeByCodeAsync(code);
            response.IsSuccess = true;

            return response;
        }
        /// <summary>
        /// lấy ds nhân viên theo id phòng ban
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [HttpGet("Department/{departmentId}")]
        public async Task<ActionResult<ServiceResponse>> GetByDepartmentId(Guid departmentId)
        {
            var response = new ServiceResponse();
            response.Data = await _employeeService.GetEmployeesByDepartmentIdAsync(departmentId);
            response.IsSuccess = true;

            return response;
        }
        /// <summary>
        /// lấy ds nv theo id vị trí
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>

        [HttpGet("Position/{positionId}")]
        public async Task<ActionResult<ServiceResponse>> GetByPositionId(Guid positionId)
        {
            var response = new ServiceResponse();
            response.Data = await _employeeService.GetEmployeesByPositionIdAsync(positionId);
            response.IsSuccess = true;

            return response;
        }
        /// <summary>
        /// bộ lọc dữ liệu in ra ds nv thỏa mãn các điều kiện của filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("Filter")]
        public async Task<ActionResult<ServiceResponse>> Filter([FromQuery] EmployeeFilterRequest filter)
        {
            var response = new ServiceResponse();
            response.Data = await _employeeService.GetEmployeesByFilterAsync(filter);
            response.IsSuccess = true;
            return response;
        }


    }
}