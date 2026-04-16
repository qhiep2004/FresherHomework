using System;
using System.Collections.Generic;
using System.Text;

namespace FresherMisa2026.Entities
{
    public class PagingResponse<T>
    {
        /// <summary>
        /// tổng số bản ghi thỏa mãn
        /// </summary>
        public long Total { get; set; }
        /// <summary>
        /// dữ liệu trả về sau khi phân trang
        /// </summary>

        public List<T> Data { get; set; }
    }
}
