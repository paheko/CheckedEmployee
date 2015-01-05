using DAO;
using DTO;
using OrnelasInput;
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
    public partial class Contenedor : Form
    {
        public Usuarios usuario = null;
       
        public bool isEmpleado=false;
      
      

        public Contenedor()
        {
            InitializeComponent();

            frmUsuarios = new Usuarios_Form();
            frmUsuarios.Disposed += new EventHandler(frmUsuarios_Disposed);
            frmChequeo = new Chequeo_form();
            frmChequeo.Disposed += new EventHandler(frmChequeo_Disposed);

            frmImporExp = new Importar_Exportar_form();
            frmImporExp.Disposed += new EventHandler(frmImporExp_Disposed);
            frmResultadoRango = new resultado_por_rango_form();
            frmResultadoRango.Disposed += new EventHandler(frmResultadosRango_Disposed);
            
        }

        Usuarios_Form frmUsuarios = null;

        Importar_Exportar_form frmImporExp = null;
        Chequeo_form frmChequeo = null;
        resultado_por_rango_form frmResultadoRango = null;
        public bool isResultadoRango = false;
        public bool isUsuariosShow = false;
        public bool isChecarShow = false;
        public bool isLoginShow = false;
        public bool isPrinc = false;
       
        public bool isImpExpShow = false;
       

        private void Contenedor_Load(object sender, EventArgs e)
        {
            
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
       
        

       
        
       

        

     

        private void frmUsuarios_Disposed(object sender, EventArgs e)
        {
            isUsuariosShow = false;

            frmUsuarios = new Usuarios_Form();
            frmUsuarios.Disposed += new EventHandler(frmUsuarios_Disposed);
        }
        private void frmChequeo_Disposed(object sender, EventArgs e) 
        {
            isChecarShow = false;
            frmChequeo = new Chequeo_form();
            frmChequeo.Disposed += new EventHandler(frmChequeo_Disposed);
        }
        private void frmResultadosRango_Disposed(object sender, EventArgs e) 
        {
            isResultadoRango = false;
            frmResultadoRango = new resultado_por_rango_form();
            frmResultadoRango.Disposed += new EventHandler(frmResultadosRango_Disposed);
        }
        
       

       
      

       

       

        

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cambiarDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login frmlog = new login();
            frmlog.Show();
            this.Dispose();
            
        }

       

       
       

       

        private void importarExportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (isImpExpShow)
            {
                frmImporExp.Focus();
            }
            else
            {
                
                    frmImporExp.MdiParent = this;
                    frmImporExp.Show();
                    isImpExpShow = true;
                             
            }
        }
        private void frmImporExp_Disposed(object sender, EventArgs e)
        {
            isImpExpShow = false;

            frmImporExp = new Importar_Exportar_form();
            frmImporExp.Disposed += new EventHandler(frmImporExp_Disposed);
        }


      

        private void Contenedor_Activated(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
       
        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         
            if (isUsuariosShow)
            {
                frmUsuarios.Focus();
            }
            else
            {

                frmUsuarios.MdiParent = this;
                frmUsuarios.Show();
                isUsuariosShow = true;

            }
        }

        private void checarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(isChecarShow)
            {
                frmChequeo.Focus();
            }
            else
            {
                frmChequeo.MdiParent = this;
                frmChequeo.Show();
                isChecarShow = true;
            }
        }

        private void Contenedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<dto_clave_scaner> usuarios = new List<dto_clave_scaner>();
            List<chequeo>chequeos = new DAOChequeo().GetChequeo(string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now)));
            if(chequeos.Count%2!=0)
            {
                MessageBox.Show("Hay usuarios que no hicieron la salida, el sistema realizará su chequeo con la hora actual.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                usuarios = UsuariosSinChecarSalida(chequeos);
                foreach(dto_clave_scaner tmp in usuarios)
                {
                    chequeo objeto = new chequeo();
                    objeto.id_usuario = tmp.id_usuario;
                    objeto.id_tipo_tiempo = new DAOTipo_tiempo().GetTipo_tiempo("SALIDA").id_tipo_tiempo;
                    objeto.dia = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now));
                    objeto.hora = string.Format("{0:HH:mm:ss}", Convert.ToDateTime(DateTime.Now));
                    new DAOChequeo().InsertChequeo(objeto);
                }
            }
        }
        public List<dto_clave_scaner> UsuariosSinChecarSalida(List<chequeo>lista) 
        {
            List<dto_clave_scaner> temp = new List<dto_clave_scaner>();
            foreach(chequeo obj in lista)
            {
                if (!SalidaCerrada(obj.id_usuario))
                    temp.Add(new DAOClave_scaner().Getclave_scaner(obj.id_usuario));
            }

            return temp;
        }
        public bool SalidaCerrada(int id_usuario) 
        {
            int salida = 0,entrada=0;
            bool cerrado=false;
            List<chequeo> chequeo = new DAOChequeo().GetChequeo(id_usuario, string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now)));
            foreach(chequeo obj in chequeo)
            {
                if (new DAOTipo_tiempo().GetTipo_tiempo(obj.id_tipo_tiempo).tipo_tiempo.Equals("ENTRADA"))
                {
                    entrada++;
                }
                else if (new DAOTipo_tiempo().GetTipo_tiempo(obj.id_tipo_tiempo).tipo_tiempo.Equals("SALIDA")) 
                {
                    salida++;
                }
            }
            if (entrada == salida)
            {
                cerrado = true;
            }
            else
                cerrado = false;
            return cerrado;
        }

        private void Contenedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*List<dto_clave_scaner> usuarios = new List<dto_clave_scaner>();
            List<chequeo> chequeos = new DAOChequeo().GetChequeo(string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now)));
            if (chequeos != null)
            {
                MessageBox.Show("Hay usuarios que no hicieron la salida, el sistema realizará su chequeo con la hora actual.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                usuarios = UsuariosSinChecarSalida(chequeos);
                foreach (dto_clave_scaner tmp in usuarios)
                {
                    chequeo objeto = new chequeo();
                    objeto.id_usuario = tmp.id_usuario;
                    objeto.id_tipo_tiempo = new DAOTipo_tiempo().GetTipo_tiempo("SALIDA").id_tipo_tiempo;
                    objeto.dia = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now));
                    objeto.hora = string.Format("{0:HH:mm:ss}", Convert.ToDateTime(DateTime.Now));
                    new DAOChequeo().InsertChequeo(objeto);
                }
            }*/
        }

        private void entradaYSalidaPorRangoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isResultadoRango)
            {
                frmResultadoRango.Focus();
            }
            else
            {
                frmResultadoRango.MdiParent = this;
                frmResultadoRango.Show();
                isResultadoRango = true;
            }
        }

        
    }
}
