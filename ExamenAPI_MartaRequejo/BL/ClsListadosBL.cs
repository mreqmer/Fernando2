using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClsListadosBL
    {
        /// <summary>
        /// Obtiene el listado de personas de un departamento
        /// Excepcion: Si el dept es RRHH entonces solo salen las >30 años
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<ClsPersona> obtienePersonasDepartamentoBL(int idDepartamento)
        {
            List<ClsPersona> listaOriginal = ClsListados.obtienePersonasDepartamento(idDepartamento);
            List<ClsPersona> listaFiltrada = new List<ClsPersona>();
            int edad;
            DateTime fechaActual = DateTime.Now;

            if (idDepartamento == 3)
            {
                //Esto no es exacto ya que solo mira el año y no los meses y demás
                foreach (ClsPersona p in listaOriginal)
                {
                    if (fechaActual.Year - p.FechaNac.Year > 30)
                    {
                        listaFiltrada.Add(p);
                    }
                }
            }
            else
            {
                listaFiltrada = listaOriginal;
            }
            

            return listaFiltrada;
        }

        /// <summary>
        /// Obtiene toda la lista de personas
        /// </summary>
        /// <returns></returns>
        public static List<ClsPersona> obtieneListaPersonasBl()
        {
            return ClsListados.obtieneListadoPersonas();
        }

        /// <summary>
        /// Obtiene la lista completa de departamentos
        /// </summary>
        /// <returns></returns>
        public static List<ClsDepartamento> obtieneListaDepartamentoBl()
        {
            return ClsListados.obtieneListadoDepartamentos();
        }

    }
}
