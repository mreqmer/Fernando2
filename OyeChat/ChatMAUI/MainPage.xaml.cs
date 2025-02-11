
using Models;
using System.Collections.ObjectModel;
namespace ChatMAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        //    private readonly HubConnection connection;
        //    public ObservableCollection<ClsMensajeUsuario> Mensajito { get; set; } = new ObservableCollection<ClsMensajeUsuario>();
        //    public MainPage()
        //    {
        //        InitializeComponent();
        //        BindingContext = this;
        //        connection = new HubConnectionBuilder().WithUrl("https://localhost:7018/chatHub").Build();

        //        connection.On<ClsMensajeUsuario>("PintarMensaje", (mensajeUsuario) =>
        //        {
        //            Dispatcher.Dispatch(() =>
        //            {
        //                Mensajito.Add(mensajeUsuario);
        //            });



        //        }
        //        );

        //        Task.Run(() =>
        //        {
        //            Dispatcher.Dispatch(async () =>

        //                await connection.StartAsync());
        //        });
        //    }

        //    private async void SendMessageButton_Clicked(object sender, EventArgs e)
        //    {
        //        ClsMensajeUsuario? mensajeUsuario = new ClsMensajeUsuario
        //        {
        //            NombreUsuario = UserNameEntry.Text,
        //            MensajeUsuario = MessageEntry.Text
        //        };
        //        await connection.InvokeCoreAsync("SendMessage", args: new[]
        //        { mensajeUsuario });
        //        MessageEntry.Text = String.Empty;
        //    }
        //}
    }
}


