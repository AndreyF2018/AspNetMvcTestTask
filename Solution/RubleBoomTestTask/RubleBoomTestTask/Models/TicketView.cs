using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;

namespace RubleBoomTestTask.Models
{
    public class TicketView
    {
        public int id { get;  set; }

        public string comment { get; set; }

        public DateTime dateCreation { get; set; }

        public int quantityPosition { get; set; }

        public int positionId { get; set; }

        public virtual Position position { get; set; }
    }
}