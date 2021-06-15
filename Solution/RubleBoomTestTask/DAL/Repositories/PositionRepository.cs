using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL.Interfaces;
using DAL.ContextDB;

namespace DAL.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        InventoryContext db;
        public PositionRepository(InventoryContext context)
        {
            this.db = context;
        }
        public IEnumerable<Position> GetAll()
        {
            return db.Positions;
        }

        public Position FindById(int id)
        {
            return db.Positions.Find(id);
        }
    }
}
