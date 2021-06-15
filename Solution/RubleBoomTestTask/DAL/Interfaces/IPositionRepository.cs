using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface IPositionRepository
    {
        IEnumerable<Position> GetAll();
        Position FindById(int id);
    }
}
