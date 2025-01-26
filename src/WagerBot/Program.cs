using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WagerBot
{
    public class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        private InteractionService _interactionService;

        public static async Task Main(string[] args)
        {
            var program = new Program();
            await program.RunAsync();
        }

        public async Task RunAsync()
        {
            // Create a shared instance of DiscordSocketClient
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Info,
                GatewayIntents =
                    GatewayIntents.AllUnprivileged |
                    GatewayIntents.MessageContent |
                    GatewayIntents.GuildMessages |
                    GatewayIntents.Guilds
            });

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register services
                    services.AddSingleton(_client);
                    services.AddSingleton<CommandService>();
                    services.AddSingleton<InteractionService>();

                    // TODO: Register Managers, Models, Data, etc.
                })
                .Build();
        }
    }
}