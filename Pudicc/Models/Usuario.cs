using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pudicc.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Contrasena { get; set; }

        public Usuario Login(string usuario, string contrasena)
        {
            Usuario u=new Usuario();
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spLogin", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Usuario", usuario);
            command.Parameters.AddWithValue("@Contrasena", contrasena);
            SqlDataReader dr;
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                u.Id = dr.GetInt32(0);
                u.Nombre = dr.GetString(1);
            }
            dr.Close();
            conx.Close();
            return u;
        }
    }
}