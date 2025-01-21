using BL;
using ENT;

namespace EjercicioASP.Models.VM
{
    public class ListadoPersonasConDeptVM
    {

        #region Atributos

        private List<PersonaConDeptModel> personasConDept;

        #endregion

        #region Propiedades

        public List<PersonaConDeptModel> PersonasConDept { get { return personasConDept; } }

        #endregion

        #region Constructores

        public ListadoPersonasConDeptVM()
        {
            personasConDept = CargarDatos();
        }

        #endregion

        /// <summary>
        /// llena la lista de personas con departamento
        /// </summary>
        /// <returns></returns>
        private List<PersonaConDeptModel> CargarDatos()
        {
            
            List<ClsPersona> personas = ClsListadosBL.ObtieneListadoPersonasBl();
            List<ClsDepartamento> departamentos = ClsListadosBL.ObtieneListadoDepartamentosBl();
            List<PersonaConDeptModel> p = new List<PersonaConDeptModel>();

            foreach (ClsPersona persona in personas)
            {
                p.Add(new PersonaConDeptModel(persona, departamentos));
            }

            return p;
        }
    }
}
