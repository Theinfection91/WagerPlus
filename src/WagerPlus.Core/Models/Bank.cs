using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Core.Models
{
    public class Bank
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
        public Dictionary<string, int> Accounts { get; set; }

        public Bank(string id, string name)
        {
            Id = id;
            Name = name;
            Accounts = [];
        }
    }
}
