using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace punto_venta
{
    public partial class login : Form
    {
        Usuarios user = new Usuarios();
        List<Usuarios> usuario = null;
       
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios datosUsuario = new Usuarios();
            usuario = new DAOUsuarios().GetUsers();
            string user = User.Text, pass=Contra.Text;
            bool bandera = false;
            foreach(Usuarios objeto in usuario)
            {
               /* if (user.Equals(objeto.Nombre) && pass.Equals(objeto.Contrasenia)) 
                {
                    bandera = true;
                    this.user = objeto;
                }*/
            }

            if (bandera)
            {
                /*Contenedor ventana = new Contenedor(this.user);
                this.Hide();
                ventana.Show();*/
                
            }
            else 
            {
                MessageBox.Show("Nombre de usuario o contraseña INCORRECTA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Contra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Usuarios datosUsuario = new Usuarios();
                usuario = new DAOUsuarios().GetUsers();
                string user = User.Text, pass = Contra.Text;
                bool bandera = false;
                foreach (Usuarios objeto in usuario)
                {
                    /*if (user.Equals(objeto.Nombre) && pass.Equals(objeto.Contrasenia))
                    {
                        bandera = true;
                        this.user = objeto;
                    }*/
                }

                if (bandera)
                {
                   /* Contenedor ventana = new Contenedor(this.user);
                    this.Hide();
                    ventana.Show();*/

                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña INCORRECTA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void User_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                Usuarios datosUsuario = new Usuarios();
                usuario = new DAOUsuarios().GetUsers();
                string user = User.Text, pass = Contra.Text;
                bool bandera = false;
                foreach (Usuarios objeto in usuario)
                {
                    /*if (user.Equals(objeto.Nombre) && pass.Equals(objeto.Contrasenia))
                    {
                        bandera = true;
                        this.user = objeto;
                    }*/
                }

                if (bandera)
                {
                    /*Contenedor ventana = new Contenedor(this.user);
                this.Hide();
                ventana.Show();*/

                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña INCORRECTA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void Contra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
