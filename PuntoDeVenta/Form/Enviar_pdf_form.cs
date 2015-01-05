using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta.DAO;
using PuntoDeVenta.DTO;
using DTO;

namespace punto_venta
{
    public partial class enviar_pdf_form : Form
    {
        string rutaPDF = null;
      
       
        public enviar_pdf_form(string RutaPDF)
        {
            InitializeComponent();
            this.rutaPDF = RutaPDF;
          
          
        }

        private void enviar_button_Click(object sender, EventArgs e)
        {

            if (new DAOCorreo().IsValidEmail(correo_textbox.Text))
            {
                //new DAOCorreo().MandarCorreoPrueba();
                new DAOCorreo().CrearCorreoYMandar(this.rutaPDF,correo_textbox.Text);
            }
            else 
            {
                MessageBox.Show("Por favor ingrese un correo valido.");
            }
        }

        private void cliente_textBox_Leave(object sender, EventArgs e)
        {
            if (!new DAOCorreo().IsValidEmail(correo_textbox.Text)) 
            {
                MessageBox.Show("Por favor ingrese un correo valido.");
            }
        }
    }
}
