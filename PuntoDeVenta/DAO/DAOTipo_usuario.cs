using PuntoDeVenta.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.DAO
{
    public class DAOTipo_usuario
    {
        public dto_tipo_usuario GetTipo_Usuario(int id)
        {
            dto_tipo_usuario usuario = null;

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM tipo_usuario WHERE id_tipo_usuario=" + id + ";";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new dto_tipo_usuario(
                    int.Parse(reader["id_tipo_usuario"].ToString()),                     
                    reader["tipo_usuario"].ToString()
                    );
            }

            return usuario;
        }
        public dto_tipo_usuario GetTipo_Usuario(string nombre)
        {
            dto_tipo_usuario usuario = null;

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM tipo_usuario WHERE tipo_usuario='" + nombre + "';";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new dto_tipo_usuario(
                    int.Parse(reader["id_tipo_usuario"].ToString()),
                    reader["tipo_usuario"].ToString()
                    );
            }

            return usuario;
        }
        public List<dto_tipo_usuario> GetTipo_Usuario()
        {
            List<dto_tipo_usuario> usuarios = new List<dto_tipo_usuario>();

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM tipo_usuario;";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuarios.Add(new dto_tipo_usuario(
                    int.Parse(reader["id_tipo_usuario"].ToString()),
                    reader["tipo_usuario"].ToString()
                    ));
            }

            return usuarios;
        }
        public void ModifyTipo_usuario(dto_tipo_usuario usuario)
        {
            SqlCeConnection conn = null;
            try
            {
                conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
                conn.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE tipo_usuario SET tipo_usuario='" + usuario.id_tipo_usuario + "' WHERE id=" + usuario.id_tipo_usuario;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }
        public void InsertTipo_usuario(dto_tipo_usuario usuario)
        {
            SqlCeConnection conn = null;
            try
            {
                conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
                conn.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO tipo_usuario ([tipo_usuario]) Values('" + usuario.id_tipo_usuario + "')";

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }
        public void DeleteTipo_Usuario(int id)
        {
            SqlCeConnection conn = null;
            try
            {
                conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
                conn.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM tipo_usuario WHERE id_tipo_usuario=" + id;

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
