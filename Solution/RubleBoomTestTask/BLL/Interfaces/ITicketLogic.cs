using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL.Interfaces
{
    public interface ITicketLogic
    {
        IEnumerable<Ticket> GetAll();
        Ticket FindById(int id);
        void Create(Ticket item);
        void Delete(int id);
        void Save();
        Position GetPosition(int id);
        IEnumerable<Position> GetAllPositions();
        void AddRange(IEnumerable<Ticket> ticket);
        IEnumerable<MonthlyReport> MakeMonthlyReport(byte _month, short _year);
    }
}
