using ChatMAUI.VM.Utils;
using Microsoft.AspNetCore.SignalR.Client;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMAUI.VM
{
    public class VMChat : ClsVMBase
    {
        private readonly HubConnection connection;
        public ObservableCollection<ClsMensajeUsuario> Mensajitos { get; set; }
        private ClsMensajeUsuario mensajeUsuario = new ClsMensajeUsuario();
        private string userName;
        private string message;
        private string sala;
        private DelegateCommand enviarCommand;

        public ClsMensajeUsuario MensajeUsuario { get { return mensajeUsuario; } set { mensajeUsuario = value;  } }
        public string UserName { get { return userName; } set { userName = value; OnPropertyChanged("UserName"); mensajeUsuario.NombreUsuario = userName;} }
        public string Message { get { return message; } set { message = value; OnPropertyChanged("Message"); mensajeUsuario.MensajeUsuario = message; } }
        public string Sala { get { return sala; } set { sala = value; OnPropertyChanged("Sala"); mensajeUsuario.Grupo = sala; } }
        public DelegateCommand EnviarCommand { get { return enviarCommand; } }


        public VMChat()
        {
            Mensajitos = new ObservableCollection<ClsMensajeUsuario>();
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7018/ChatHub").Build();
            esperarConexion();
            enviarCommand = new DelegateCommand(EnviarCommand_Execute);

            //ESTO ES EL RECEIVE MESSAGE (ETIQUETA) DE SENDMESSAGE
            connection.On<ClsMensajeUsuario>("ReceiveMessage", addMensaje);
            
        }

        private async Task esperarConexion()
        {
            MainThread.BeginInvokeOnMainThread(async() =>
            {
                 await connection.StartAsync();

            });
        }
        

        private async Task addMensaje(ClsMensajeUsuario mensaje)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Mensajitos.Add(mensaje);
                OnPropertyChanged("Mensajitos");
            });
        }

        private async void EnviarCommand_Execute()
        {

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                
                await connection.InvokeAsync("JoinGroup", mensajeUsuario);
                await connection.InvokeAsync("SendMessage", mensajeUsuario);
                
            });

    
            


        }



    }
}

