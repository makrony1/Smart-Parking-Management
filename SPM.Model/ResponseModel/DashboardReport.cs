using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Model.ResponseModel
{
    public class DashboardReport
    {
        public IncomeReport TaotalEarning { get; set; }
        public List<GroupByParking> AvailableParking { get; set; }
        public int TotalParked { get; set; }
    }
}
