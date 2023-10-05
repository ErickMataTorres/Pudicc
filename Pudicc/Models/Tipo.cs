using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pudicc.Models
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public static List<Tipo> ListaTipos()
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spListaTipos", conx);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            List<Tipo> lista = new List<Tipo>();
            Tipo c;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = new Tipo();
                c.Id = dr.GetInt32(0);
                c.Nombre = dr.GetString(1);
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
    }
}