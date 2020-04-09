using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using coursework.Interfaces.Repos;
using coursework.Models;

namespace coursework.Repositories
{
    public class PositionRepository : Repository, IPositionRepository
    {
        public Position Get(int id)
        {
            return Context.Positions.Find(id);
        }

        public IEnumerable<Position> GetAllPositions()
        {
            return Context.Positions.ToList();
        }

        public void CreatePosition(Position position)
        {
            if (position == null) return;
            Context.Positions.Add(position);
            SaveChanges();
        }

        public void UpdatePosition(Position position)
        {
            if (position == null) return;
            Context.Positions.AddOrUpdate(position);
            SaveChanges();
        }

        public void DeletePosition(int id)
        {
            var data = Get(id);
            if (data == null) return;
            Context.Positions.Remove(data);
            SaveChanges();
        }
    }
}