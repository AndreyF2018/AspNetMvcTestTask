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
        
        private InventoryContext db;

        public TicketRepository (InventoryContext context)
        {
            this.db = context;
        }
        public IEnumerable<Ticket> GetAll()
        {
            return db.Tickets.Include("Position");
        }

        public Ticket FindById(int id)
        {
            Ticket foundTicket = db.Tickets.Find(id);
            if (foundTicket != null)
            {
                return db.Tickets.Find(id);
            }
            else
            {
                throw new Exception("Found ticket is null");
            }
        }

        public void Create(Ticket item)
        {
            if (item != null)
            {

                var comment = new SqlParameter("@Comment", item.comment);
                var positionId = new SqlParameter("@PositionId", item.positionId);
                var quantityPosition = new SqlParameter("@QuantityPosition", item.quantityPosition);
                db.Database.ExecuteSqlCommand("exec AddTicket @Comment, @PositionId, @QuantityPosition", comment, positionId, quantityPosition);
            }
            else
            {
                throw new Exception("Ticket is null");
            }
        }

        public void Delete(int id)
        {
            Ticket deeletedTicket = db.Tickets.Find(id);
            if (deeletedTicket != null)
            {
                db.Tickets.Remove(deeletedTicket);
            }
            else
            {
                throw new Exception("Deleted ticket is null");
            }
        }

        public void AddRange(IEnumerable<Ticket> tickets)
        {
            if (tickets.Count() != 0)
            {
                db.Tickets.AddRange(tickets);
            }
            else
            {
                throw new Exception("Tickets list is null");
            }
        }

        public void Save()
        {
            db.SaveChanges();
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
