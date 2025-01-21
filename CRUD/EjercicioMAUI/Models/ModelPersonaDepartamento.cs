using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioMAUI.Models
{
    public class ModelPersonaDepartamento : ClsPersona
    {

        #region Atributos
        private string departamento = "";
        #endregion

        #region Propiedades
        public string Departamento { get { return departamento; } }
        #endregion
        #region Constructor
        public ModelPersonaDepartamento()
        {

        }
        public ModelPersonaDepartamento(ClsPersona p, List<ClsDepartamento> listaDept)
        {
            base.Id = p.Id;
            base.Nombre = p.Nombre;
            base.Apellidos = p.Apellidos;
            base.Telefono = p.Telefono;
            base.Direccion = p.Direccion;
            base.Foto = p.Foto;
            base.FechaNacimiento = p.FechaNacimiento;
            base.IdDepartamento = p.IdDepartamento;

            string dep = listaDept.First(dept => dept.IdDepartamento == p.IdDepartamento).NombreDepartamento;
            departamento = dep;
        }
        #endregion

    }
}
