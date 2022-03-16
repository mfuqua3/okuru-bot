using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OkuruBot.Discord;

namespace OkuruBot
{
    public class BotWorker : BackgroundService
    {
        private readonly DiscordSocketClient _client;
        private readonly IResponseEngine _responseEngine;
        private readonly DiscordConfiguration _config;

        private readonly List<ulong> _allowedChannels = new()
        {
            718579586622816277,
            636991039407915038,
            738041943702896723
        };

        private const ulong Okuru = 144664922188414977;

        public BotWorker(DiscordSocketClient client,
            IOptions<DiscordConfiguration> options,
            IResponseEngine responseEngine)
        {
            _client = client;
            _responseEngine = responseEngine;
            _config = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _client.LoginAsync(TokenType.Bot, _config.Token);
            await _client.StartAsync();
            _client.MessageReceived += MessageReceived;
            try
            {
                await Task.Delay(-1, stoppingToken);
            }
            finally
            {
                _client.MessageReceived -= MessageReceived;
            }
        }

        private async Task MessageReceived(SocketMessage rawMessage)
        {
            // Ignore system messages and messages from bots
            if (rawMessage is not SocketUserMessage { Source: MessageSource.User } message) return;
            if (message.Author.IsBot) return;
            if (!_allowedChannels.Contains(message.Channel.Id)) return;
            if (!_responseEngine.ShouldRespond(rawMessage.Content)) return;
            var channel = rawMessage.Channel;
            var response = rawMessage.Author.Id != Okuru ? _responseEngine.GenerateResponse() : _responseEngine.GenerateResponseToOkuru();
            await channel.SendMessageAsync(response);
        }
    }
}