using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL.Interfaces
{
    public interface IPositionLogic
    {
        IEnumerable<Position> GetAll();
        Position FindById(int id);
    }
}
