using BL;
using DTO;
using Ejercicio01.Models.VM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.VM
{
    [QueryProperty(nameof(IdPersona), "IdPersona")]
    public class VMDetalles : clsVMBase
    {
        #region Atributos
        private DTOPersona persona;
        private int idPersona;
        #endregion

        #region Propiedades
        public DTOPersona Persona { get { return persona; } }
        public int IdPersona { get { return idPersona; } set { idPersona = value; CargaDatos(); } }

        #endregion

        #region Constructor

        public VMDetalles()
        {
            CargaDatos();
        }

        #endregion

        #region Metodos

        public async void CargaDatos()
        {
            OnPropertyChanged(nameof(IdPersona));
            persona = await ManejadoraApi.getPersona(idPersona);
            OnPropertyChanged(nameof(Persona));

        }

        #endregion

    }
}
