using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace proyectoVehiculos.Clases
{
    public class CTA_vehiculo
    {

        public List<Vehiculo> Listado()
        {
            List<Vehiculo> lista = new List<Vehiculo>();

            try
            {
                using(SqlConnection conn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "_CONSULTA_VEHICULOS";
                    comando.Parameters.Add("@ID_VEHICULO", SqlDbType.Int).Value = DBNull.Value;
                    comando.Connection = conn;
                    comando.CommandTimeout = 240;
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                            lista.Add(
                                new Vehiculo()
                                {
                                    Patente = reader["patente"].ToString(),
                                    Marca = reader["marca"].ToString(),
                                    Modelo = reader["modelo"].ToString(),
                                    Cant_puertas = int.Parse(reader["cant_puertas"].ToString()),
                                    Nombre_titular = reader["nombre_titular"].ToString(),
                                }
                                );

                        }

                    }
                    catch (Exception ex)
                    {
                        lista = new List<Vehiculo>();
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }


                }



            }
            catch
            {

            }

            return lista;
        }

        public string guardarVehiculo(string patente, string marca, string modelo, int puertas, string titular)
        {
            string resultado = "";

            using (SqlConnection conn = new SqlConnection(Conexion.cn))
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "_AGREGAR_VEHICULO";
                comando.Parameters.Add("@PATENTE", SqlDbType.VarChar).Value = patente;
                comando.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = marca;
                comando.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = modelo;
                comando.Parameters.Add("@CANT_PUERTAS", SqlDbType.Int).Value = puertas;
                comando.Parameters.Add("@TITULAR", SqlDbType.VarChar).Value = titular;
                comando.Connection = conn;
                comando.CommandTimeout = 240;
                try
                {
                    conn.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        resultado = reader["resultado"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    resultado = ex.Message;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return resultado;
        }

    }
}