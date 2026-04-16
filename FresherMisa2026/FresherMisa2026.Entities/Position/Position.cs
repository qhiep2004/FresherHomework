using FresherMisa2026.Entities.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace FresherMisa2026.Entities.Position
{
    [ConfigTable("Position", false, "PositionCode")]
    public class Position : BaseModel
    {
        /// <summary>
        /// id vị trí 
        /// </summary>
        [Key]
        public Guid PositionID { get; set; }
        /// <summary>
        /// mã vị trí 
        /// </summary>
        [IRequired]
        public string PositionCode { get; set; }
        /// <summary>
        /// tên vị trí
        /// </summary>
       [IRequired]

        public string PositionName { get; set; }
    }
}