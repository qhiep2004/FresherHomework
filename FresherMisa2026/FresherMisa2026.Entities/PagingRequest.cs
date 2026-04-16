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

}
