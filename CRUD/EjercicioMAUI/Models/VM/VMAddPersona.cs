using Ejercicio01.Models.VM.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using BL;

namespace EjercicioMAUI.Models.VM
{
    public class VMAddPersona : clsVMBase
    {
        #region Atributos
        private DelegateCommand btnAddPersonaCommand;
        private long id = 0;
        private string nombre;
        private string apellidos;
        private string telefono;
        private string direccion;
        private string foto;
        private DateTime fechaNacimiento;
        private ObservableCollection<ClsDepartamento> listaDepartamentos;
        private ClsDepartamento? departamentoSeleccionado;
        #endregion

        #region Propiedades
        public DelegateCommand BtnAddPersonaCommand { get { return btnAddPersonaCommand; } }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; OnPropertyChanged("Nombre"); btnAddPersonaCommand.RaiseCanExecuteChanged(); }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; OnPropertyChanged("Apellidos"); btnAddPersonaCommand.RaiseCanExecuteChanged(); }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; OnPropertyChanged("Telefono"); btnAddPersonaCommand.RaiseCanExecuteChanged(); }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; OnPropertyChanged("Direccion"); btnAddPersonaCommand.RaiseCanExecuteChanged(); }
        }

        public string Foto
        {
            get { return foto; }
            set { foto = value; OnPropertyChanged("Foto"); btnAddPersonaCommand.RaiseCanExecuteChanged(); }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; OnPropertyChanged(); btnAddPersonaCommand.RaiseCanExecuteChanged(); }
        }

        public ObservableCollection<ClsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
            set { listaDepartamentos = value; OnPropertyChanged(); }
        }

        public ClsDepartamento DepartamentoSeleccionado 
        {
            get { return departamentoSeleccionado; } 
            set { departamentoSeleccionado = value; OnPropertyChanged(); btnAddPersonaCommand.RaiseCanExecuteChanged(); }
        }
        #endregion

        #region Constructor

        public VMAddPersona()
        {
            
            listaDepartamentos = new ObservableCollection<ClsDepartamento>(ClsListadosBL.ObtieneListadoDepartamentosBl());
            btnAddPersonaCommand = new DelegateCommand(btnAddPersonaCommand_Execute, btnAddPersonaCommand_CanExecute);
        }

        #endregion

        #region Command

        public bool btnAddPersonaCommand_CanExecute()
        {
            bool execute = false;

            if 
                (
                !string.IsNullOrEmpty(Nombre)&& !string.IsNullOrEmpty(Apellidos) && !string.IsNullOrEmpty(Direccion)
                && !string.IsNullOrEmpty(Telefono) && !string.IsNullOrEmpty(Foto) && departamentoSeleccionado != null
                )
            {
                execute = true;
            }

            return execute;
        }

        public async void btnAddPersonaCommand_Execute()
        {
            
            ClsPersona p = new ClsPersona(nombre, apellidos, telefono, direccion, foto, fechaNacimiento, departamentoSeleccionado.IdDepartamento);
            ClsManejadoraBL.newPersonaBl(p);

            nombre = ""; OnPropertyChanged();
            apellidos = ""; OnPropertyChanged();
            telefono = ""; OnPropertyChanged();
            direccion = ""; OnPropertyChanged();
            foto = ""; OnPropertyChanged();
            fechaNacimiento = new DateTime(1924, 01, 01); OnPropertyChanged();
            departamentoSeleccionado = null; OnPropertyChanged();

            await Shell.Current.GoToAsync("//MainPage");

        }

        #endregion
    }
}
