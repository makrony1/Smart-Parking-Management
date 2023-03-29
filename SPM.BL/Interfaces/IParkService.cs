using SPM.Model.ResponseModel;
using SPM.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.BL.Interfaces
{
    public interface IParkService
    {
        CheckinResponse Checkin(CheckinModel checkinModel);
        CheckoutResponse Checkout(CheckoutModel checkoutModel);
    }
}
