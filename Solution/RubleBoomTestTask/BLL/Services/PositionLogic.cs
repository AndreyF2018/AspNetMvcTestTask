using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class PositionLogic : IPositionLogic
    {
        private UnitOfWork positionRepo;

        public PositionLogic(UnitOfWork uow)
        {
            positionRepo = uow;
        }

        public IEnumerable<Position> GetAll()
        {
            return positionRepo.Positions.GetAll();
        }

        public Position FindById(int id)
        {
            return positionRepo.Positions.FindById(id);
        }
    }
}
