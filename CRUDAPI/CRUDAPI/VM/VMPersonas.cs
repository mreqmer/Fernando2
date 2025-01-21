using Ejercicio01.Models.VM.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BL;

namespace CRUDAPI.VM
{
    public class VMPersonas : clsVMBase
    {
        #region Atributos

        private DelegateCommand btnAddCommand;
        private DelegateCommand btnDeleteCommand;
        private DelegateCommand btnEditCommand;
        private DelegateCommand btnDetallesCommand;
        private ObservableCollection<DTOPersona> personasConDept = new ObservableCollection<DTOPersona>();
        private ObservableCollection<DTOPersona> listaPersonas = new ObservableCollection<DTOPersona>();
        private DTOPersona personaSeleccionada;


        #endregion

        #region Propiedades
        public bool EsCargando { get; set; } = true;
        public DelegateCommand BtnAddCommand { get { return btnAddCommand; } }
        public DelegateCommand BtnDeleteCommand { get { return btnDeleteCommand; } }
        public DelegateCommand BtnEditCommand { get { return btnEditCommand; } }
        public DelegateCommand BtnDetallesCommand { get { return btnDetallesCommand; } }
        public ObservableCollection<DTOPersona> PersonasConDept { get { return personasConDept; } }
        public ObservableCollection<DTOPersona> ListaPersonas { get { return listaPersonas; } }
        public DTOPersona PersonaSelecionada
        {
            get { return personaSeleccionada; }
            set
            {
                personaSeleccionada = value;
                OnPropertyChanged("PersonaSeleccionada");
                btnAddCommand.RaiseCanExecuteChanged();
                btnDeleteCommand.RaiseCanExecuteChanged();
                btnEditCommand.RaiseCanExecuteChanged();

            }
        }
        public DTOPersona PersonaSeleccionada { get { return personaSeleccionada; } set { PersonaSeleccionada = value; } }

        #endregion

        #region Constructores

        public VMPersonas()
        {

            CargarDatos();
            btnAddCommand = new DelegateCommand(btnAddCommand_Execute, btnAddComand_CanExecute);
            btnEditCommand = new DelegateCommand(btnEditCommand_Execute, btnEditCommand_CanExecute);
            btnDeleteCommand = new DelegateCommand(btnDeleteCommand_Execute, btnDeleteCommand_CanExecute);
            btnDetallesCommand = new DelegateCommand(btnDetallesCommand_Execute);

        }

        public VMPersonas(int idPersonaSeleccionada)
        {
            CargarDatos();
            btnAddCommand = new DelegateCommand(btnAddCommand_Execute, btnAddComand_CanExecute);
            btnEditCommand = new DelegateCommand(btnEditCommand_Execute, btnEditCommand_CanExecute);
            btnDeleteCommand = new DelegateCommand(btnDeleteCommand_Execute, btnDeleteCommand_CanExecute);
        }

        #endregion

        /// <summary>
        /// llena la lista de personas con departamento
        /// </summary>
        /// <returns></returns>
        private async void CargarDatos()
        {
            listaPersonas = new ObservableCollection<DTOPersona>(await ManejadoraApi.getPersonas());
            OnPropertyChanged(nameof(ListaPersonas));
        }

        #region Command

        /// <summary>
        /// Boton para añadir persona Can Execute
        /// </summary>
        /// <returns></returns>
        public bool btnAddComand_CanExecute()
        {


            return false;

        }

        /// <summary>
        /// Execute para ir a la vista de aladir persona
        /// </summary>
        private async void btnAddCommand_Execute()
        {

            await Shell.Current.GoToAsync("///addPersonas");

        }

        public bool btnEditCommand_CanExecute()
        {
            bool execute = false;

            if (personaSeleccionada != null)
            {
                execute = true;
            }

            return false;
        }

        public async void btnEditCommand_Execute()
        {
           



        }
        public bool btnDeleteCommand_CanExecute()
        {
            bool execute = false;

            if (personaSeleccionada != null)
            {
                execute = true;
            }

            return execute;
        }

        public async void btnDeleteCommand_Execute()
        {

            await ManejadoraApi.deletePersona(personaSeleccionada.Id);
            listaPersonas.Remove(personaSeleccionada);
            EsCargando = false;
            OnPropertyChanged(nameof(EsCargando));
            OnPropertyChanged(nameof(ListaPersonas));

        }

        public async void btnDetallesCommand_Execute()
        {

            try
            {
                int id = personaSeleccionada.Id;



                var queryParams = new Dictionary<string, object>
                {
                    { "IdPersona", id}
                };

                await Shell.Current.GoToAsync("///detalles", queryParams);
            }
            catch (Exception ex)
            {

                await Shell.Current.GoToAsync("///Error");

            }

        }



        #endregion
    }
}