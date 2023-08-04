using Microsoft.AspNetCore.SignalR;

public class TimedHostedService : IHostedService, IDisposable
{

    private Timer? _timer = null;
    private readonly IHubContext<ChatSampleHub> _context;

    public TimedHostedService(IHubContext<ChatSampleHub> context)
    {
        _context = context;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(1));

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        string groupName = "Matty.Matt@hotmail.com";

        _context.Clients.Group(groupName).SendAsync("broadcastMessage", "The server says", $"the time is {DateTime.Now}");



    }

    public Task StopAsync(CancellationToken stoppingToken)
    {


        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}