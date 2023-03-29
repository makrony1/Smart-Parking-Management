using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.DataAccess.Entity
{
    [Table("Payment")]
    public class Payment
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int ParkingHistoryId { get; set; }
        public DateTime DateTime { get; set; }

    }
}
