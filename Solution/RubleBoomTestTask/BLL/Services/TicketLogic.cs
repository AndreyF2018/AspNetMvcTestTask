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
        private UnitOfWork ticketRepo;

        public TicketLogic(UnitOfWork uow)
        {
            ticketRepo = uow;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return ticketRepo.Tickets.GetAll();
        }

        public Ticket FindById(int id)
        {
            return ticketRepo.Tickets.FindById(id);
        }

        public void Create(Ticket item)
        {
            ticketRepo.Tickets.Create(item);
        }

        public void Delete(int id)
        {
            ticketRepo.Tickets.Delete(id);
        }
        public void Save()
        {
            ticketRepo.Tickets.Save();
        }

        public Position GetPosition(int id)
        {
            Position position = ticketRepo.Positions.FindById(id);
            return position;
        }

        public IEnumerable<Position> GetAllPositions()
        {
            return ticketRepo.Positions.GetAll();
        }

        public void AddRange(IEnumerable<Ticket> tickets)
        {
            ticketRepo.Tickets.AddRange(tickets);
        }

        public IEnumerable<MonthlyReport> MakeMonthlyReport(byte _month, short _year)
        {
            return ticketRepo.MakeMonthlyReport(_month, _year);
        }

    }
}
