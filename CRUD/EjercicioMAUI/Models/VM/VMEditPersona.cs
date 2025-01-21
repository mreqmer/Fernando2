using BL;
using Ejercicio01.Models.VM.Utils;
using ENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioMAUI.Models.VM
{

    /*using CommunityToolkit.Maui.Alerts;
        using CommunityToolkit.Maui.Core;
    CancellationTokenSource token = new CancellationTokenSource();
                var toast = Toast.Make("Persona añadida correctamente", ToastDuration.Short, 14);
                toast.Show(token.Token);
    
     */
    //Esto fcunciona
    //[QueryProperty(nameof(Id), "Id")]
    [QueryProperty(nameof(Persona), "Persona")]
    public class VMEditPersona : clsVMBase
    {
        #region Atributos
        private DelegateCommand btnEditCommand;
        private ClsDepartamento departamentoSeleccionado = new ClsDepartamento();
        private ClsPersona persona;
        private List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();
        #endregion


        #region Propiedades


        public ClsPersona Persona
        {
            get
            {
                return persona;
            }
            set
            {
                persona = value;
                btnEditCommand.RaiseCanExecuteChanged();
                departamentoSeleccionado = ClsManejadoraBL.findDepartamentoBl(persona.IdDepartamento);
                OnPropertyChanged("DepartamentoSeleccionado");
                persona.IdDepartamento = departamentoSeleccionado.IdDepartamento;
                OnPropertyChanged(nameof(Persona));
                Console.WriteLine(Persona.FechaNacimiento.ToString());

            }
        }
        public DelegateCommand BtnEditCommand { get { return btnEditCommand; } }
        public List<ClsDepartamento> ListadoDepartamentos {get{return listadoDepartamentos;} }

        public ClsDepartamento DepartamentoSeleccionado { get { return departamentoSeleccionado; } set { departamentoSeleccionado = value; OnPropertyChanged("DepartamentoSeleccionado"); } }

        #endregion

        #region Constructores
        public VMEditPersona()
        {

            listadoDepartamentos = ClsListadosBL.ObtieneListadoDepartamentosBl();
            
            btnEditCommand = new DelegateCommand(btnEditCommand_Execute, btnEditCommand_CanExecute);

        }
        #endregion
        #region Commands

        public bool btnEditCommand_CanExecute()
        {
            //bool execute = false;

            //if (persona.Nombre != "" && persona.Apellidos != "" && persona.Telefono != "" && persona.Direccion != "" && persona.Foto != "")
            //{
            //    execute = true;
            //}

            return true;
        }

        public async void btnEditCommand_Execute()
        {
            try
            {
                try
                {
                    ClsManejadoraBL.updatePersonaBl(persona);
                    await Shell.Current.GoToAsync("//MainPage");
                }
                catch
                {
                    await Shell.Current.GoToAsync("///Error");
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.GoToAsync("///Error");
            }

        }

        #endregion
    }
}

