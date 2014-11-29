using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.DTO
{
    public class dto_tipo_usuario
    {
        public int id_tipo_usuario { set; get; }
        public string tipo_usuario { set; get; }
        public dto_tipo_usuario() { }
        public dto_tipo_usuario(int id_tipo_usuario,string tipo_usuario) 
        {
            this.id_tipo_usuario = id_tipo_usuario;
            this.tipo_usuario = tipo_usuario;
        }
    }
}
