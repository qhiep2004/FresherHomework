using FresherMisa2026.Entities.Position;
using System;

namespace FresherMisa2026.Application.Interfaces.Repositories
{
    public interface IPositionRepository : IBaseRepository<Position>
    {
        /// <summary>
        /// lấy ds vi trí theo mã vị trí
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Position> GetPositionByCode(string code);
    }
}