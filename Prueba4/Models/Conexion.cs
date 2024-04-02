using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Prueba4.Models
{
    public class Conexion
    {
        SqlConnection conexion = new SqlConnection();
        bool conectar()
        {
            try
            {
                conexion.ConnectionString = "Persist Security Info=False;Integrated Security =SSPI;Initial Catalog=BaseDatosProyectoValencia;Data Source=servidorequipo5.database.windows.net";
                conexion.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        void desconectar()
        {
            conexion.Close();
        }

        public int selval(string query)
        {

            if (conectar() == true)
            {

                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int valor = dr.GetInt32(0);
                    desconectar();
                    return valor;

                }
                else
                {
                    desconectar();
                    return 0;
                }


            }
            else
            {
                return 0;
            }
        }

        public DataTable seltable(string query)
        {
            DataTable dt = new DataTable();
            if (conectar() == true)
            {

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.Fill(dt);
                desconectar();
                return dt;
            }
            else
            {
                desconectar();
                return dt;
            }
        }


        public int actualizar(string query)
        {

            try
            {
                if (conectar() == true)
                {
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.ExecuteNonQuery();
                    desconectar();
                    return 1;

                }
                else
                {

                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }
        public int eliminar(string query)
        {

            try
            {
                if (conectar() == true)
                {
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.ExecuteNonQuery();
                    desconectar();
                    return 1;

                }
                else
                {

                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }

        public int Insertar(string query)
        {

            try
            {
                if (conectar() == true)
                {
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.ExecuteNonQuery();
                    desconectar();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }
    }
}