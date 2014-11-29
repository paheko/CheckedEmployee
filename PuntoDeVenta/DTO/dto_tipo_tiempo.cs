using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.DTO
{
    public class dto_tipo_tiempo
    {
        public int id_tipo_tiempo { set; get; }
        public string tipo_tiempo { set; get; }
        public dto_tipo_tiempo() { }

        public dto_tipo_tiempo(int id_tipo_tiempo, string tipo_tiempo) 
        {
            this.id_tipo_tiempo = id_tipo_tiempo;
            this.tipo_tiempo = tipo_tiempo;
        }
    }
}
