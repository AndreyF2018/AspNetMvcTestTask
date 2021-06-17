using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.Services;
using Entities;
using AutoMapper;
using RubleBoomTestTask.Models;
using System.Threading;

namespace RubleBoomTestTask.Controllers
{
    public class HomeController : Controller
    {
        private ITicketLogic ticketLogic;
        private List<Ticket> addedTickets;

        public HomeController(ITicketLogic _ticketLogic)
        {
            this.ticketLogic = _ticketLogic;
            addedTickets = new List<Ticket>();
        }

        public ActionResult Index()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketView>()).CreateMapper();
            var tickets = mapper.Map<IEnumerable<Ticket>, List<TicketView>>(ticketLogic.GetAll());
            return View(tickets);

        }

        [HttpGet]
        public ActionResult Report()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Report(byte month, short year)
        {
            ViewBag.Month = month;
            ViewBag.Year = year;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MonthlyReport, MonthlyReportView>()).CreateMapper();
            var report = mapper.Map<IEnumerable<MonthlyReport>, List<MonthlyReportView>>(ticketLogic.MakeMonthlyReport(month, year));
            return View("PostReport", report);
        }
        
        [HttpGet]
        public ActionResult CreateTicket()
        {
            ViewBag.Positions = ticketLogic.GetAllPositions().ToArray();

            return View();
        }

        [HttpPost]
        public Object CreateTicket(int[] positionsId)
        {
            foreach(var item in positionsId)
            {
                Position position = ticketLogic.GetPosition(item);
                Ticket ticket = new Ticket(position, 1);
                addedTickets.Add(ticket);
            }
            ViewBag.AddedTickets = addedTickets;
            TempData["AddedTickets"] = addedTickets;
            return View("PostCreateTicket");
        }

       [HttpPost]
       public ActionResult PostCreateTicket(int id, int[] quantityPosition, string[] comment)
       {
           addedTickets = (List<Ticket>)TempData["AddedTickets"];
           if (addedTickets.Count == 0)
           {
               throw new Exception("Empty tickets");
           }
            try
            {
                for (int i = 0; i < addedTickets.Count; i++)
                {
                    int currentQuantityPosition = quantityPosition[i];
                    string currentComment = comment[i];
                    Ticket ticket = new Ticket(addedTickets[i].position, currentQuantityPosition, currentComment);
                    ticketLogic.Create(ticket);
                    ticketLogic.Save();

                }
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;
                return View("ExceptionPage");
            }
            return View("SuccessfulAddition");      
       }

        [HttpGet]
        public ActionResult DeleteTicket(long id)
        {
            Ticket deletedTicket = ticketLogic.FindById((int)id);
            return View(deletedTicket);
        }

        [HttpPost]
        public ActionResult DeleteTicket(int id)
        {
            Ticket deletedTicket = ticketLogic.FindById(id);
            ViewBag.DeletedTicket = deletedTicket;
            try
            {
                ticketLogic.Delete(id);
                ticketLogic.Save();
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;
                return View("ExceptionPage");
            }
            return View("SucessfulDeleted");
        }

    }
}