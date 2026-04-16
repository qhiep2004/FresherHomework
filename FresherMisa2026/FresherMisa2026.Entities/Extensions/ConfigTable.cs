using System;
using System.Collections.Generic;
using System.Text;

namespace FresherMisa2026.Entities.Extensions
{
    public class ConfigTable : Attribute
    {
        /// <summary>
        /// có xóa mềm không
        /// </summary>
        public bool HasDeletedColumn { get; set; } = false;
        /// <summary>
        /// không dc trùng cột 
        /// </summary>

        public string UniqueColumns { get; set; } = string.Empty;
        /// <summary>
        /// tên bảng
        /// </summary>

        public string TableName { get; set; } = string.Empty;
        /// <summary>
        /// hàm lấy table name, unique column và has deleted column
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="hasDeletedColumn"></param>
        /// <param name="uniqueColumns"></param>

        public ConfigTable(string tableName = "", bool hasDeletedColumn = false, string uniqueColumns = "")
        {
            TableName = tableName;

            HasDeletedColumn = hasDeletedColumn;

            UniqueColumns = uniqueColumns;
        }
    }
}
