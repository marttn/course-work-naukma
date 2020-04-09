using System.Collections.Generic;
using coursework.Models;

namespace coursework.Interfaces.Services
{
    public interface IPositionService
    {
        Position Get(int id);
        IEnumerable<Position> GetAllPositions();
        void CreatePosition(Position position);
        void UpdatePosition(Position position);
        void DeletePosition(int id);
    }
}
