using FresherMisa2026.Application.Interfaces;
using FresherMisa2026.Application.Interfaces.Repositories;
using FresherMisa2026.Application.Interfaces.Services;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.Enums;
using FresherMisa2026.Entities.Position;
using System;
using System.Collections.Generic;

namespace FresherMisa2026.Application.Services
{
    public class PositionService : BaseService<Position>, IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(
            IBaseRepository<Position> baseRepository,
            IPositionRepository positionRepository
            ) : base(baseRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<ServiceResponse> GetPositionByCodeAsync(string code)
        {
            var position = await _positionRepository.GetPositionByCode(code);
            if (position == null)
                return CreateErrorResponse(ResponseCode.NotFound, "Không tìm thấy vị trí với mã này");
            return CreateSuccessResponse(position);
        }

        protected override async Task<List<ValidationError>> ValidateCustomAsync(Position position)
        {
            var errors = new List<ValidationError>();

            if (!string.IsNullOrEmpty(position.PositionCode) && position.PositionCode.Length > 20)
            {
                errors.Add(new ValidationError("PositionCode", "Mã vị trí không được vượt quá 20 ký tự"));
            }

            return errors;
        }
    }
}