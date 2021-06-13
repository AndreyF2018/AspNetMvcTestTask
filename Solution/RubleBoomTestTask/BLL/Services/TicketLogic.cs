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
    public class TicketLogic : ITicketLogic
    {
        public ITicketRepository ticketRepo;
        public TicketLogic()
        {
            ticketRepo = new TicketRepository();
        }

        public IEnumerable<Ticket> GetAll()
        {
            return ticketRepo.GetAll();
        }

        public Ticket FindById(int id)
        {
            return ticketRepo.FindById(id);
        }

        public void Create(Ticket item)
        {
            ticketRepo.Create(item);
        }

        public IEnumerable<MonthlyReport> MakeMonthlyReport(byte _month, short _year)
        {
            return ticketRepo.MakeMonthlyReport(_month, _year);
        }

    }
}
