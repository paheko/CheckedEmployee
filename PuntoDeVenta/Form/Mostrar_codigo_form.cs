using DTO;
using punto_venta.DAO;
using PuntoDeVenta.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace punto_venta
{
    public partial class Mostrar_codigo_form : Form
    {
        Usuarios usuario_actual;
        public Mostrar_codigo_form(Usuarios usuario)
        {
            InitializeComponent();
            usuario_actual = usuario;
            label1.Text = usuario.usuario;
            label2.Text = new DAOTipo_usuario().GetTipo_Usuario(usuario.id_tipo_usuario).tipo_usuario;
            
            string contrasenia = new DAOClave_scaner().Getclave_scaner(usuario.id_usuario).contrasenia;
            label3.Text = contrasenia;
            textBox1.Text = contrasenia;
            Code39 code = new Code39(contrasenia);
            string pathString2 = @"c:\Codigos generados";
            string nombreArchivo = Convert.ToString(usuario_actual.usuario);
            if (!System.IO.File.Exists(pathString2))
            {
                System.IO.Directory.CreateDirectory(pathString2);
                //barcode.drawBarcode("c:\\Codigos generados" + "\\" + nombreArchivo + ".png");
                code.Paint().Save("c:\\Codigos generados" + "\\" + nombreArchivo + ".png", ImageFormat.Png);
                codigo_picture.ImageLocation = "c:\\Codigos generados" + "\\" + nombreArchivo + ".png";
                
            }
            else
            {
                //  barcode.drawBarcode("c:\\Codigos generados" + "\\" + nombreArchivo + ".png");
                code.Paint().Save("c:\\Codigos generados" + "\\" + nombreArchivo + ".png", ImageFormat.Png);
                codigo_picture.ImageLocation = "c:\\Codigos generados" + "\\" + nombreArchivo + ".png";
                
            }
        }

        private void guardar_Button_Click(object sender, EventArgs e)
        {
            if (guardarArchivo.ShowDialog() == DialogResult.OK)
            {
                codigo_picture.Image.Save(guardarArchivo.FileName);
            }
        }
    }
}
