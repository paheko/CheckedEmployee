using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Usuarios
    {
        public Usuarios()
        {
        }

        public int id_usuario { get; set; }
        public int id_tipo_usuario { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }
        public Usuarios(int id_usuario,int id_tipo_usuario, string usuario, string constrasenia) 
        {
            this.id_usuario = id_usuario;
            this.id_tipo_usuario = id_tipo_usuario;
            this.usuario = usuario;
            this.contrasenia = constrasenia;
        }
    }
}
