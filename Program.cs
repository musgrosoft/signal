var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR(
    hubOptions =>
    {
        hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
        hubOptions.ClientTimeoutInterval = TimeSpan.FromMinutes(1);
    }

    ).AddAzureSignalR();

builder.Services.AddHostedService<TimedHostedService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseRouting();
app.UseStaticFiles();
app.MapHub<ChatSampleHub>("/chat");
app.Run();

