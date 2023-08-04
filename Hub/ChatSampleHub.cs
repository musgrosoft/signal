using Microsoft.AspNetCore.SignalR;

public class ChatSampleHub : Hub
{
    //public Task BroadcastMessage(string name, string message) =>
    //    //1min
    //    Clients.All.SendAsync("broadcastMessage", name, message);

    //public Task Echo(string name, string message) =>
    //    Clients.Client(Context.ConnectionId)
    //        .SendAsync("echo", name, $"{message} (echo from server)");

    //public async Task BuildMyCV(string groupName, string message)
    //{
        

    //    await Clients.Group(groupName).SendAsync("broadcastMessage","The server says", message) ;
    //}
    

    public override async Task OnConnectedAsync()
    {
        string groupName = "Matty.Matt@hotmail.com"; //get unique user identifier

        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        await base.OnConnectedAsync();
    }
}