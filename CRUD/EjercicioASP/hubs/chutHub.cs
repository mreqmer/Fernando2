using ENT;
using Microsoft.AspNetCore.SignalR;


namespace BlazorSignalRApp.Hubs;

public class chatHub : Hub
{
    public async Task SendMessage(ModelMensaje mensajeUsuaro)
    {
        await Clients.All.SendAsync("ReceiveMessage", mensajeUsuaro);
    }
}