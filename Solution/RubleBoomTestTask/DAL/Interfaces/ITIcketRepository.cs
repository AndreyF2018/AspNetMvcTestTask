using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAll();
        Ticket FindById(int id);
        void Create(Ticket item);
        void Delete(int id);
        void AddRange(IEnumerable<Ticket> ticket);
        void Save();
        IEnumerable<MonthlyReport> MakeMonthlyReport(byte _month, short _year);
    }
}
