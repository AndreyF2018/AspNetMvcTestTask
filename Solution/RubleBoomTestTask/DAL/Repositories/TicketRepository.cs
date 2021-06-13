using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using DAL.ContextDB;
using System.Data.SqlClient;

namespace DAL.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        
        InventoryContext db;

        public TicketRepository ()
        {
            db = new InventoryContext();
        }
        public IEnumerable<Ticket> GetAll()
        {
            return db.Tickets.Include("Position");
        }

        public Ticket FindById(int id)
        {
            return db.Tickets.Find(id);
        }

        public void Create(Ticket item)
        {
            db.Tickets.Add(item);
           
        }

        public IEnumerable<MonthlyReport> MakeMonthlyReport(byte _month, short _year)
        {
            List<MonthlyReport> reports = new List<MonthlyReport>();
            var month = new SqlParameter("@Month", _month);
            var year = new SqlParameter("@Year", _year);
            var sqlResult = db.Database.SqlQuery<MonthlyReport>("MakeMonthlyReport @Month, @Year", month, year).ToList();
            if (sqlResult.Count == 0)
            {
                MonthlyReport emptyReport = new MonthlyReport(" ", 0);
                reports.Add(emptyReport);
            }
            else 
            {
                foreach (var item in sqlResult)
                {
                    reports.Add(new MonthlyReport(item.positionName, item.positionQuantity));
                }
            }
            return reports;
        }
    }
}
