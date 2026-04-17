using FresherMisa2026.Application.Interfaces;
using FresherMisa2026.Application.Interfaces.Repositories;
using FresherMisa2026.Application.Interfaces.Services;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.Department;
using FresherMisa2026.Entities.DTOs;
using FresherMisa2026.Entities.Employee;
using FresherMisa2026.Entities.Enums;
using FresherMisa2026.Entities.Position;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FresherMisa2026.Application.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IBaseRepository<Department> _departmentRepository;
        private readonly IBaseRepository<Position> _positionRepository;

        public EmployeeService(
            IBaseRepository<Employee> baseRepository,
            IEmployeeRepository employeeRepository,
            IBaseRepository<Department> departmentRepository,
            IBaseRepository<Position> positionRepository
            ) : base(baseRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _positionRepository = positionRepository;

        }
        /// <summary>
        /// lấy ds nv theo mã 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>

        public async Task<ServiceResponse> GetEmployeeByCodeAsync(string code)
        {
            var employee = await _employeeRepository.GetEmployeeByCode(code);
            if (employee == null)
                return CreateErrorResponse(ResponseCode.NotFound, "Không tìm thấy nhân viên với mã này");

            return CreateSuccessResponse(employee);
        }
        /// <summary>
        /// lấy ds nv theo id phòng ban 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> GetEmployeesByDepartmentIdAsync(Guid departmentId)
        {
            // Validate GUID
            if (departmentId == Guid.Empty)
                return CreateErrorResponse(ResponseCode.BadRequest, "DepartmentId không đúng định dạng GUID");

            var employees = await _employeeRepository.GetEmployeesByDepartmentId(departmentId);
            if (employees == null || !employees.Any())
                return CreateErrorResponse(ResponseCode.NotFound, "Không tìm thấy nhân viên theo phòng ban này");

            return CreateSuccessResponse(employees);
        }
        /// <summary>
        /// lấy ds nhân viên theo id vị trí 
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>

        public async Task<ServiceResponse> GetEmployeesByPositionIdAsync(Guid positionId)
        {
            // Validate GUID
            if (positionId == Guid.Empty)
                return CreateErrorResponse(ResponseCode.BadRequest, "PositionId không đúng định dạng GUID");

            var employees = await _employeeRepository.GetEmployeesByPositionId(positionId);
            if (employees == null || !employees.Any())
                return CreateErrorResponse(ResponseCode.NotFound, "Không tìm thấy nhân viên theo vị trí này");

            return CreateSuccessResponse(employees);
        }
        /// <summary>
        /// bộ lọc dữ liệu theo yêu cầu
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>

        public async Task<ServiceResponse> GetEmployeesByFilterAsync(EmployeeFilterRequest filter)
        {
            var employees = await _employeeRepository.FilterAsync(filter);
            if (employees == null || !employees.Any())
                return CreateErrorResponse(ResponseCode.NotFound, "Không tìm thấy nhân viên thỏa mãn điều kiện lọc");

            return CreateSuccessResponse(employees);
        }
        /// <summary>
        /// validate custom theo yêu cầu nghiệp vụ
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        protected override async Task<List<ValidationError>> ValidateCustomAsync(Employee employee)
        {
            var errors = new List<ValidationError>();

            if (!string.IsNullOrEmpty(employee.EmployeeCode) && employee.EmployeeCode.Length > 20)
            {
                errors.Add(new ValidationError("EmployeeCode", "Mã nhân viên không được vượt quá 20 ký tự"));
            }

            //if (string.IsNullOrEmpty(employee.EmployeeName))
            //{
            //    errors.Add(new ValidationError("EmployeeName", "Tên nhân viên không được để trống"));
            //}
            // 1. Mã nhân viên không được trùng lặp
            if (!string.IsNullOrEmpty(employee.EmployeeCode))
            {
                var existingEmployee = await _employeeRepository.GetEmployeeByCode(employee.EmployeeCode);
                if (existingEmployee != null && existingEmployee.EmployeeID != employee.EmployeeID)
                {
                    errors.Add(new ValidationError("EmployeeCode", $"Mã nhân viên {employee.EmployeeCode} đã tồn tại"));
                }
            }

            // 2. Email phải đúng định dạng
            if (!string.IsNullOrEmpty(employee.Email))
            {
                var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(employee.Email, emailRegex))
                {
                    errors.Add(new ValidationError("Email", "Email không đúng định dạng"));
                }
            }

            // 3. Số điện thoại phải đúng định dạng
            if (!string.IsNullOrEmpty(employee.PhoneNumber))
            {
                var phoneRegex = @"^(0|\+84)[0-9]{9,10}$";
                if (!Regex.IsMatch(employee.PhoneNumber, phoneRegex))
                {
                    errors.Add(new ValidationError("PhoneNumber", "Số điện thoại không đúng định dạng"));
                }
            }

            // 4. Ngày sinh phải nhỏ hơn ngày hiện tại
            if (employee.DateOfBirth.HasValue)
            {
                if (employee.DateOfBirth.Value >= DateTime.Now)
                {
                    errors.Add(new ValidationError("DateOfBirth", "Ngày sinh phải nhỏ hơn ngày hiện tại"));
                }
            }

            // 5. Kiểm tra phòng ban có tồn tại không
            if (employee.DepartmentID.HasValue && employee.DepartmentID.Value != Guid.Empty)
            {
                var department = await _departmentRepository.GetEntityByIDAsync(employee.DepartmentID.Value);
                if (department == null)
                {
                    errors.Add(new ValidationError("DepartmentID", $"Phòng ban không tồn tại"));
                }
            }

            // 6. Kiểm tra vị trí có tồn tại không
            if (employee.PositionID.HasValue && employee.PositionID.Value != Guid.Empty)
            {
                var position = await _positionRepository.GetEntityByIDAsync(employee.PositionID.Value);
                if (position == null)
                {
                    errors.Add(new ValidationError("PositionID", $"Vị trí không tồn tại"));
                }
            }
            return errors;
        }
        /// <summary>
        /// phân trang cho bộ lọc filter
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> FilterPagingAsync(PagingOnlyRequest paging, EmployeeFilterRequest filter)
        {
            var (total, data) = await _employeeRepository.FilterPagingAsync(paging, filter);

            var response = new PagingResponse<Employee>
            {
                Total = total,
                Data = data.ToList()
            };

            return CreateSuccessResponse(response);
        }

    }
    
}