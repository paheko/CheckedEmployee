using DAO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PuntoDeVenta.DAO;
using PuntoDeVenta.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace punto_venta
{
    public partial class resultado_por_rango_form : Form
    {
        List<chequeo> ChequeoGlobal = new List<chequeo>();
        public resultado_por_rango_form()
        {
            InitializeComponent();
        }
        int posicion = 0;
        private void filtrar_Button_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("Debe escoger una fecha correcta.", "Alerta",
        MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
            else
            {
                string fecha1 = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dateTimePicker1.Value));
                string fecha2 = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dateTimePicker2.Value));
                List<chequeo> chequeo = new DAOChequeo().GetChequeo(fecha1,fecha2);
                ChequeoGlobal = chequeo;
                string fechaActual = null;
                bool primaraVuelta = false;
               while(ChequeoGlobal.Count>0)
               {
                   chequeo entrada = new chequeo();
                   chequeo salida = new chequeo();
                   bool salidaEncontrada = false;
                   //Busco de la lista global la primera entrada
                   foreach(chequeo temp in ChequeoGlobal)
                   {
                       //Verifico fecha actual 
                       if (!primaraVuelta)
                       {
                           fechaActual = temp.dia;
                           actualizarDGVfecha(fechaActual);
                       }
                       else 
                       {
                           if (FechaDiferente(fechaActual, temp.dia)) 
                           {
                               fechaActual = temp.dia;
                               actualizarDGVfecha(fechaActual);
                           }
                       }
                       if(temp.id_tipo_tiempo==new DAOTipo_tiempo().GetTipo_tiempo("ENTRADA").id_tipo_tiempo)
                       {
                           entrada = temp;
                           break;
                       }
                   }
                   foreach (chequeo temp in ChequeoGlobal)
                   {
                       //Verifico fecha actual 

                       if (temp.id_tipo_tiempo == new DAOTipo_tiempo().GetTipo_tiempo("SALIDA").id_tipo_tiempo && entrada.id_usuario==temp.id_usuario)
                       {
                           salida = temp;
                           salidaEncontrada = true;
                           break;
                       }
                   }
                   if (salidaEncontrada)
                   {
                       //borro los objetos de la lista.
                       ChequeoGlobal.Remove(entrada);
                       ChequeoGlobal.Remove(salida);
                       actualizarDGVUsuario(new DAOUsuarios().GetUser(entrada.id_usuario).usuario,entrada.hora,salida.hora);
                   }
                   else 
                   {
                       ChequeoGlobal.Remove(entrada);
                       actualizarDGVUsuario(new DAOUsuarios().GetUser(entrada.id_usuario).usuario, entrada.hora);
                   }

                   primaraVuelta = true;

               }


            }
        }
        public bool FechaDiferente(string fechaActual, string fechaNueva) 
        {
            bool diferente = false;
            if(!fechaActual.Equals(fechaNueva))
            {
                diferente = true;
            }
            return diferente;
        }
        public string ObtenerHoraSalida(int id_usuario,string dia) 
        {
            string salida=null;
            int c=0;
            foreach(chequeo temp in ChequeoGlobal)
            {

                if(temp.id_usuario==id_usuario && new DAOTipo_tiempo().GetTipo_tiempo("SALIDA").id_tipo_tiempo==temp.id_tipo_tiempo && dia.Equals(temp.dia))
                {
                    salida = temp.hora;
                    posicion = c;
                    break;
                }
                c++;
            }
            return salida;
        }
        private void clearTable()
        {
           
            while (dataGridView_Clientes.Rows.Count != 1)
            {
                dataGridView_Clientes.Rows.RemoveAt(0);
            }

        }
        private void actualizarDGV()
        {
            clearTable();
            dataGridView_Clientes.Rows.Add();
        }
        private void actualizarDGVfecha(string fecha)
        {            
            dataGridView_Clientes.Rows.Add(fecha," "," "," "," ");
        }
        private void actualizarDGVUsuario(string usuario,string entrada,string salida)
        {
            DateTime StartTime = DateTime.Parse(entrada);
            DateTime EndTime = DateTime.Parse(salida);
            TimeSpan Span = EndTime.Subtract(StartTime);
            dataGridView_Clientes.Rows.Add(" ", usuario,entrada,salida,Span.Minutes);
        }
        private void actualizarDGVUsuario(string usuario, string entrada)
        {
           
            dataGridView_Clientes.Rows.Add(" ", usuario, entrada, "--","--");
        }
        private void crear_pdf_button_Click(object sender, EventArgs e)
        {
            string fecha = string.Format("{0:yyyy-MM-dd HH-mm-ss-fff}", Convert.ToDateTime(DateTime.Now));
            //Realizo PDF
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 20, 20, 42, 35);
            string pathString2 = @"c:\PDF Generados";
            //Verifico si exite la carpeta PDF Generados
            if (!System.IO.File.Exists(pathString2))
            {
                System.IO.Directory.CreateDirectory(pathString2);
                PdfWriter write = PdfWriter.GetInstance(doc, new FileStream("c:\\PDF Generados\\Resultados " + fecha + ".pdf", FileMode.Create));
            }
            else
            {
                PdfWriter write = PdfWriter.GetInstance(doc, new FileStream("c:\\PDF Generados\\Resultados " + fecha + ".pdf", FileMode.Create));
            }
            doc.Open();
            string rutaimg = Path.Combine(Application.StartupPath, "Resources\\logo.png");
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance(rutaimg);
            PNG.ScalePercent(25f);
            doc.Add(PNG);
            Paragraph paragraph = new Paragraph(20, "RESULTADOS DE ENTRADAS Y SALIDAS ");
            doc.Add(paragraph);
            Paragraph paragraph2 = new Paragraph(5, " ");
            doc.Add(paragraph2);
            Paragraph paragraph3 = new Paragraph(20, "REPORTE DEL DIA " + string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dateTimePicker1.Value)) + " A " + string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dateTimePicker2.Value)));
            doc.Add(paragraph3);
            Paragraph paragraph4 = new Paragraph(5, " ");
            doc.Add(paragraph4);
            PdfPTable table = new PdfPTable(dataGridView_Clientes.Columns.Count);
            for (int j = 0; j < dataGridView_Clientes.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView_Clientes.Columns[j].HeaderText));
            }

            table.HeaderRows = 1;
            for (int i = 0; i < dataGridView_Clientes.Rows.Count; i++)
            {
                for (int k = 0; k < dataGridView_Clientes.Columns.Count; k++)
                {
                    if (dataGridView_Clientes[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView_Clientes[k, i].Value.ToString()));
                    }
                }
            }
            doc.Add(table);
            doc.Close();
            System.Diagnostics.Process.Start("c:\\PDF Generados\\Resultados " + fecha + ".pdf");
        }
    }
}
