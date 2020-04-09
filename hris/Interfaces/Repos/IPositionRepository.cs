using System.Collections.Generic;
using coursework.Models;

namespace coursework.Interfaces.Repos
{
    public interface IPositionRepository
    {
        Position Get(int id);
        IEnumerable<Position> GetAllPositions();
        void CreatePosition(Position position);
        void UpdatePosition(Position position);
        void DeletePosition(int id);
    }
}
