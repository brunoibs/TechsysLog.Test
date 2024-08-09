using Microsoft.AspNetCore.SignalR;

namespace TechsysLog.Api.Hub
{
    public class NotificationHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public async Task SendUpdateNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveUpdate", message);
        }
    }
}
