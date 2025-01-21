using BL;
using ENT;

namespace EjercicioASP.Models
{
    public class PersonaConDeptModel : ClsPersona
    {

        #region Atributos
        private string departamento;
        #endregion

        #region Propiedades
        public string Departamento { get { return departamento; } }
        #endregion

        #region Constructor
        public PersonaConDeptModel(ClsPersona p, List<ClsDepartamento> listaDept) {
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

        //public PersonaConDeptModel(int idPersona)
        //{
        //    ClsPersona persona = ClsManejadoraBL.findPersonaBl(idPersona);

        //    if (persona != null)
        //    {
        //        this.Id = persona.Id;
        //        this.Nombre = persona.Nombre;
        //        this.Apellidos = persona.Apellidos;
        //        this.Telefono = persona.Telefono;
        //        this.Direccion = persona.Direccion;
        //        this.Foto = persona.Foto;
        //        this.FechaNacimiento = persona.FechaNacimiento;
        //        this.IdDepartamento = persona.IdDepartamento;

        //        ClsDepartamento dep = ClsManejadoraBL.findDepartamentoBl(this.IdDepartamento);

        //        if (dep != null)
        //        {
        //            this.departamento = dep.NombreDepartamento;
        //        }
        //    }

        //}

    }
}
