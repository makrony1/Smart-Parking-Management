using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.DataAccess.Entity
{
    [Table("SpaceType")]
    public class SpaceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
