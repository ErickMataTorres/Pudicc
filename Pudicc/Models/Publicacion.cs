using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pudicc.Models
{
    public class Publicacion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion{ get; set; }
        public string Imagen { get; set; }
        public int IdTipo { get; set; }
        public string NombreTipo { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public static List<Publicacion> CardsPublicacion(int idTipo)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spCardsPublicacion", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdTipo", idTipo);
            SqlDataReader dr;
            List<Publicacion> lista = new List<Publicacion>();
            Publicacion c;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = new Publicacion();
                c.Id = dr.GetInt32(0);
                c.Titulo = dr.GetString(1);
                c.Descripcion = dr.GetString(2);
                c.Imagen = dr.GetString(3);
                c.IdTipo = dr.GetInt32(4);
                c.NombreTipo = dr.GetString(5);
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        public string Guardar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarPublicacion", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Titulo", Titulo);
            command.Parameters.AddWithValue("@Descripcion", Descripcion);
            command.Parameters.AddWithValue("@Imagen", Imagen);
            command.Parameters.AddWithValue("@IdTipo", IdTipo);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch (Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
    }
}