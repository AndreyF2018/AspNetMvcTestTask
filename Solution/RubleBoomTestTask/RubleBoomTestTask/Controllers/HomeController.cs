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

namespace RubleBoomTestTask.Controllers
{
    public class HomeController : Controller
    {
        private ITicketLogic ticketLogic;

        public HomeController()
        {
            ticketLogic = new TicketLogic();
        }

        public ActionResult Index()
        {

            /*
            ViewBag.Tickets = ticketLogic.GetAll();
            return View();
             */
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
        public ActionResult PostReport(byte month, short year)
        {
            ViewBag.Month = month;
            ViewBag.Year = year;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MonthlyReport, MonthlyReportView>()).CreateMapper();
            var report = mapper.Map<IEnumerable<MonthlyReport>, List<MonthlyReportView>>(ticketLogic.MakeMonthlyReport(month, year));
            return View(report);
        }
       

        /*
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        */
    }
}