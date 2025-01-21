using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsManejadora
    {
        
        /// <summary>
        /// busca una persona por su id si existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ClsPersona findPersonaDal(int id)
        {
            SqlConnection miConexion = new SqlConnection();
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsPersona oPersona = new ClsPersona();
            miConexion.ConnectionString = ClsConexion.CadenaConexion();

            try

            {
                miConexion.Open();
                miComando.Parameters.AddWithValue("@id", id);
                miComando.CommandText = "SELECT * FROM personas WHERE ID = @id";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {
                    miLector.Read();
                    //Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IdDepartamento
                    oPersona = new ClsPersona();
                    oPersona.Id = (int)miLector["ID"];
                    oPersona.Nombre = (string)miLector["Nombre"];
                    oPersona.Apellidos = (string)miLector["Apellidos"];
                    oPersona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                    oPersona.Direccion = (string)miLector["Direccion"];
                    oPersona.Foto = (string)miLector["Foto"];
                    oPersona.Telefono = (string)miLector["Telefono"];
                    oPersona.IdDepartamento = (int)miLector["IDDepartamento"];

                }

                miLector.Close();
                miConexion.Close();

            }
            catch (SqlException exSql)
            {

                throw exSql;

            }


            return oPersona;
        }
        /// <summary>
        /// Añade una nueva persona
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int newPersonaDal(ClsPersona p)
        {
            int filasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miConexion.ConnectionString = ClsConexion.CadenaConexion();

            try
            {

                miConexion.Open();
                miComando.Parameters.AddWithValue("@nombre", p.Nombre);
                miComando.Parameters.AddWithValue("@apellidos", p.Apellidos);
                miComando.Parameters.AddWithValue("@telefono", p.Telefono);
                miComando.Parameters.AddWithValue("@direccion", p.Direccion);
                miComando.Parameters.AddWithValue("@foto", p.Foto);
                miComando.Parameters.AddWithValue("@fechaNacimiento", p.FechaNacimiento);
                miComando.Parameters.AddWithValue("@idDepartamento", p.IdDepartamento);
                miComando.CommandText = "INSERT INTO Personas (nombre, apellidos, telefono, direccion, foto, fechaNacimiento, idDepartamento) " +
                        "VALUES (@nombre, @apellidos, @telefono, @direccion, @foto, @fechaNacimiento, @idDepartamento)";

                miComando.Connection = miConexion;
                filasAfectadas = miComando.ExecuteNonQuery();

            }
            catch (SqlException exSql)
            {

            }
            finally
            {
                miConexion.Close();
            }


            return filasAfectadas;
        }

        /// <summary>
        /// updatea una persona
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int updatePersonaDal(ClsPersona p)
        {
            int filasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsPersona oPersona = new ClsPersona();
            miConexion.ConnectionString = ClsConexion.CadenaConexion();

            try
            {

                miConexion.Open();
                miComando.Parameters.AddWithValue("@id", p.Id);
                miComando.Parameters.AddWithValue("@nombre", p.Nombre);
                miComando.Parameters.AddWithValue("@apellidos", p.Apellidos);
                miComando.Parameters.AddWithValue("@telefono", p.Telefono);
                miComando.Parameters.AddWithValue("@direccion", p.Direccion);
                miComando.Parameters.AddWithValue("@foto", p.Foto);
                miComando.Parameters.AddWithValue("@fechaNacimiento", p.FechaNacimiento);
                miComando.Parameters.AddWithValue("@idDepartamento", p.IdDepartamento);
                miComando.CommandText = "UPDATE Personas SET nombre = @nombre, apellidos = @apellidos, telefono = @telefono, " +
                        "direccion = @direccion, foto = @foto, fechaNacimiento = @fechaNacimiento, idDepartamento = @idDepartamento " +
                        "WHERE id = @id";
                miComando.Connection = miConexion;
                filasAfectadas = miComando.ExecuteNonQuery();

            }
            catch (SqlException exSql)
            {

            }
            finally
            {
                miConexion.Close();
            }


            return filasAfectadas;
        }
        /// <summary>
        /// Borra a una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int borrarPersonaDal(int id)
        {
            int filasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsPersona oPersona = new ClsPersona();
            miConexion.ConnectionString = ClsConexion.CadenaConexion();
            miComando.Parameters.AddWithValue("@id", id);

            try
            {
                miConexion.Open();
                miComando.CommandText = "DELETE FROM Personas WHERE id=@id";
                miComando.Connection = miConexion;
                filasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return filasAfectadas;
        }

        public static ClsDepartamento findDepartamentoDal(int idDepartamento)
        {
            SqlConnection miConexion = new SqlConnection();
            List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsDepartamento oDept = new ClsDepartamento();
            miConexion.ConnectionString = ClsConexion.CadenaConexion();

            try

            {
                miConexion.Open();
                miComando.Parameters.AddWithValue("@id", idDepartamento);
                miComando.CommandText = "SELECT * FROM departamentos WHERE ID = @id";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {
                    miLector.Read();

                    oDept = new ClsDepartamento((int)miLector["ID"], (string)miLector["Nombre"]);
                    //oDept.IdDepartamento = (int)miLector["ID"];
                    //oDept.NombreDepartamento = (string)miLector["Nombre"];


                }

                miLector.Close();
                miConexion.Close();

            }
            catch (Exception ex)
            {

            }

            return oDept;

        }
    }
}
