using BL;
using ENT;

namespace EjercicioASP.Models
{
    public class PersonaConListaDepartamento : ClsPersona
    {
        #region Atributos
        private List<ClsDepartamento> listaDepartamentos;
        #endregion

        #region Propiedades
        public List<ClsDepartamento> ListaDepartamentos { get { return listaDepartamentos; } }
        #endregion

        #region Constructor
        public PersonaConListaDepartamento()
        {
            listaDepartamentos = ClsListadosBL.ObtieneListadoDepartamentosBl();
        }
        public PersonaConListaDepartamento(ClsPersona p)
        {
            base.Id = p.Id;
            base.Nombre = p.Nombre;
            base.Apellidos = p.Apellidos;
            base.Telefono = p.Telefono;
            base.Direccion = p.Direccion;
            base.Foto = p.Foto;
            base.FechaNacimiento = p.FechaNacimiento;
            base.IdDepartamento = p.IdDepartamento;

            listaDepartamentos = ClsListadosBL.ObtieneListadoDepartamentosBl();
        }
        #endregion



    }
}
