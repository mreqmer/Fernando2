using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsPersona
    {

        #region Propiedades
        private int idPersona;
        private string nombre;
        private string apellidos;
        private DateOnly fechaNac;
        private string direccion;
        private string telefono;
        private int idDepartamento;
        #endregion

        #region Atributos
        public int IdPersona { get { return idPersona; } set { idPersona = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellidos { get { return apellidos; } set { apellidos = value; } }
        public DateOnly FechaNac { get { return fechaNac; } set { fechaNac = value; } }
        public string Direccion { get { return direccion; } set {  direccion = value; } }
        public string Telefono { get { return telefono; } set {  telefono = value; } }
        public int IdDepartamento { get { return idDepartamento; } set { idDepartamento = value; } }
        #endregion

        #region Constructores
        public ClsPersona()
        {

        }
        public ClsPersona(int idPersona, string nombre, string apellidos, DateOnly fechaNac, string direccion, string telefono, int idDepartamento)
        {
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
            this.idDepartamento = idDepartamento;
        }
        #endregion

    }
}
