using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.DataAccess.Entity
{
    [Table("SpacePrice")]
    public class SpacePrice
    {
        public int Id { get; set; }
        public int SpaceTypeId { get; set; }
        public double RentPerHour { get; set; }
    }
}
