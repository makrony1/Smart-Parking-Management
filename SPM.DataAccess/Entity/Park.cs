using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.DataAccess.Entity
{
    [Table("Park")]
    public class Park
    {
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehiclePlate { get; set; }
        public int ParkingSpaceId { get; set; }
        public DateTime CheckinTime { get; set; }
    }
}
