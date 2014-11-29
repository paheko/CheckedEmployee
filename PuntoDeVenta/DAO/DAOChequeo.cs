using PuntoDeVenta.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.DAO
{
    public class DAOChequeo
    {
        public chequeo GetChequeo(chequeo chequeo)
        {
            chequeo usuario = null;

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM chequeo WHERE id_usuario=" + chequeo.id_usuario + " AND dia='"+chequeo.dia+"' AND hora='"+chequeo.hora+";";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new chequeo(
                    int.Parse(reader["id_usuario"].ToString()),
                     int.Parse(reader["id_tipo_usuario"].ToString()),
                    reader["dia"].ToString(),
                    reader["hora"].ToString()
                    );
            }

            return usuario;
        }
        public List<chequeo> GetChequeo(string fecha1, string fecha2)
        {
            List<chequeo> usuarios = new List<chequeo>();

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM chequeo WHERE dia > '" + fecha1 + "' AND dia < '" + fecha2+"';";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuarios.Add(new chequeo(
                    int.Parse(reader["id_usuario"].ToString()),
                    int.Parse(reader["id_tipo_tiempo"].ToString()),
                    reader["dia"].ToString(),
                    reader["hora"].ToString()
                    ));
            }

            return usuarios;
        }
        public List<chequeo> GetChequeo()
        {
            List<chequeo> usuarios = new List<chequeo>();

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM chequeo;";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuarios.Add(new chequeo(
                    int.Parse(reader["id_usuario"].ToString()),
                    int.Parse(reader["id_tipo_tiempo"].ToString()),
                    reader["dia"].ToString(),
                    reader["hora"].ToString()
                    ));
            }

            return usuarios;
        }
        public List<chequeo> GetChequeo(string fecha)
        {
            List<chequeo> usuarios = new List<chequeo>();

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM chequeo WHERE dia='"+fecha+"';";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuarios.Add(new chequeo(
                    int.Parse(reader["id_usuario"].ToString()),
                    int.Parse(reader["id_tipo_tiempo"].ToString()),
                    reader["dia"].ToString(),
                    reader["hora"].ToString()
                    ));
            }

            return usuarios;
        }
        public List<chequeo> GetChequeo(int id_usuario, string fecha)
        {
            List<chequeo> usuarios = new List<chequeo>();

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM chequeo WHERE id_usuario="+id_usuario+"AND dia='"+fecha+"';";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuarios.Add(new chequeo(
                    int.Parse(reader["id_usuario"].ToString()),
                    int.Parse(reader["id_tipo_tiempo"].ToString()),
                    reader["dia"].ToString(),
                    reader["hora"].ToString()
                    ));
            }

            return usuarios;
        }
        public void InsertChequeo(chequeo chequeo)
        {
            SqlCeConnection conn = null;
            try
            {
                conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
                conn.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO chequeo ([id_usuario],[id_tipo_tiempo],[dia],[hora]) Values(" + chequeo.id_usuario + "," + chequeo.id_tipo_tiempo + ",'" + chequeo.dia + "','"+chequeo.hora+"')";

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
