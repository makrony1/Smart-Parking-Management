using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.DataAccess.Entity
{
    [Table("ParkingHistory")]
    public class ParkingHistory
    {
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehiclePlate { get; set; }
        public int ParkingSpaceId { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }

        public double CostPerHour { get; set; }
        public double BillableHours { get; set; }
        public double TotalCost { get; set; }
    }
}
