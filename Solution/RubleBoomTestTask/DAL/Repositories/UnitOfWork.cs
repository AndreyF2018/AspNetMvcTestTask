using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ContextDB;
using Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork
    {
        private InventoryContext db;
        private TicketRepository ticketRepo;
        private PositionRepository positionRepo;

        public UnitOfWork()
        {
            db = new InventoryContext();
        }

        public ITicketRepository Tickets
        {
            get
            {
                if (ticketRepo == null)
                {
                    ticketRepo = new TicketRepository(db);
                }
                return ticketRepo;
            }
        }

        public IPositionRepository Positions
        {
            get
            {
                if (positionRepo == null)
                {
                    positionRepo = new PositionRepository(db);
                }
                return positionRepo;
            }
        }

        public IEnumerable<MonthlyReport> MakeMonthlyReport(byte _month, short _year)
        {
            if (ticketRepo == null)
            {
                ticketRepo = new TicketRepository(db);
            }
            return ticketRepo.MakeMonthlyReport(_month, _year);
        }
    }
}
