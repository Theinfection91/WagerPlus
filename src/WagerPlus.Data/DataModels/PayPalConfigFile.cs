using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Data.DataModels
{
    public class PayPalConfigFile
    {
        public string ClientId { get; set; } = "YOUR_CLIENT_ID";
        public string ClientSecret { get; set; } = "YOUR_CLIENT_SECRET";
        public bool IsPayPalInProduction { get; set; } = false;

        public PayPalConfigFile() { }
    }
}
