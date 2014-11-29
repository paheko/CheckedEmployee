using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.DTO
{
    public class chequeo
    {
        public chequeo() { }
        public int id_usuario { set; get; }
        public int id_tipo_tiempo { set; get; }
        public string dia { set; get; }
        public string hora { set; get; }

        public chequeo(int id_usuario, int id_tipo_tiempo,string dia, string hora) 
        {
            this.id_usuario = id_usuario;
            this.id_tipo_tiempo = id_tipo_tiempo;
            this.dia = dia;
            this.hora = hora;
        }
    }
}
