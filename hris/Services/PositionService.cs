using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using coursework.Interfaces.Repos;
using coursework.Interfaces.Services;
using coursework.Models;

namespace coursework.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        public Position Get(int id)
        {
            return _positionRepository.Get(id);
        }

        public IEnumerable<Position> GetAllPositions()
        {
            return _positionRepository.GetAllPositions();
        }

        public void CreatePosition(Position position)
        {
            _positionRepository.CreatePosition(position);
        }

        public void UpdatePosition(Position position)
        {
            _positionRepository.UpdatePosition(position);
        }

        public void DeletePosition(int id)
        {
            _positionRepository.DeletePosition(id);
        }
    }
}