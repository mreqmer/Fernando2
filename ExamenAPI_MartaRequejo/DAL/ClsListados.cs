using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsListados
    {

        private static List<ClsPersona> listadoPersonas = cargaListadoPersonas();
        private static List<ClsDepartamento> listadoDepartamentos = cargaListadoDepartamentos();

        /// <summary>
        /// Método que carga la información en la lista de personas para usarlo
        /// </summary>
        /// <returns></returns>
        private static List<ClsPersona> cargaListadoPersonas()
        {
            return new List<ClsPersona>
            {
                new ClsPersona(1, "Juana", "Sierra", new DateOnly(1998, 02, 01), "C/", "98765243", 1),
                new ClsPersona(2, "Pedro", "Gómez", new DateOnly(1994, 02, 01), "C/", "98765243", 1),
                new ClsPersona(3, "Marco", "Sánchez", new DateOnly(2000, 02, 01), "C/", "98765243", 2),
                new ClsPersona(4, "Mario", "Pérez", new DateOnly(2000, 02, 01), "C/", "98765243", 2),
                new ClsPersona(5, "María", "Barrena", new DateOnly(1999, 02, 01), "C/", "98765243", 3),
                new ClsPersona(6, "Marina", "De La Rosa", new DateOnly(1950, 02, 01), "C/", "98765243", 3),
            };  
        }

        /// <summary>
        /// Método que carga la información en la lista de departamentos para usarlo
        /// </summary>
        /// <returns></returns>
        private static List<ClsDepartamento> cargaListadoDepartamentos()
        {
            return new List<ClsDepartamento>
            {
                new ClsDepartamento(1, "Finanzas"),
                new ClsDepartamento(2, "Marketing"),
                new ClsDepartamento(3, "Recursos Humanos")
            };
        }

        /// <summary>
        /// Obtiene el listado de personas
        /// </summary>
        /// <returns></returns>
        public static List<ClsPersona> obtieneListadoPersonas()
        {
            return listadoPersonas;
        }

        /// <summary>
        /// Obtiene el listado de departamentos
        /// </summary>
        /// <returns></returns>
        public static List<ClsDepartamento> obtieneListadoDepartamentos()
        {
            return listadoDepartamentos;
        }

        /// <summary>
        /// Busca las personas que pertenecen a un departamento en concreto
        /// </summary>
        /// <param name="idDept"></param>
        /// <returns></returns>
        public static List<ClsPersona> obtienePersonasDepartamento(int idDept)
        {
            List<ClsPersona> lista = new List<ClsPersona>();

            foreach (ClsPersona p in listadoPersonas)
            {
                if(p.IdDepartamento == idDept)
                {
                    lista.Add(p);
                }
            }

            return lista;
        }
    }
}
