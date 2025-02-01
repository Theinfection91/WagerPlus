using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;

namespace WagerPlus.Bot.Modals.PoolModals
{
    public class ClosePoolModal : IModal
    {
        public string Title => "Close Pool Confirmation";

        [InputLabel("Enter Pool ID Number - Case Sensitive")]
        [ModalTextInput("pool_id_one", placeholder: "Enter pool ID number...")]
        public string PoolIdOne { get; set; }

        [InputLabel("Enter Pool ID Number Again - Case Sensitive")]
        [ModalTextInput("pool_id_two", placeholder: "Enter pool ID number again...")]
        public string PoolIdTwo { get; set; }
    }
}
