using System;
using System.Collections.Generic;
using System.Text;

namespace FresherMisa2026.Entities
{
    public class PagingRequest
    {
        /// <summary>
        /// trang hiện tại, vd: 1,2,3
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// số bản ghi trong 1 trang
        /// </summary>

        public int PageSize { get; set; }
        /// <summary>
        /// từ khóa tìm kiếm
        /// </summary>

        public string Search { get; set; }
        /// <summary>
        /// sắp xếp giảm dần , tăng dần + - 
        /// </summary>

        public string Sort { get; set; } //vd: +ModifiedDate

        /// <summary>
        /// DepartmentCode;DepartmentName( theo trường)
        /// </summary>
        public string SearchFields { get; set; }
    }
    /// <summary>
    /// tạo riêng để phân trang cho filter thôi . kh cần từ khóa search và field
    /// </summary>
    public class PagingOnlyRequest
    {
        public int PageIndex { get; set; } 
        public int PageSize { get; set; } 
    }

}
