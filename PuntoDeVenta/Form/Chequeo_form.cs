using PuntoDeVenta.DAO;
using PuntoDeVenta.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace punto_venta
{
    public partial class Chequeo_form : Form
    {
        public Chequeo_form()
        {
            InitializeComponent();
            LlenarCombo();
        }
        public void LlenarCombo() 
        {
            List<dto_tipo_tiempo> tiempo = new List<dto_tipo_tiempo>();
            tiempo = new DAOTipo_tiempo().GetTipo_tiempo();
            foreach(dto_tipo_tiempo temp in tiempo)
            {
                privilegios_combo.Items.Add(temp.tipo_tiempo);
            }
        }
        private void nombre_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                if (!privilegios_combo.Text.Equals(null))
                {
                    if (privilegios_combo.Text.Equals("ENTRADA"))
                    {
                        if (!VerificarEntrada(new DAOClave_scaner().Getclave_scaner(new Validaciones().LimpiarString(codigo_textbox.Text)).id_usuario))
                        {
                            chequeo chequeo = new chequeo();
                            chequeo.id_usuario = new DAOClave_scaner().Getclave_scaner(new Validaciones().LimpiarString(codigo_textbox.Text)).id_usuario;
                            chequeo.dia = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now));
                            chequeo.hora = string.Format("{0:HH:mm:ss}", Convert.ToDateTime(DateTime.Now));
                            chequeo.id_tipo_tiempo = new DAOTipo_tiempo().GetTipo_tiempo(privilegios_combo.Text).id_tipo_tiempo;
                            new DAOChequeo().InsertChequeo(chequeo);
                            RemarcarCodigo();
                            codigo_textbox.Text = null;
                        }
                        else
                        {
                            MessageBox.Show("No puedes checar entrada, ya se había realizado. Debes checar salida.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RemarcarCodigo();
                        }
                    }
                    else if (privilegios_combo.Text.Equals("SALIDA"))
                    {
                        if (VerificarEntrada(new DAOClave_scaner().Getclave_scaner(new Validaciones().LimpiarString(codigo_textbox.Text)).id_usuario))
                        {
                            chequeo chequeo = new chequeo();
                            chequeo.id_usuario = new DAOClave_scaner().Getclave_scaner(new Validaciones().LimpiarString(codigo_textbox.Text)).id_usuario;
                            chequeo.dia = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now));
                            chequeo.hora = string.Format("{0:HH:mm:ss}", Convert.ToDateTime(DateTime.Now));
                            chequeo.id_tipo_tiempo = new DAOTipo_tiempo().GetTipo_tiempo(privilegios_combo.Text).id_tipo_tiempo;
                            new DAOChequeo().InsertChequeo(chequeo);

                            RemarcarCodigo();
                            codigo_textbox.Text = null;
                        }
                        else
                        {
                            MessageBox.Show("No puedes checar salida sin haber hecho la entrada.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RemarcarCodigo();
                        }
                    }
                    else if (!privilegios_combo.Text.Equals("ENTRADA") && !privilegios_combo.Text.Equals("SALIDA"))
                    {
                        MessageBox.Show("Por el momento no estan habilitados estas opciones.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RemarcarCodigo();
                        //Codigo a comentar
                        /*if (VerificarEntrada(new DAOClave_scaner().Getclave_scaner(new Validaciones().LimpiarString(new Crypting().DecryptKey(codigo_textbox.Text))).id_usuario))
                        {
                            chequeo chequeo = new chequeo();
                            chequeo.id_usuario = new DAOClave_scaner().Getclave_scaner(new Validaciones().LimpiarString(codigo_textbox.Text)).id_usuario;
                            chequeo.dia = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now));
                            chequeo.hora = string.Format("{0:HH:mm:ss}", Convert.ToDateTime(DateTime.Now));
                            chequeo.id_tipo_tiempo = new DAOTipo_tiempo().GetTipo_tiempo(privilegios_combo.Text).id_tipo_tiempo;
                         * codigo_textbox.Text = null;
                        }
                        else 
                        {
                            MessageBox.Show("Debes de checar entrada primero.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }*/
                    }
                }
                else 
                {
                    MessageBox.Show("Debes seleccionar primero un status.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RemarcarCodigo();
                }
               
            }
        }
        public bool VerificarEntrada(int id_usuario) 
        {
            bool entrada = false;
            List<chequeo> temp = new List<chequeo>();
            temp = new DAOChequeo().GetChequeo(id_usuario,string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now)));
            if(temp.Count==0)
            {
                entrada = false;
            }
            else
            {
                if (EntradaAbierta(temp))
                    entrada = true;
                else
                    entrada = false;
            }                
            
            return entrada;
        }
        public bool EntradaAbierta(List<chequeo>lista) 
        {
            int entrada = 0,salida=0;
            bool abierto = false;
            foreach(chequeo temp in lista)
            {
                if(new DAOTipo_tiempo().GetTipo_tiempo(temp.id_tipo_tiempo).tipo_tiempo.Equals("ENTRADA"))
                {
                    entrada++;
                }
                else if (new DAOTipo_tiempo().GetTipo_tiempo(temp.id_tipo_tiempo).tipo_tiempo.Equals("SALIDA"))
                {
                    salida++;
                }
            }
            if (entrada>salida)
                abierto = true;
            else
                abierto = false;

            return abierto;

        }
        public bool SalidaCerrada(List<chequeo> lista)
        {
            bool cerrada = false;
            if (EntradaAbierta(lista))
                cerrada = false;
            else
                cerrada = true;

            return cerrada;

        }
        private void codigo_textbox_Enter(object sender, EventArgs e)
        {
            RemarcarCodigo();
        }
        public void RemarcarCodigo() 
        {
            codigo_textbox.Focus();
            codigo_textbox.SelectionStart = 0;
            codigo_textbox.SelectionLength = codigo_textbox.Text.Length;
        }

        private void Agregar_usuarios_Button_Click(object sender, EventArgs e)
        {
         
                if (!privilegios_combo.Text.Equals(null))
                {
                    if (privilegios_combo.Text.Equals("ENTRADA"))
                    {
                        if (!VerificarEntrada(new DAOClave_scaner().Getclave_scaner(new Validaciones().LimpiarString(codigo_textbox.Text)).id_usuario))
                        {
                            chequeo chequeo = new chequeo();
                            chequeo.id_usuario = new DAOClave_scaner().Getclave_scaner(new Validaciones().LimpiarString(codigo_textbox.Text)).id_usuario;
                            chequeo.dia = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now));
                            chequeo.hora = string.Format("{0:HH:mm:ss}", Convert.ToDateTime(DateTime.Now));
                            chequeo.id_tipo_tiempo = new DAOTipo_tiempo().GetTipo_tiempo(privilegios_combo.Text).id_tipo_tiempo;
                            new DAOChequeo().InsertChequeo(chequeo);
                            RemarcarCodigo();
                            codigo_textbox.Text = null;
                        }
                        else
                        {
                            MessageBox.Show("No puedes checar entrada, ya se había realizado. Debes checar salida.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RemarcarCodigo();
                        }
                    }
                    else if (privilegios_combo.Text.Equals("SALIDA"))
                    {
                        if (VerificarEntrada(new DAOClave_scaner().Getclave_scaner(new Validaciones().LimpiarString(codigo_textbox.Text)).id_usuario))
                        {
                            chequeo chequeo = new chequeo();
                            chequeo.id_usuario = new DAOClave_scaner().Getclave_scaner(new Validaciones().LimpiarString(codigo_textbox.Text)).id_usuario;
                            chequeo.dia = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now));
                            chequeo.hora = string.Format("{0:HH:mm:ss}", Convert.ToDateTime(DateTime.Now));
                            chequeo.id_tipo_tiempo = new DAOTipo_tiempo().GetTipo_tiempo(privilegios_combo.Text).id_tipo_tiempo; 
                            new DAOChequeo().InsertChequeo(chequeo);
                            RemarcarCodigo();
                            codigo_textbox.Text = null;
                        }
                        else
                        {
                            MessageBox.Show("No puedes checar salida sin haber hecho la entrada.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RemarcarCodigo();
                        }
                    }
                    else if (!privilegios_combo.Text.Equals("ENTRADA") && !privilegios_combo.Text.Equals("SALIDA"))
                    {
                        MessageBox.Show("Por el momento no estan habilitados estas opciones.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RemarcarCodigo();
                        //Codigo a comentar
                        /*if (VerificarEntrada(new DAOClave_scaner().Getclave_scaner(new Validaciones().LimpiarString(new Crypting().DecryptKey(codigo_textbox.Text))).id_usuario))
                        {
                            chequeo chequeo = new chequeo();
                            chequeo.id_usuario = new DAOClave_scaner().Getclave_scaner(new Validaciones().LimpiarString(codigo_textbox.Text)).id_usuario;
                            chequeo.dia = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now));
                            chequeo.hora = string.Format("{0:HH:mm:ss}", Convert.ToDateTime(DateTime.Now));
                            chequeo.id_tipo_tiempo = new DAOTipo_tiempo().GetTipo_tiempo(privilegios_combo.Text).id_tipo_tiempo;
                            new DAOChequeo().InsertChequeo(chequeo);
                            codigo_textbox.Text = null;
                        }
                        else 
                        {
                            MessageBox.Show("Debes de checar entrada primero.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }*/
                    }
                }
                else
                {
                    MessageBox.Show("Debes seleccionar primero un status.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RemarcarCodigo();
                }

            
        }

        private void codigo_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            RemarcarCodigo();
        }
    }
}
