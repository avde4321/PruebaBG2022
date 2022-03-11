using Prueba_BG.Interfaces;
using Prueba_BG.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_BG.Servicio
{
    public class PersonaService : PersonaInterface
    {
        public async Task<List<PersonaModel>> Get_person_list(string change, PersonaQuery parameter)
        {
            List<PersonaModel> list = new();

            using (SqlConnection connection = new(change))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new("[sp_consulta_personas]", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@id_persona", SqlDbType.VarChar, 100)).Value = parameter.id_persona;
                        command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 100)).Value = parameter.name;
                        command.Parameters.Add(new SqlParameter("@lastname", SqlDbType.VarChar, 100)).Value = parameter.lastname;
                        command.Parameters.Add(new SqlParameter("@phonenumber", SqlDbType.VarChar, 100)).Value = parameter.phonenumber;
                        command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 100)).Value = parameter.email;
                        command.Parameters.Add(new SqlParameter("@direction", SqlDbType.VarChar, 100)).Value = parameter.direction;
                        command.Parameters.Add(new SqlParameter("@fech_creacion", SqlDbType.VarChar, 100)).Value = parameter.fech_creacion;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();
                        command.CommandTimeout = 0;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add(new PersonaModel()
                                {
                                    id_persona = reader["id_persona"].ToString().Trim(),
                                    name = reader["nombre"].ToString().Trim(),
                                    lastname = reader["apellido"].ToString().Trim(),
                                    phonenumber = reader["telefono"].ToString().Trim(),
                                    email = reader["email"].ToString().Trim(),
                                    direction = reader["direction"].ToString().Trim(),
                                    fech_creacion = reader["fech_creacion"].ToString().Trim(),
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                finally
                {
                    connection.Close();
                }
            }

            return list;
        }
        public async Task<Response> Post_person(string change, PersonaModel parameter)
        {
            Response res = new();

            using (SqlConnection connection = new(change))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new("[sp_insertar_actualizar_persona]", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@id_persona", SqlDbType.VarChar, 100)).Value = parameter.id_persona;
                        command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 100)).Value = parameter.name;
                        command.Parameters.Add(new SqlParameter("@lastname", SqlDbType.VarChar, 100)).Value = parameter.lastname;
                        command.Parameters.Add(new SqlParameter("@phonenumber", SqlDbType.VarChar, 100)).Value = parameter.phonenumber;
                        command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 100)).Value = parameter.email;
                        command.Parameters.Add(new SqlParameter("@direction", SqlDbType.VarChar, 100)).Value = parameter.direction;
                        command.Parameters.Add(new SqlParameter("@fech_creacion", SqlDbType.VarChar, 100)).Value = parameter.fech_creacion;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();
                        command.CommandTimeout = 0;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                res = new Response()
                                {
                                    code = reader["cod_error"].ToString(),
                                    mensaje = reader["message"].ToString(),
                                    data = "SI incertor",
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return res;
        }
    }
}
