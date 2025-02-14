using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Models;

namespace WagerPlus.Data.DataModels
{
    public class BankVaults
    {
        public List<Bank> Banks { get; set; } = [];

        public BankVaults() { }
    }
}
