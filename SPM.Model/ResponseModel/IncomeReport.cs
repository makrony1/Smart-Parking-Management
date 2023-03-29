using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Model.ResponseModel
{
    public class IncomeReport
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public double Total { get; set; }
    }
}
