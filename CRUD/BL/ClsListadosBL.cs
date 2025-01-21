using ENT;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClsListadosBL
    {
        public static List<ClsPersona> ObtieneListadoPersonasBl()
        {
            return ClsListados.ObtieneListadoPersonasDal();
        }

        public static List<ClsDepartamento> ObtieneListadoDepartamentosBl()
        {
            return ClsListados.ObtieneListadoDepartamentosDal();
        }
    }
}
