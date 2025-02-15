using System;
using System.Threading.Tasks;
using PaypalServerSdk.Standard;
using WagerPlus.Managers;
using PaypalServerSdk.Standard.Authentication;
using PaypalServerSdk.Standard.Models;
using PaypalServerSdk.Standard.Controllers;
using PaypalServerSdk.Standard.Exceptions;
using PaypalServerSdk.Standard.Http.Response;

namespace WagerPlus.Payments
{
    public class PayPalClient
    {
        private readonly ConfigManager _configManager;
        private readonly PaypalServerSdkClient _client;
        private readonly bool _isProduction;

        public PayPalClient(ConfigManager configManager)
        {
            Console.WriteLine("PayPal Client Check");
            _configManager = configManager;
            _isProduction = configManager.GetIsPayPalInProduction(); // Assumes "true" for production, "false" for sandbox

            _client = new PaypalServerSdkClient.Builder()
                .ClientCredentialsAuth(
                    new ClientCredentialsAuthModel.Builder(
                        _configManager.GetPayPalClientId(),
                        _configManager.GetPayPalClientSecret()
                    ).Build()
                )
                .Environment(_isProduction ? PaypalServerSdk.Standard.Environment.Production : PaypalServerSdk.Standard.Environment.Sandbox)
                .Build();
        }

        public async Task<OrdersCaptureInput> CreateOrderAsync(decimal amount, string currency = "USD")
        {
            OrdersCreateInput ordersCreateInput = new OrdersCreateInput
            {
                Body = new OrderRequest
                {
                    Intent = CheckoutPaymentIntent.Capture,
                    PurchaseUnits = new List<PurchaseUnitRequest>
        {
            new PurchaseUnitRequest
            {
                Amount = new AmountWithBreakdown
                {
                    CurrencyCode = currency,
                    MValue = "value0",
                },
            },
                    },
                },
                Prefer = "return=minimal",
            };

            try
            {
                ApiResponse<Order> result = await _client.OrdersController.OrdersCreateAsync(ordersCreateInput);
                return new OrdersCaptureInput(result.Data.Id, "application/json");
            }
            catch (ApiException e)
            {
                // TODO: Handle exception here
                Console.WriteLine(e.Message);
                return null;
            }

            //var orderRequest = new OrderRequest()
            //{
            //    Intent = CheckoutPaymentIntent.Capture,
            //    PurchaseUnits = new[] {
            //        new PurchaseUnit
            //        {
            //            Amount = new AmountWithBreakdown()
            //            {
            //                CurrencyCode = currency,
            //                MValue = am
            //            }
            //        }
            //}

            //try
            //{
            //    var orderResponse = await _client.OrdersController.OrdersCreateAsync(orderRequest);

            //    if (orderResponse.Data?.Links == null)
            //    {
            //        Console.WriteLine("No approval link found in the order response.");
            //        return null;
            //    }

            //    string orderId = orderResponse.Data.Id;
            //    string approvalUrl = orderResponse.Data.Links?.Find(link => link.Rel == "approve")?.Href;

            //    Console.WriteLine($"Order Created! PayPal Link: {approvalUrl}");
            //    return orderId;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error creating order: {ex.Message}");
            //    return null;
            //}
        }

        public async Task<bool> CaptureOrderAsync(OrdersCaptureInput ordersCaptureInput, string discordUserId)
        {
            try
            {
                var captureResult = await _client.OrdersController.OrdersCaptureAsync(ordersCaptureInput);

                if (captureResult.Data.Status == OrderStatus.Completed)
                {
                    decimal amount = decimal.Parse(captureResult.Data.PurchaseUnits[0].Payments.Captures[0].Amount.MValue);
                    string payerEmail = captureResult.Data.Payer.EmailAddress;

                    Console.WriteLine($"Payment successful! {amount} USD received from {payerEmail}");

                    // Award currency in WagerBot
                    await AwardCurrencyToUser(discordUserId, amount);
                    return true;
                }
                else
                {
                    Console.WriteLine("Payment not completed.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error capturing order: {ex.Message}");
                return false;
            }
        }

        private Task AwardCurrencyToUser(string discordUserId, decimal amount)
        {
            var coins = (int)(amount * 100); // Example: $1 = 100 coins
            Console.WriteLine($"User {discordUserId} donated ${amount}. Awarded {coins} coins.");

            // Add logic to update user balance in WagerBot (e.g., update database or in-memory store)
            return Task.CompletedTask;
        }
    }
}
