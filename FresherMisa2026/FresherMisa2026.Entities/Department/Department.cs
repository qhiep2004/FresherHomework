using FresherMisa2026.Entities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FresherMisa2026.Entities.Department
{
    [ConfigTable("Department", false, "DepartmentCode")]
    public class Department : BaseModel
    {
        public Department(){
            //tự sinh ra ID mới khi khởi tạo đối tượng, tránh trường hợp quên gán ID dẫn đến lỗi
            DepartmentID = Guid.NewGuid();
        }
        /// <summary>
        /// ID phòng ban
        /// </summary>
        [Key]
        public Guid DepartmentID { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [IRequired]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
         [IRequired]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
    }
}
