using FresherMisa2026.Application.Interfaces;
using FresherMisa2026.Application.Interfaces.Repositories;
using FresherMisa2026.Application.Interfaces.Services;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.Department;
using FresherMisa2026.Entities.Employee;
using FresherMisa2026.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherMisa2026.Application.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentSerice
    {
        private readonly IDepartmentRepository _deptRepository;

        public DepartmentService(
            IBaseRepository<Department> baseRepository,
            IDepartmentRepository departmentRepository
            ) : base(baseRepository)
        {
            _deptRepository = departmentRepository;
        }
        /// <summary>
        /// gọi hàm tạo response thành công
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected static ServiceResponse CreateSuccessResponse(object? data = null) => new()
        {
            IsSuccess = true,
            Code = (int)ResponseCode.Success,
            Data = data
        };
        /// <summary>
        /// tạo repose lỗi
        /// </summary>
        /// <param name="code"></param>
        /// <param name="devMessage"></param>
        /// <param name="userMessage"></param>
        /// <returns></returns>
        protected static ServiceResponse CreateErrorResponse(ResponseCode code, string devMessage, string? userMessage = null) => new()
        {
            IsSuccess = false,
            Code = (int)code,
            DevMessage = devMessage,
            Data = userMessage
        };

        /// <summary>
        /// Lấy department theo code
        /// </summary>
        /// <returns></returns>
        /// Created By: dvhai (10/04/2026)
        public async Task<ServiceResponse> GetDepartmentByCodeAsync(string code)
        {


            var department = await _deptRepository.GetDepartmentByCode(code);
          if  (department == null)
        return CreateErrorResponse(ResponseCode.NotFound, "Không tìm thấy phòng ban với mã này");

            return CreateSuccessResponse(department);
        }
        /// <summary>
        /// lấy ds nhân viên theo mã phòng ban
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ServiceResponse> GetEmployeesByDepartmentCode(string code)
        {
            var employees = await _deptRepository.GetEmployeesByDepartmentCode(code);
            if (employees == null || !employees.Any())
                return CreateErrorResponse(ResponseCode.NotFound, "Không tìm thấy nhân viên với mã phòng này");
            return CreateSuccessResponse(employees); 
        }
        /// <summary>
        /// đếm sl nv theo mã phòng ban
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public async Task<int> GetEmployeeCountByDepartmentCode(string code)
        {
            var department = await _deptRepository.GetEmployeeCountByDepartmentCode(code);
            if (department == null)
                throw new Exception("department is null");

            return department;
        }

        #region OVERRIDE METHODS
        //protected override async Task<bool> ValidateBeforeDeleteAsync(Guid entityId)
        //{
        //    //1. Validate còn nhân viên trong phòng ban không
        //    bool hasEmployee = true;

        //    return !hasEmployee;
        //}

        /// <summary>
        /// Validate tùy chỉnh cho Department
        /// </summary>
        protected override async Task<List<ValidationError>> ValidateCustomAsync(Department department)
        {
            var errors = new List<ValidationError>();

            // Ví dụ: Kiểm tra mã phòng ban không được vượt quá 20 ký tự
            if (!string.IsNullOrEmpty(department.DepartmentCode) && department.DepartmentCode.Length > 20)
            {
                errors.Add(new ValidationError("DepartmentCode", "Mã phòng ban không được vượt quá 20 ký tự"));
            }


            return errors;
        }

        #endregion OVERRIDE METHODS
    }
}
