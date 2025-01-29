using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums;

namespace WagerPlus.Core.Models
{
    public class Pool
    {
        // Basic Info
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required PoolType Type { get; set; }
        public DateTime CreatedOn { get; set; }

        // Choices
        public List<Choice> Choices { get; set; }

        // Dynamic Info
        public bool isOpen { get; set; }
        public decimal? Odds { get; set; }
        public int AmountTotal { get; set; }
        public List<Wager> Wagers { get; set; }

        public Pool(string name, PoolType poolType, string? description = null)
        {
            Id = new(); 
            Name = name;
            Description = description ?? string.Empty;
            Type = poolType;
            CreatedOn = DateTime.Now;
            Choices = [];
            isOpen = false;
            Wagers = [];           
        }
    }
}
