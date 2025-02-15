using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Payments;

namespace WagerPlus.CommandLogic.DonationCommands
{
    public class TestDonateLogic : Logic
    {
        private PayPalClient _client;
        public TestDonateLogic(PayPalClient payPalClient) : base("Test Donate")
        {
            _client = payPalClient;
        }

        public async Task TestDonateProcess(decimal amount, SocketInteractionContext context)
        {
            var orderCapture = await _client.CreateOrderAsync(amount);
            await _client.CaptureOrderAsync(orderCapture, context.User.Id);
            await context.Channel.SendMessageAsync($"{orderCapture.Id} {orderCapture.PaypalRequestId} {orderCapture.ContentType}");
        }
    }
}
