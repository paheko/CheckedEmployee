using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Xml;


namespace DAO
{
    public class DAOUsuarios
    {
        
        public Usuarios GetUser(string nombre, string pass)
        {
            Usuarios usuario = new Usuarios();

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM usuario WHERE usuario='" + nombre + "' && contrasenia='"+pass+"';";
            SqlCeDataReader rd = cmd.ExecuteReader();
            usuario.id_usuario = rd.GetInt16(0);
            usuario.id_tipo_usuario = rd.GetInt16(1);
            usuario.usuario = rd.GetString(2);
            usuario.contrasenia = rd.GetString(3);
            
            
            return usuario;
        }

        public Usuarios GetUser(int id)
        {
            Usuarios usuario = null;

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM usuario WHERE id_usuario=" + id +";";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new Usuarios(
                    int.Parse(reader["id_usuario"].ToString()),
                     int.Parse(reader["id_tipo_usuario"].ToString()),
                    reader["usuario"].ToString(),
                    reader["contrasenia"].ToString()
                    );
            }

            return usuario;
        }
        public Usuarios GetUser(string nombre)
        {
            Usuarios usuario = null;

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM usuario WHERE usuario='" + nombre + "';";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new Usuarios(
                    int.Parse(reader["id_usuario"].ToString()),
                     int.Parse(reader["id_tipo_usuario"].ToString()),
                    reader["usuario"].ToString(),
                    reader["contrasenia"].ToString()
                    );
            }

            return usuario;
        }
        public List<Usuarios> GetUsers()
        {
            List<Usuarios> usuarios = new List<Usuarios>();

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM usuario;";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuarios.Add(new Usuarios(
                   int.Parse(reader["id_usuario"].ToString()),
                     int.Parse(reader["id_tipo_usuario"].ToString()),
                    reader["usuario"].ToString(),
                    reader["contrasenia"].ToString()
                    ));
            }

            return usuarios;
        }

        public void ModifyUser(Usuarios usuario)
        {
            SqlCeConnection conn = null;
            try
            {
                conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
                conn.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE usuario SET id_tipo_usuario="+ usuario.id_tipo_usuario + ",usuario='" + usuario.usuario + "',contrasenia='" + usuario.contrasenia + "' WHERE id_usuario="+usuario.id_usuario;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }

        public void InsertUser(Usuarios usuario)
        {
            SqlCeConnection conn = null;
            try
            {
                conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
                conn.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO usuario ([id_tipo_usuario],[usuario],[contrasenia]) Values("+usuario.id_tipo_usuario+",'"+usuario.usuario+"','"+usuario.contrasenia+"')";

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
                        
        }

        public void DeleteUsuario(int id)
        {
            SqlCeConnection conn = null;
            try
            {
                conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
                conn.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM usuario WHERE id_usuario=" + id;

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
