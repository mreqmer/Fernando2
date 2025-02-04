using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsDepartamento
    {
        #region Propiedades
        private int idDepartamento;
        private string nombreDepartamento;
        #endregion

        #region Atributos
        public int IdDepartamento { get { return idDepartamento; } set { idDepartamento = value; } }
        public string NombreDepartamento { get { return nombreDepartamento; } set { nombreDepartamento = value; } }
        #endregion

        public ClsDepartamento() { }

        public ClsDepartamento( int idDepartamento, string nombreDepartamento)
        {
            this.idDepartamento = idDepartamento;
            this.nombreDepartamento = nombreDepartamento;
        }

    }
}
