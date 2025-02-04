using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClsManejadoraBL
    {
        /// <summary>
        /// busca una persona por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ClsPersona obtienePersonaIdBL (int id)
        {
            return ClsManejadora.obtienePersonaId(id);
        }
        /// <summary>
        /// busca un departamento por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ClsDepartamento obtieneDepartamentoIdBL(int id)
        {
            return ClsManejadora.obtieneDepartamentoId(id);
        }

    }
}
