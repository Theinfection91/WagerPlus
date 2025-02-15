using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataModels;

namespace WagerPlus.Data.Handlers
{
    public class PayPalConfigHandler : DataHandler<PayPalConfigFile>
    {
        public PayPalConfigHandler() : base("paypal_config.json", "Configs")
        {

        }
    }
}
