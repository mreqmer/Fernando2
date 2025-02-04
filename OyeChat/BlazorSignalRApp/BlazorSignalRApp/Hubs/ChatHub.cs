using Microsoft.AspNetCore.SignalR;
using Models;
using System.Text.RegularExpressions;

namespace BlazorSignalRApp.Hubs
{
    public class ChatHub : Hub
    {
        //Cuando se llama a mandar mensaje este es enviado y se llama a ReceiveMessage para que lo pinte el cliente en el chat
        public async Task SendMessage(ClsMensajeUsuario mensajeUsuario)
        {
            await Clients.Group(mensajeUsuario.Grupo).SendAsync("ReceiveMessage", mensajeUsuario);
        }

        public async Task JoinGroup(ClsMensajeUsuario usuario)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, usuario.Grupo);
        }

        public async Task LeaveGroup(ClsMensajeUsuario usuario)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, usuario.Grupo);
        }

    }
}
