using PuntoDeVenta.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.DAO
{
    public class DAOTipo_tiempo
    {
        public dto_tipo_tiempo GetTipo_tiempo(int id)
        {
            dto_tipo_tiempo usuario = null;

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM tipo_tiempo WHERE id_tipo_tiempo=" + id + ";";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new dto_tipo_tiempo(
                    int.Parse(reader["id_tipo_tiempo"].ToString()),
                    reader["tipo_tiempo"].ToString()
                    );
            }

            return usuario;
        }
        public dto_tipo_tiempo GetTipo_tiempo(string id)
        {
            dto_tipo_tiempo usuario = null;

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM tipo_tiempo WHERE tipo_tiempo='" + id + "';";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new dto_tipo_tiempo(
                    int.Parse(reader["id_tipo_tiempo"].ToString()),
                    reader["tipo_tiempo"].ToString()
                    );
            }

            return usuario;
        }
        public List<dto_tipo_tiempo> GetTipo_tiempo()
        {
            List<dto_tipo_tiempo> usuarios = new List<dto_tipo_tiempo>();

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM tipo_tiempo;";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuarios.Add(new dto_tipo_tiempo(
                    int.Parse(reader["id_tipo_tiempo"].ToString()),
                    reader["tipo_tiempo"].ToString()
                    ));
            }

            return usuarios;
        }
        public void InsertTipo_tiempo(dto_tipo_tiempo usuario)
        {
            SqlCeConnection conn = null;
            try
            {
                conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
                conn.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO tipo_tiempo ([tipo_tiempo]) Values('" + usuario.tipo_tiempo + "')";

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }
        public void DeleteTipo_tiempo(int id)
        {
            SqlCeConnection conn = null;
            try
            {
                conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
                conn.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM tipo_tiempo WHERE id_tipo_tiempo=" + id;

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
