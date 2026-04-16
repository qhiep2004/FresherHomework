using System;
using System.Collections.Generic;
using System.Text;

namespace FresherMisa2026.Entities.DTOs
{
    public class EmployeeFilterRequest
    {
        /// <summary>
        /// id phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }
        /// <summary>
        /// id vị trí
        /// </summary>
        public Guid? PositionId { get; set; }
        /// <summary>
        /// lương từ
        /// </summary>
        public decimal? SalaryFrom { get; set; }
        /// <summary>
        /// lương đến
        /// </summary>
        public decimal? SalaryTo { get; set; }
        /// <summary>
        /// giới tính 
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// từ ngày ...
        /// </summary>
        public DateTime? HireDateFrom { get; set; }
        /// <summary>
        /// đến ngày ...
        /// </summary>
        public DateTime? HireDateTo { get; set; }
    }
}
