using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Core.Models
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Vault Vault { get; set; }
    }
}
