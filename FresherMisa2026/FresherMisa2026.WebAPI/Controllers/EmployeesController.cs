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
        public async Task<IActionResult> GetByDepartmentId(string departmentId)
        {
            if (!Guid.TryParse(departmentId, out var guid))
                return BadRequest(new { message = "departmentId không đúng định dạng GUID" });

            var result = await _employeeService.GetEmployeesByDepartmentIdAsync(guid);
            return Ok(result);
        }

        /// <summary>
        /// lấy ds nv theo id vị trí
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>

        [HttpGet("Position/{positionId}")]
        public async Task<IActionResult> GetByPositionId(string positionId)
        {
            if (!Guid.TryParse(positionId, out var guid))
                return BadRequest(new { message = "positionId không đúng định dạng GUID" });

            var result = await _employeeService.GetEmployeesByPositionIdAsync(guid);
            return Ok(result);
        }
        /// <summary>
        /// bộ lọc dữ liệu in ra ds nv thỏa mãn các điều kiện của filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("Filter")]
        public async Task<IActionResult> Filter(
     [FromQuery] EmployeeFilterRequest filter)
        {
            // Validate DepartmentId
            if (filter.DepartmentId.HasValue &&
                filter.DepartmentId.Value == Guid.Empty)
            {
                return BadRequest(new
                {
                    message = "departmentId không đúng định dạng GUID"
                });
            }

            // Validate PositionId
            if (filter.PositionId.HasValue &&
                filter.PositionId.Value == Guid.Empty)
            {
                return BadRequest(new
                {
                    message = "positionId không đúng định dạng GUID"
                });
            }

            var result =
                await _employeeService.GetEmployeesByFilterAsync(filter);

            return Ok(result);
        }
        /// <summary>
        /// phân trang cho bộ lọc filter
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("filter-paging")]
        public async Task<IActionResult> FilterPaging(
    [FromQuery] PagingOnlyRequest paging,
    [FromQuery] EmployeeFilterRequest filter)
        {
            var result = await _employeeService.FilterPagingAsync(paging, filter);
            return Ok(result);
        }

    }
}