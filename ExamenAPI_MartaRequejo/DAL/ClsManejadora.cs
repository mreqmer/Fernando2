using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class ClsManejadora
    {
        /// <summary>
        /// Busca a una persona en el listado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ClsPersona obtienePersonaId(int id)
        {
            ClsPersona persona = new ClsPersona();
            persona = ClsListados.obtieneListadoPersonas().Find(p => p.IdPersona == id);
            return persona;
        }

        /// <summary>
        /// Busca un departamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ClsDepartamento obtieneDepartamentoId(int id)
        {
            ClsDepartamento departamento = new ClsDepartamento();
            departamento = ClsListados.obtieneListadoDepartamentos().Find(d => d.IdDepartamento == id);
            return departamento;
        }
    }
}
