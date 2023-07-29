using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sol_PuntoVenta.Negocio;

namespace Sol_PuntoVenta.Presentacion
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        #region "Mis Metodos"
        private void Acceder_us(string cLogin_us, string cPassword_us)
        {
            try
            {
                DataTable TablaAcceder = new DataTable();
                TablaAcceder = N_Login.Acceder_us(cLogin_us, cPassword_us);
                if (TablaAcceder.Rows.Count>0) // Si tiene permiso para el uso del Sistema
                {
                    Frm_DashBoard oFrm_DB = new Frm_DashBoard();
                    oFrm_DB.pCodigo_us = Convert.ToInt32(TablaAcceder.Rows[0][0]);
                    oFrm_DB.pLogin_us = Convert.ToString(TablaAcceder.Rows[0][1]);
                    oFrm_DB.pNombres_us = Convert.ToString(TablaAcceder.Rows[0][2]);
                    oFrm_DB.pDescripcion_ca = Convert.ToString(TablaAcceder.Rows[0][3]);
                    oFrm_DB.pCodigo_ro = Convert.ToInt32(TablaAcceder.Rows[0][4]);
                    oFrm_DB.pDescripcion_ro = Convert.ToString(TablaAcceder.Rows[0][5]);
                    oFrm_DB.Show();
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña son incorrecto", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        private void Btn_acceder_Click(object sender, EventArgs e)
        {
            this.Acceder_us(Txt_login_us.Text.Trim(), Txt_Password_us.Text.Trim());
        }
    }
}
