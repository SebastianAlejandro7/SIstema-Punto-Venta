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
    public partial class Frm_Mesas : Form
    {
        public Frm_Mesas()
        {
            InitializeComponent();
        }

        #region "Mis variables"
        int nCodigo = 0;
        int nCodigo_pv = 0;
        int Estadoguarda = 0;
        #endregion

        #region "Mis metodos"
        private void Formato_me()
        {
            Dgv_Listado.Columns[0].Width = 100;
            Dgv_Listado.Columns[0].HeaderText = "CODIGO_ME";
            Dgv_Listado.Columns[1].Width = 417;
            Dgv_Listado.Columns[1].HeaderText = "MESAS";
            Dgv_Listado.Columns[2].Width = 417;
            Dgv_Listado.Columns[2].HeaderText = "PUNTO DE VENTA";
            Dgv_Listado.Columns[3].Visible = false;
        }

        private void Formato_pv()
        {
            Dgv_1.Columns[0].Visible = false;
            Dgv_1.Columns[1].Width = 417;
            Dgv_1.Columns[1].HeaderText = "PUNTO DE VENTA";

        }

        private void Listado_pv(string cTexto)
        {
            try
            {
                Dgv_Listado.DataSource = N_Mesas.Listado_pv(cTexto); // Mediacion del contenido
                this.Formato_pv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Listado_me(string cTexto)
        {
            try
            {
                Dgv_1.DataSource = N_Mesas.Listado_me(cTexto); // Mediacion del contenido
                this.Formato_me();
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
            Txt_punto_venta.Text = "";
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_Listado.CurrentRow.Cells["codigo_me"].Value))) // Convierte a string para evaluarlo
            {
                MessageBox.Show("Selecciona un registro", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nCodigo = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_me"].Value); // Convierte entero porque la variable es de tipo entero y se envia al sql si o si tipo entero
                Txt_descripcion.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["descripcion_me"].Value);
                Txt_punto_venta.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["descripcion_pv"].Value);
                this.nCodigo_pv = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_pv"].Value);
            }
        }
        private void Selecciona_item_pv()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_1.CurrentRow.Cells["codigo_pv"].Value))) // Convierte a string para evaluarlo
            {
                MessageBox.Show("Selecciona un registro", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Txt_punto_venta.Text = Convert.ToString(Dgv_1.CurrentRow.Cells["descripcion_pv"].Value);
                this.nCodigo_pv = Convert.ToInt32(Dgv_1.CurrentRow.Cells["Codigo_fa"].Value);
            }
        }

        #endregion

        private void Frm_Mesas_Load(object sender, EventArgs e)
        {
            this.Listado_me("%");
            this.Listado_pv("%");
        }

        //private void Btn_nuevo_Click(object sender, EventArgs e)
        //{
        //    this.Estadoguarda = 1; // valor de 1 significa nuevo registro
        //    this.Estado_BotonesPrincipales(false);
        //    this.Estado_BotonesProcesos(true);
        //    this.Limpia_Texto();
        //    this.Estado_Texto(true);
        //    Tbc_principal.SelectedIndex = 1;
        //    Btn_lupa1.Focus();
        //}

        //private void Btn_cancelar_Click(object sender, EventArgs e)
        //{
        //    this.Limpia_Texto();
        //    this.Estado_Texto(false);
        //    this.Estado_BotonesPrincipales(true);
        //    this.Estado_BotonesProcesos(false);
        //    Tbc_principal.SelectedIndex = 0;
        //}

        //private void Btn_retornar_Click(object sender, EventArgs e)
        //{
        //    Tbc_principal.SelectedIndex = 0;
        //}

        //private void Btn_guardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Txt_descripcion.Text == string.Empty || Txt_punto_venta.Text == string.Empty)
        //        {
        //            MessageBox.Show("Falta ingresar datos requeridos(*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }
        //        else
        //        {
        //            string Rpta = "";
        //            E_Mesas oPrpiedad = new E_Mesas();
        //            oPrpiedad.Codigo_me = this.nCodigo;
        //            oPrpiedad.Descripcion_me = Txt_descripcion.Text.Trim();
        //            oPrpiedad.Codigo_pv = this.nCodigo_pv;
        //            Rpta = N_Mesas.Guardar_me(this.Estadoguarda, oPrpiedad);
        //            if (Rpta.Equals("OK"))
        //            {
        //                MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                this.Limpia_Texto();
        //                this.Estado_Texto(false);
        //                this.Estado_BotonesPrincipales(true);
        //                this.Estado_BotonesProcesos(false);
        //                this.Estadoguarda = 0;
        //                this.nCodigo = 0;
        //                this.nCodigo_pv = 0;
        //                this.Listado_me("%");
        //                Tbc_principal.SelectedIndex = 0;
        //            }
        //            else
        //            {
        //                MessageBox.Show(Rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message + ex.StackTrace); // stracktrace muestra en que parte sucedio el error!
        //    }
        //}

        //private void Btn_actualizar_Click(object sender, EventArgs e)
        //{

        //}

        private void Dgv_Listado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Estadoguarda == 0)
            {
                this.Selecciona_item();
                this.Estado_BotonesProcesos(false);
                Tbc_principal.SelectedIndex = 1;
            }
        }
        ///
        private void Dgv_Listado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
                    Rpta = N_Mesas.Eliminar_me(this.nCodigo);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_me("%");
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
            this.Listado_me(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            //if (Dgv_Listado.Rows.Count > 0)
            //{
            //    Reportes.Frm_Rpt_SubFamilias oRpt_sf = new Reportes.Frm_Rpt_SubFamilias();
            //    oRpt_sf.Txt_p1.Text = Txt_buscar.Text.Trim();
            //    oRpt_sf.ShowDialog();
            //}
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        //private void Btn_salir_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_1.Location = Btn_lupa1.Location;
            Pnl_Listado_1.Visible = true;
            Txt_buscar1.Focus();
        }

        private void Dgv_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_item_pv();
            Pnl_Listado_1.Visible = false;
            Txt_descripcion.Focus();
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_1.Visible = false;
        }

        private void Btn_buscar1_Click(object sender, EventArgs e)
        {
            this.Listado_pv(Txt_buscar1.Text.Trim());
        }

        private void Btn_salir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_reporte_Click_1(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count > 0)
            {
                Reportes.Frm_Rpt_Area_Despacho oRpt_ad = new Reportes.Frm_Rpt_Area_Despacho();
                oRpt_ad.Txt_p1.Text = Txt_buscar.Text.Trim();
                oRpt_ad.ShowDialog();
            }
        }

        private void Btn_eliminar_Click_1(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count > 0)
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Estas seguro de eliminar el registro seleccionado?", "Aviso del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Opcion == DialogResult.Yes)
                {
                    string Rpta = "";
                    this.Selecciona_item();
                    Rpta = N_Mesas.Eliminar_me(this.nCodigo);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_me("%");
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

        private void Btn_nuevo_Click_1(object sender, EventArgs e)
        {
            this.Estadoguarda = 1; // valor de 1 significa nuevo registro
            this.Estado_BotonesPrincipales(false);
            this.Estado_BotonesProcesos(true);
            this.Limpia_Texto();
            this.Estado_Texto(true);
            Tbc_principal.SelectedIndex = 1;
            Btn_lupa1.Focus();
        }

        private void Btn_actualizar_Click_1(object sender, EventArgs e)
        {
                //this.Estadoguarda = 2; // Actualiza registro
                //this.Estado_BotonesPrincipales(false);
                //this.Estado_BotonesProcesos(true);
                //this.Estado_Texto(true);
                //this.Limpia_Texto();
                //this.Selecciona_item();
                //Tbc_principal.SelectedIndex = 1;
                //Txt_descripcion.Focus();
        }

        private void Btn_cancelar_Click_1(object sender, EventArgs e)
        {
            this.Limpia_Texto();
            this.Estado_Texto(false);
            this.Estado_BotonesPrincipales(true);
            this.Estado_BotonesProcesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_descripcion.Text == String.Empty ||
                    Txt_punto_venta.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos (*)",
                                    "Aviso del Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    string Rpta = "";
                    E_Mesas oPropiedad = new E_Mesas();
                    oPropiedad.Codigo_me = this.nCodigo;
                    oPropiedad.Descripcion_me = Txt_descripcion.Text.Trim();
                    oPropiedad.Codigo_pv = this.nCodigo_pv;
                    Rpta = N_Mesas.Guardar_me(this.Estadoguarda, oPropiedad);
                    if (Rpta.Equals("OK"))
                    {
                        MessageBox.Show("Los datos han sido guardados correctamente",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.Limpia_Texto();
                        this.Estado_Texto(false);
                        this.Estado_BotonesPrincipales(true);
                        this.Estado_BotonesProcesos(false);
                        this.Estadoguarda = 0;
                        this.nCodigo = 0;
                        this.nCodigo_pv = 0;
                        this.Listado_me("%");
                        Tbc_principal.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show(Rpta,
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
