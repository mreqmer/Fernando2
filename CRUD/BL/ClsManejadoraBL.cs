using ENT;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace BL
{
    public class ClsManejadoraBL
    {
        /// <summary>
        /// busca una persona por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int de filas afectadas</returns>
        public static ClsPersona findPersonaBl(int id)
        {
            return ClsManejadora.findPersonaDal(id);
        }
        /// <summary>
        /// anade una nueva persona
        /// </summary>
        /// <param name="p"></param>
        /// <returns>int de filas afectads</returns>
        public static int newPersonaBl(ClsPersona p)
        {
            return ClsManejadora.newPersonaDal(p);

        }
        /// <summary>
        /// hace update a una persona
        /// </summary>
        /// <param name="p"></param>
        /// <returns>int de filas afectads</returns>
        public static int updatePersonaBl(ClsPersona p)
        {
            return ClsManejadora.updatePersonaDal(p);
        }
        /// <summary>
        /// borra una persona por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int con filas afectadas</returns>
        public static int borrarPersonaBl(int id)
        {
            return ClsManejadora.borrarPersonaDal(id);
        }

        public static ClsDepartamento findDepartamentoBl(int idDepartamento)
        {
            return ClsManejadora.findDepartamentoDal(idDepartamento);
        }


    }
}
