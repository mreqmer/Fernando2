using DAL;
using DTO;
using ENT;
using Pokeapi.VM.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokeapi.VM
{
    public class VMInicio : ClsVMBase
    {

        #region Atributos
        private CosasPokemon cosasPokemonActual;
        private int dex;
        private string nombrePoke;
        private string foto;
        private ObservableCollection<ClsPokemon> listaPokemon;
        private DelegateCommand btnAnteriorCommand;
        private DelegateCommand btnSiguienteCommand;
        private int numeroPoke;
        #endregion

        #region Propiedades

        public int Dex { get { return dex; } set { dex = value; } }
        public string NombrePoke { get { return nombrePoke; } set { nombrePoke = value; } }
        public string Foto { get { return foto; } set { foto = value; } }
        public ObservableCollection<ClsPokemon> ListaPokemon { get { return listaPokemon; } set { listaPokemon = value; } }
        public DelegateCommand BtnAnteriorCommand { get { return btnAnteriorCommand; } }
        public DelegateCommand BtnSiguienteCommand { get { return btnSiguienteCommand; } }
        public int NumeroPoke { get { return numeroPoke; } set { numeroPoke = value; OnPropertyChanged(nameof(NumeroPoke)); cargaListado(); }  }

        #endregion

        #region Constructores

        public VMInicio() 
        {

            cargaListado();
            btnAnteriorCommand = new DelegateCommand(btnAnteriorCommand_Execute, btnAnteriorCommand_CanExecute);
            btnSiguienteCommand = new DelegateCommand(btnSiguienteCommand_Execute, btnSiguienteCommand_CanExecute);
        }

        #endregion

        #region Commands
        public bool btnAnteriorCommand_CanExecute()
        {
            bool execute = false;

            if (cosasPokemonActual!=null && cosasPokemonActual.Previous!=null)
            {
                execute = true;
            }

            return execute;
        }

        public async void btnAnteriorCommand_Execute()
        {
            cosasPokemonActual = await Manejadora.getPokemon(cosasPokemonActual.Previous);
            List<ClsPokemon> pokemones = cosasPokemonActual.Results;
            listaPokemon = new ObservableCollection<ClsPokemon>(pokemones);
            OnPropertyChanged(nameof(ListaPokemon));
            btnSiguienteCommand.RaiseCanExecuteChanged();
            btnAnteriorCommand.RaiseCanExecuteChanged();
        }

        public bool btnSiguienteCommand_CanExecute()
        {
            bool execute = false;

            if (cosasPokemonActual != null && cosasPokemonActual.Next != null)
            {
                execute = true;
            }

            return execute;
        }

        public async void btnSiguienteCommand_Execute()
        {
            cosasPokemonActual = await Manejadora.getPokemon(cosasPokemonActual.Next);
            List<ClsPokemon> pokemones = cosasPokemonActual.Results;
            listaPokemon = new ObservableCollection<ClsPokemon>(pokemones);
            OnPropertyChanged(nameof(ListaPokemon));
            btnSiguienteCommand.RaiseCanExecuteChanged();
            btnAnteriorCommand.RaiseCanExecuteChanged();
        }

        #endregion

        #region Metodos

        private async void cargaListado()
        {
            cosasPokemonActual = await Manejadora.getPokemon(numeroPoke);
            List<ClsPokemon> pokemones = cosasPokemonActual.Results;
            listaPokemon = new ObservableCollection<ClsPokemon>(pokemones);
            OnPropertyChanged(nameof(ListaPokemon));
            btnSiguienteCommand.RaiseCanExecuteChanged();
            btnAnteriorCommand.RaiseCanExecuteChanged();
            
        }

        #endregion
    }
}
