using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsDepartamento
    {

        #region Atributos
        private int idDepartamento;
        private string nombreDepartamento;
        #endregion

        #region Propiedades
        public int IdDepartamento { get { return idDepartamento; } set { idDepartamento = value; } }
        public string NombreDepartamento {get { return nombreDepartamento; } set { nombreDepartamento = value; } }
        #endregion

        #region Constructores
        public ClsDepartamento()
        {

        }
        public ClsDepartamento(int idDepartamento, string nombreDepartamento)
        {
            this.idDepartamento = idDepartamento;
            this.nombreDepartamento = nombreDepartamento;
        }
        #endregion

    }
}
