using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsListados
    {
        /// <summary>
        /// Conecta con la base de datos para devolver un listado de personas
        /// </summary>
        /// <returns></returns>
        public static List<ClsPersona> ObtieneListadoPersonasDal()
        {
            SqlConnection miConexion = new SqlConnection();
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsPersona oPersona;
            miConexion.ConnectionString = ClsConexion.CadenaConexion();

            try
            {
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM personas";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {

                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();
                        oPersona.Id = (int)miLector["ID"];
                        oPersona.Nombre = (string)miLector["Nombre"];
                        oPersona.Apellidos = (string)miLector["Apellidos"];
                        oPersona.Telefono = (string)miLector["Telefono"];
                        oPersona.Direccion = (string)miLector["Direccion"];
                        oPersona.Foto = (string)miLector["Foto"];
                        oPersona.FechaNacimiento = (DateTime)miLector["FechaNAcimiento"];
                        oPersona.IdDepartamento = (int)miLector["IDDepartamento"];

                        listadoPersonas.Add(oPersona);
                    }
                    miLector.Close();
                    miConexion.Close();
                }
            }
            catch (SqlException exSql)
            {
                throw exSql;

            }
            return listadoPersonas;

        }

        public static List<ClsDepartamento> ObtieneListadoDepartamentosDal()
        {
            SqlConnection miConexion = new SqlConnection();
            List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsDepartamento oDept;
            miConexion.ConnectionString = ClsConexion.CadenaConexion();

            try
            {
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM Departamentos";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {

                    while (miLector.Read())
                    {
                        oDept = new ClsDepartamento((int)miLector["ID"], (string)miLector["Nombre"]);
                        //oDept.Id = (int)miLector["ID"];
                        //oDept.Nombre = (string)miLector["Nombre"];


                        listadoDepartamentos.Add(oDept);
                    }
                    miLector.Close();
                    miConexion.Close();
                }
            }
            catch (SqlException exSql)
            {
                throw exSql;

            }
            return listadoDepartamentos;

        }


    }
}
