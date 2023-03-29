using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.DataAccess.Entity
{
    [Table("ParkingSpace")]
    public class ParkingSpace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpaceTypeId { get; set; }
        public bool IsOccpiped { get; set; }
        public bool IsAvailable { get; set; }
    }
}
