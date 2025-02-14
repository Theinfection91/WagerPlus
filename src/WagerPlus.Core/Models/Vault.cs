using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Core.Models
{
    public class Vault
    {
        public string BankName { get; set; }
        public int Total { get; set; }
        public Dictionary<string, int> BankNotes { get; set; }

        public Vault(string bankName)
        {
            BankName = bankName;
            BankNotes = [];
        }
    }
}
