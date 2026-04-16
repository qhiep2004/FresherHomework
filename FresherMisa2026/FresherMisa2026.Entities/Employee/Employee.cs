using FresherMisa2026.Entities.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace FresherMisa2026.Entities.Employee
{
    [ConfigTable("Employee", false, "EmployeeCode")]
    public class Employee : BaseModel
    {
        /// <summary>
        /// id nhân viên
        /// </summary>
        [Key]
        public Guid EmployeeID { get; set; }
        /// <summary>
        /// mã nhân viên
        /// </summary>

        [IRequired]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// tên nhân viên
        /// </summary>
        [IRequired]

        public string EmployeeName { get; set; }
        /// <summary>
        /// giới tính
        /// </summary>


        public int? Gender { get; set; }
        /// <summary>
        /// ngày sinh
        /// </summary>

        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// số điên thoại
        /// </summary>

        public string? PhoneNumber { get; set; }
        /// <summary>
        /// email
        /// </summary>

        public string? Email { get; set; }
        /// <summary>
        /// địa chỉ 
        /// </summary>

        public string? Address { get; set; }
        /// <summary>
        /// id phòng ban
        /// </summary>
        [IRequired]

        public Guid? DepartmentID { get; set; }
        /// <summary>
        /// id vị trí 
        /// </summary>
        [IRequired]

        public Guid? PositionID { get; set; }
        /// <summary>
        /// lương
        /// </summary>

        public decimal? Salary { get; set; }
        /// <summary>
        /// ngày vào 
        /// </summary>

        public DateTime? CreatedDate { get; set; }
    }
}