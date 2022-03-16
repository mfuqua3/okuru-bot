using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OkuruBot;
using OkuruBot.Discord;

var builder = Host.CreateDefaultBuilder(args)
    .UseWindowsService();
builder.ConfigureServices((ctx, services) =>
{
    services.AddOptions();
    services.Configure<DiscordConfiguration>(ctx.Configuration.GetSection("Discord"));
    services.AddSingleton<DiscordSocketClient>();
    services.AddHostedService<BotWorker>();
    services.AddTransient<IResponseEngine, ResponseEngine>();
});
var app = builder.Build();
app.Run();