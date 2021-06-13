using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MonthlyReport
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {get; set; }
        public String positionName { get; set; }

        public int positionQuantity { get; set; }

        public MonthlyReport()
        {

        }
        public MonthlyReport(String _positionName, int _positionQuantity)
        {
            this.positionName = _positionName;
            this.positionQuantity = _positionQuantity;
        }

    }
}
