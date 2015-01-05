using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using DTO;
using iTextSharp;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PuntoDeVenta.DAO;
using PuntoDeVenta.DTO;

namespace punto_venta
{
    public partial class Usuarios_Form : Form
    {
        List<Usuarios> usuarios = new List<Usuarios>();
        Usuarios UsuarioGlobal = new Usuarios();
        Usuarios usuarioActual = new Usuarios();
        int idUserSelected = 0;
        public Usuarios_Form()
        {
            InitializeComponent();
            actualizarDGV();
            LlenarCombo();
            nombre_textbox.Focus();
        }
        public void LlenarCombo() 
        {
            List<dto_tipo_usuario> temp = new List<dto_tipo_usuario>();
            temp = new DAOTipo_usuario().GetTipo_Usuario();
           foreach(dto_tipo_usuario obj in temp)
           {
               privilegios_combo.Items.Add(obj.tipo_usuario);
           }
        }


        private void Usuarios_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView_Clientes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idUserSelected = (int)this.dataGridView_Clientes.Rows[e.RowIndex].Cells[0].Value;
            Agregar_usuarios_Button.Enabled = false;
            eliminar_button.Enabled = true;
            modificar_button1.Enabled = true;            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("¿Estás seguro de eliminar a este usuario?", "Alerta",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {
                    new DAOUsuarios().DeleteUsuario(idUserSelected);
                    
                        actualizarDGV();
                        
                        eliminar_button.Enabled = false;
                        modificar_button1.Enabled = true;
                        nombre_textbox.Text = null;
                        contrasena_textbox.Text = null;
                    
                }
                eliminar_button.Enabled = false;
                modificar_button1.Enabled = false;
                Agregar_usuarios_Button.Enabled = true;
            
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
         
           
        }
        public void RemarcarNombre() 
        {
            nombre_textbox.Focus();
            nombre_textbox.SelectionStart = 0;
            nombre_textbox.SelectionLength = nombre_textbox.Text.Length;
        }
        private void Agregar_Clientes_Button_Click(object sender, EventArgs e)
        {
            string nombre = nombre_textbox.Text,contrasenia=contrasena_textbox.Text, privilegio= privilegios_combo.Text;
            if (nombre.Equals("") || contrasenia.Equals("") || privilegio.Equals(""))
            {
                MessageBox.Show("Te está faltando datos por llenar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RemarcarNombre();
            }
            else if(nombre.Equals(' ')|| contrasenia.Equals(' ')|| privilegio.Equals(' '))
            {
                MessageBox.Show("Te está faltando datos por llenar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RemarcarNombre();
            }
            else if(new DAOUsuarios().GetUser(new Validaciones().LimpiarString(nombre_textbox.Text))!=null)
            {
                MessageBox.Show("El usuario ya existe.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RemarcarNombre();
            }
            else
            {

                Usuarios temp = new Usuarios();
                temp.usuario = new Validaciones().LimpiarString(nombre_textbox.Text);
                temp.contrasenia = contrasenia;
                temp.id_tipo_usuario = new DAOTipo_usuario().GetTipo_Usuario(new Validaciones().LimpiarString(privilegio)).id_tipo_usuario;
                
                new DAOUsuarios().InsertUser(temp);
                new DAOClave_scaner().AsignarClave(temp);
                List<dto_clave_scaner> lista = new DAOClave_scaner().Getclave_scaner();
                actualizarDGV();
                BorrarCajasTexto();
               
                
            }
        }


        public void BorrarCajasTexto() 
        {
            nombre_textbox.Text = null;
            contrasena_textbox.Text = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios user = new DAOUsuarios().GetUser(idUserSelected);
            nombre_textbox.Text = user.usuario;
            contrasena_textbox.Text = user.contrasenia;
            privilegios_combo.Text = new DAOTipo_usuario().GetTipo_Usuario(user.id_tipo_usuario).tipo_usuario;
                
            modificar_button1.Enabled = false;
            guardar_button.Enabled = true;
            eliminar_button.Enabled = false;
            Agregar_usuarios_Button.Enabled = false;

           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro que deseas modificar a este usuario?", "Alerta",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes) 
            {
                Usuarios user = new DAOUsuarios().GetUser(idUserSelected);

                user.usuario = nombre_textbox.Text;
                user.id_tipo_usuario = new DAOTipo_usuario().GetTipo_Usuario(privilegios_combo.Text).id_tipo_usuario;
                user.contrasenia = contrasena_textbox.Text;

                new DAOUsuarios().ModifyUser(user);
                actualizarDGV();
                guardar_button.Enabled = false;
                Agregar_usuarios_Button.Enabled = true;
                modificar_button1.Enabled = false;
                eliminar_button.Enabled = false;
                nombre_textbox.Text = null;
                contrasena_textbox.Text = null;
            }
        }

        private void pdf_button_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER,20,20,42,35);
            PdfWriter write = PdfWriter.GetInstance(doc, new FileStream("c:\\Codigos generados\\test.pdf", FileMode.Create));
            
            doc.Open();
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("logo.png");
            PNG.ScalePercent(25f);
            doc.Add(PNG);
            Paragraph paragraph = new Paragraph(10,"Lista de usuarios registrados en el sistema");
            doc.Add(paragraph);

            PdfPTable table = new PdfPTable(dataGridView_Clientes.Columns.Count);
            for (int j = 0; j < dataGridView_Clientes.Columns.Count;j++)
            {
                table.AddCell(new Phrase(dataGridView_Clientes.Columns[j].HeaderText));
            }

            table.HeaderRows = 1;
            for (int i = 0; i < dataGridView_Clientes.Rows.Count;i++ )
            {
                for (int k = 0; k < dataGridView_Clientes.Columns.Count;k++ )
                {
                    if(dataGridView_Clientes[k,i].Value!=null)
                    {
                        table.AddCell(new Phrase(dataGridView_Clientes[k,i].Value.ToString()));
                    }
                }
            }
            doc.Add(table);
            doc.Close();
            System.Diagnostics.Process.Start("c:\\Codigos generados\\test.pdf");

        }

        private void dataGridView_Clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void privilegios_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void actualizarDGV()
        {
            usuarios = new List<Usuarios>();
            clearTable();
            usuarios = new DAOUsuarios().GetUsers();
            dataGridView_Clientes.DataSource = null;
            foreach (Usuarios u in usuarios)
            {
                dataGridView_Clientes.Rows.Add(u.id_usuario,u.usuario,new DAOTipo_usuario().GetTipo_Usuario(u.id_tipo_usuario).tipo_usuario);
            }
            //dataGridView_Clientes.DataSource = usuarios.ToArray();
        }
        private void clearTable()
        {
            usuarios = new List<Usuarios>();
            dataGridView_Clientes.Rows.Clear();

        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            if (idUserSelected != 0)
            {
                Mostrar_codigo_form form = new Mostrar_codigo_form(new DAOUsuarios().GetUser(idUserSelected));
                form.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Debes seleccionar un usuario.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Marcar codigo o dar una solucion. 
            }
            eliminar_button.Enabled = false;
            modificar_button1.Enabled = true;
            nombre_textbox.Text = null;
            contrasena_textbox.Text = null;
            Agregar_usuarios_Button.Enabled = true;
        }
    }
}
