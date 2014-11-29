using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.DAO
{
    public class Validaciones
    {
        private bool CheckValid(string text)
        {
            char[] cha = new char[text.Length];
            char b, e;
            b = text.ToCharArray()[0];
            e = text.ToCharArray()[text.Length - 1];
            if (e == ' ' || b == ' ')
                return true;
            else
                return false;
        }
        public string LimpiarString(string text) 
        {
            string procesador = text;
            //if (procesador.Length != 1)
           // {
                while (CheckValid(procesador))
                {
                    char b, e;
                    b = procesador.ToCharArray()[0];
                    e = procesador.ToCharArray()[procesador.Length - 1];
                    if (e == ' ')
                        procesador.Remove(procesador.Length - 1);

                    if (b == ' ')
                        procesador.Remove(0);
                }
            //}
            /*else 
            {
                procesador = null;
            }*/
           
            return procesador;
           
        }
       
    }
}
