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
    public class UsuarioServices : UsurInterface
    {
        public async Task<List<UserModel>> Get_user_list(string change, UserQuery parameter)
        {
            List<UserModel> list = new();

            using (SqlConnection connection = new(change))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new("[sp_consulta_user]", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@id_user", SqlDbType.VarChar, 100)).Value = parameter.id_persona;
                        command.Parameters.Add(new SqlParameter("@id_persona", SqlDbType.VarChar, 100)).Value = parameter.id_persona;
                        command.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 100)).Value = parameter.username;
                        command.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 100)).Value = parameter.password;
                        command.Parameters.Add(new SqlParameter("@cargo", SqlDbType.VarChar, 100)).Value = parameter.cargo;
                        command.Parameters.Add(new SqlParameter("@fech_creacion", SqlDbType.VarChar, 100)).Value = parameter.fech_creacion;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();
                        command.CommandTimeout = 0;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add(new UserModel()
                                {
                                    id_persona = reader["id_persona"].ToString().Trim(),
                                    id_user = reader["id_user"].ToString().Trim(),
                                    username = reader["username"].ToString().Trim(),
                                    password = reader["password"].ToString().Trim(),
                                    cargo = reader["cargo"].ToString().Trim(),
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
        public async Task<Response> Post_usuario(string change, UserModel parameter)
        {
            Response res = new();

            using (SqlConnection connection = new(change))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new("[sp_ingresar_actualizar_usuario]", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@id_user", SqlDbType.VarChar, 100)).Value = parameter.id_persona;
                        command.Parameters.Add(new SqlParameter("@id_persona", SqlDbType.VarChar, 100)).Value = parameter.id_persona;
                        command.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 100)).Value = parameter.username;
                        command.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 100)).Value = parameter.password;
                        command.Parameters.Add(new SqlParameter("@cargo", SqlDbType.VarChar, 100)).Value = parameter.cargo;
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
                finally
                {
                    connection.Close();
                }
            }
            return res;
        }
    }
}
