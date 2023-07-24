using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sol_PuntoVenta.Entidades;
using Sol_PuntoVenta.Negocio;

namespace Sol_PuntoVenta.Presentacion
{
    public partial class Frm_SubFamilias : Form
    {
        public Frm_SubFamilias()
        {
            InitializeComponent();
        }

        #region "Mis variables"
        int nCodigo = 0;
        int nCodigo_fa = 0;
        int Estadoguarda = 0;
        #endregion

        #region "Mis metodos"
        private void Formato_sf()
        {
            Dgv_Listado.Columns[0].Width = 100;
            Dgv_Listado.Columns[0].HeaderText = "CODIGO_SF";
            Dgv_Listado.Columns[1].Width = 417;
            Dgv_Listado.Columns[1].HeaderText = "SUBFAMILIA";
            Dgv_Listado.Columns[2].Width = 417;
            Dgv_Listado.Columns[2].HeaderText = "FAMILIA";
            Dgv_Listado.Columns[3].Visible = false;
        }

        private void Formato_fa()
        {
            Dgv_1.Columns[0].Visible = false;
            Dgv_1.Columns[1].Width = 417;
            Dgv_1.Columns[1].HeaderText = "FAMILIA";

        }

        private void Listado_sf(string cTexto)
        {
            try
            {
                Dgv_Listado.DataSource = N_SubFamilias.Listado_sf(cTexto); // Mediacion del contenido
                this.Formato_sf();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Listado_fa(string cTexto)
        {
            try
            {
                Dgv_1.DataSource = N_SubFamilias.Listado_fa(cTexto); // Mediacion del contenido
                this.Formato_fa();
                Lbl_totalregistros.Text = "Total registros: " + Convert.ToString(Dgv_Listado.Rows.Count); //Dgv contiene los registros, porque ya recibio la informacion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpia_Texto()
        {
            Txt_descripcion.Text = "";
            Txt_familia.Text = "";
        }

        private void Estado_BotonesPrincipales(bool lEstado)
        {
            Btn_nuevo.Enabled = lEstado;
            Btn_actualizar.Enabled = lEstado;
            Btn_eliminar.Enabled = lEstado;
            Btn_reporte.Enabled = lEstado;
            Btn_salir.Enabled = lEstado;
        }


        private void Estado_Texto(bool lEstado)
        {
            Txt_descripcion.ReadOnly = !lEstado;
        }

        private void Estado_BotonesProcesos(bool Lestado)
        {
            Btn_cancelar.Visible = Lestado;
            Btn_guardar.Visible = Lestado;
            Btn_retornar.Visible = !Lestado;
            Btn_lupa1.Visible = Lestado;
        }

        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_Listado.CurrentRow.Cells["codigo_sf"].Value))) // Convierte a string para evaluarlo
            {
                MessageBox.Show("Selecciona un registro", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nCodigo = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_sf"].Value); // Convierte entero porque la variable es de tipo entero y se envia al sql si o si tipo entero
                Txt_descripcion.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["descripcion_sf"].Value);
                Txt_familia.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["descripcion_fa"].Value);
                this.nCodigo_fa= Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_fa"].Value);
            }
        }
        private void Selecciona_item_fa()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_1.CurrentRow.Cells["codigo_fa"].Value))) // Convierte a string para evaluarlo
            {
                MessageBox.Show("Selecciona un registro", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Txt_familia.Text = Convert.ToString(Dgv_1.CurrentRow.Cells["descripcion_fa"].Value);
                this.nCodigo_fa = Convert.ToInt32(Dgv_1.CurrentRow.Cells["Codigo_fa"].Value);
            }
        }

        #endregion

        private void Frm_SubFamilias_Load(object sender, EventArgs e)
        {
            this.Listado_sf("%");
            this.Listado_fa("%");
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            this.Estadoguarda = 1; // valor de 1 significa nuevo registro
            this.Estado_BotonesPrincipales(false);
            this.Estado_BotonesProcesos(true);
            this.Limpia_Texto();
            this.Estado_Texto(true);
            Tbc_principal.SelectedIndex = 1;
            Btn_lupa1.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Limpia_Texto();
            this.Estado_Texto(false);
            this.Estado_BotonesPrincipales(true);
            this.Estado_BotonesProcesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_descripcion.Text == string.Empty || Txt_familia.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos(*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string Rpta = "";
                    E_SubFamilias oPrpiedad = new E_SubFamilias();
                    oPrpiedad.Codigo_sf = this.nCodigo;
                    oPrpiedad.Descripcion_sf = Txt_descripcion.Text.Trim();
                    oPrpiedad.Codigo_fa = this.nCodigo_fa;
                    Rpta = N_SubFamilias.Guardar_sf(this.Estadoguarda, oPrpiedad);
                    if (Rpta.Equals("OK"))
                    {
                        MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Limpia_Texto();
                        this.Estado_Texto(false);
                        this.Estado_BotonesPrincipales(true);
                        this.Estado_BotonesProcesos(false);
                        this.Estadoguarda = 0;
                        this.nCodigo = 0;
                        this.nCodigo_fa = 0;
                        this.Listado_sf("%");
                        Tbc_principal.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace); // stracktrace muestra en que parte sucedio el error!
            }
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count > 0)
            {
                this.Estadoguarda = 2; // Actualiza registro
                this.Estado_BotonesPrincipales(false);
                this.Estado_BotonesProcesos(true);
                this.Estado_Texto(true);
                this.Limpia_Texto();
                this.Selecciona_item();
                Tbc_principal.SelectedIndex = 1;
                Btn_lupa1.Focus();
            }
        }

        private void Dgv_Listado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Estadoguarda == 0)
            {
                this.Selecciona_item();
                this.Estado_BotonesProcesos(false);
                Tbc_principal.SelectedIndex = 1;
            }
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count > 0)
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Estas seguro de eliminar el registro seleccionado?", "Aviso del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Opcion == DialogResult.Yes)
                {
                    string Rpta = "";
                    this.Selecciona_item();
                    Rpta = N_SubFamilias.Eliminar_sf(this.nCodigo);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_fa("%");
                        MessageBox.Show("El registro ha sido elimindo", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.nCodigo = 0;
                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    this.Limpia_Texto();
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_sf(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count > 0)
            {
                Reportes.Frm_Rpt_SubFamilias oRpt_sf = new Reportes.Frm_Rpt_SubFamilias();
                oRpt_sf.Txt_p1.Text = Txt_buscar.Text.Trim();
                oRpt_sf.ShowDialog();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_1.Location = Btn_lupa1.Location;
            Pnl_Listado_1.Visible = true;
            Txt_buscar1.Focus();
        }

        private void Dgv_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_item_fa();
            Pnl_Listado_1.Visible = false;
            Txt_descripcion.Focus();
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_1.Visible=false;
        }

        private void Btn_buscar1_Click(object sender, EventArgs e)
        {
            this.Listado_fa(Txt_buscar1.Text.Trim());
        }
    }
}
