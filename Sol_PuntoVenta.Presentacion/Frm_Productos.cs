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
using Sol_PuntoVenta.Entidades;
using Sol_PuntoVenta.Negocio;

namespace Sol_PuntoVenta.Presentacion
{
    public partial class Frm_Productos : Form
    {
        public Frm_Productos()
        {
            InitializeComponent();
        }

        #region "Mis variables"
        int nCodigo = 0;
        int nCodigo_ma = 0;
        int nCodigo_um = 0;
        int nCodigo_sf = 0;
        int nCodigo_ad = 0;
        int Estadoguarda = 0;
        DataTable Dtdetalle = new DataTable();
        #endregion

        #region "Mis metodos"
        private void Formato_pr()
        {
            Dgv_Listado.Columns[0].Width = 100;
            Dgv_Listado.Columns[0].HeaderText = "CODIGO_PR";
            Dgv_Listado.Columns[1].Width = 250;
            Dgv_Listado.Columns[1].HeaderText = "PRODUCTO";
            Dgv_Listado.Columns[2].Width = 150;
            Dgv_Listado.Columns[2].HeaderText = "MARCA";
            Dgv_Listado.Columns[3].Width = 100;
            Dgv_Listado.Columns[3].HeaderText = "MEDIDA";
            Dgv_Listado.Columns[4].Width = 150;
            Dgv_Listado.Columns[4].HeaderText = "SUBFAMILIA";
            Dgv_Listado.Columns[5].Width = 110;
            Dgv_Listado.Columns[5].HeaderText = "P.UNITARIO";
            Dgv_Listado.Columns[6].Width = 150;
            Dgv_Listado.Columns[6].HeaderText = "ÁREA DESPACHO";
            Dgv_Listado.Columns[7].Visible = false;
            Dgv_Listado.Columns[8].Visible = false;
            Dgv_Listado.Columns[9].Visible = false;
            Dgv_Listado.Columns[10].Visible = false;
            Dgv_Listado.Columns[11].Visible = false;
        }

        private void Formato_ma()
        {
            Dgv_1.Columns[0].Visible = false;
            Dgv_1.Columns[1].Width = 417;
            Dgv_1.Columns[1].HeaderText = "MARCA";
        }
        private void Formato_um()
        {
            Dgv_1.Columns[0].Visible = false;
            Dgv_1.Columns[1].Width = 417;
            Dgv_1.Columns[1].HeaderText = "MEDIDA";
        }
        private void Formato_sf()
        {
            Dgv_3.Columns[0].Visible = false;
            Dgv_3.Columns[1].Width = 250;
            Dgv_3.Columns[1].HeaderText = "SUBFAMILIA";
            Dgv_3.Columns[2].Width = 250;
            Dgv_3.Columns[2].HeaderText = "FAMILIA";
            Dgv_3.Columns[3].Visible = false;
        }

        private void Listado_pr(string cTexto)
        {
            try
            {
                Dgv_Listado.DataSource = N_Productos.Listado_pr(cTexto); // Mediacion del contenido
                this.Formato_pr();
                Lbl_totalregistros.Text = "Total registros: " + Convert.ToString(Dgv_Listado.Rows.Count); //Dgv contiene los registros, porque ya recibio la informacion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Listado_ma(string cTexto)
        {
            try
            {
                Dgv_1.DataSource = N_Productos.Listado_ma(cTexto); // Mediacion del contenido
                this.Formato_ma();
                //Lbl_totalregistros.Text = "Total registros: " + Convert.ToString(Dgv_Listado.Rows.Count); //Dgv contiene los registros, porque ya recibio la informacion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Listado_um(string cTexto)
        {
            try
            {
                Dgv_2.DataSource = N_Productos.Listado_um(cTexto); // Mediacion del contenido
                this.Formato_um();
                //Lbl_totalregistros.Text = "Total registros: " + Convert.ToString(Dgv_Listado.Rows.Count); //Dgv contiene los registros, porque ya recibio la informacion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Listado_sf(string cTexto)
        {
            try
            {
                Dgv_3.DataSource = N_Productos.Listado_sf(cTexto); // Mediacion del contenido
                this.Formato_sf();
                //Lbl_totalregistros.Text = "Total registros: " + Convert.ToString(Dgv_Listado.Rows.Count); //Dgv contiene los registros, porque ya recibio la informacion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void Limpia_Texto()
        {
            Txt_descipcion_pr.Text = "";
            Txt_descripcion_ma.Text = "";
            Txt_descripcion_um.Text = "";
            Txt_descripcion_sf.Text = "";
            Txt_precio_unitario.Text = "";
            Txt_descripcion_ad.Text = "";
            Txt_observacion.Text = "";
        }

        private void Estado_BotonesPrincipales(bool lEstado)
        {
            Btn_nuevo.Enabled = lEstado;
            Btn_actualizar.Enabled = lEstado;
            Btn_eliminar.Enabled = lEstado;
            Btn_reporte.Enabled = lEstado;
            Btn_salir.Enabled = lEstado;
        }

        private void Mostrar_img(int nCodigo_pr)
        {
            Byte[] bImagen = new byte[0]; // Recibe la imagen en byte
            bImagen = N_Productos.Mostrar_img(nCodigo_pr); // hacemos la peticion de capa de negocio
            MemoryStream ms = new MemoryStream(bImagen); // Convierte la imagen
            Pct_imagen.Image = System.Drawing.Bitmap.FromStream(ms); // Y la adapta al control de imagen
        }

        private void Create_Tabla_pv()
        {
            this.Dtdetalle = new DataTable("Detalle");
            this.Dtdetalle.Columns.Add("Descripcion_pv", System.Type.GetType("System.String"));
            this.Dtdetalle.Columns.Add("OK", System.Type.GetType("System.Boolean"));
            this.Dtdetalle.Columns.Add("Codigo_pv", System.Type.GetType("System.Int32"));

            Dgv_PuntoVentas.DataSource = this.Dtdetalle;

            Dgv_PuntoVentas.Columns[0].Width = 220;
            Dgv_PuntoVentas.Columns[0].HeaderText = "PUNTO DE VENTA";
            Dgv_PuntoVentas.Columns[0].ReadOnly = true;
            Dgv_PuntoVentas.Columns[1].Width = 40;
            Dgv_PuntoVentas.Columns[1].HeaderText = "OK";
            Dgv_PuntoVentas.Columns[1].ReadOnly = true;
            Dgv_PuntoVentas.Columns[1].Visible = false;
        }

        private void Agregar_pv(string Descripcion_pv, bool OK, int nCodigo_pv)
        {
            DataRow Fila = Dtdetalle.NewRow();
            Fila["Descripcion_pv"] = Descripcion_pv;
            Fila["OK"] = OK;
            Fila["Codigo_pv"] = nCodigo_pv;
        }

        private void Puntos_Ventas_OK(int nOpcion, int nCodigo_pr) // Relacionado al producto
        {
            try
            {
                DataTable Tablatemp = new DataTable();
                Tablatemp = N_Productos.Puntos_Ventas_OK(nOpcion, nCodigo_pr);
                Dtdetalle.Clear();
                for(int nFila=0; nFila <= Tablatemp.Rows.Count -1; nFila++) 
                {
                    this.Agregar_pv(Convert.ToString(Tablatemp.Rows[nFila][0]),
                        Convert.ToBoolean(Tablatemp.Rows[nFila][1]),
                        Convert.ToInt32(Tablatemp.Rows[nFila][2]));
                }
                Dgv_PuntoVentas.DataSource = Dtdetalle;

                if (nOpcion>=1)
                {
                    Dgv_PuntoVentas.Columns["OK"].ReadOnly = false;
                }
                else
                {
                    Dgv_PuntoVentas.Columns["OK"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Estado_Texto(bool lEstado) // Deja escribir o solo seleccionar en el textbox
        {
            Txt_descipcion_pr.ReadOnly = !lEstado;
            Txt_precio_unitario.ReadOnly = !lEstado;
            Txt_observacion_product.ReadOnly = !lEstado;
            //Btn_lupa_ma.Visible = lEstado;
        }

        private void Estado_BotonesProcesos(bool Lestado)
        {
            Btn_cancelar.Visible = Lestado;
            Btn_guardar.Visible = Lestado;
            Btn_retornar.Visible = !Lestado;
            Btn_lupa_ma.Visible = Lestado;
            Btn_lupa_um.Visible = Lestado;
            Btn_lupa_sf.Visible = Lestado;
        }

        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_Listado.CurrentRow.Cells["codigo_pr"].Value))) // Convierte a string para evaluarlo
            {
                MessageBox.Show("Selecciona un registro", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nCodigo = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_pr"].Value); // Convierte entero porque la variable es de tipo entero y se envia al sql si o si tipo entero
                Txt_descipcion_pr.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["descripcion_pr"].Value);
                Txt_descripcion_ma.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["descripcion_ma"].Value);
                Txt_descripcion_um.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["descripcion_um"].Value);
                Txt_descripcion_sf.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["descripcion_sf"].Value);
                Txt_precio_unitario.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["precio_unitario"].Value);
                Txt_descripcion_ad.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["descripcion_ad"].Value);
                Txt_observacion_product.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["observacion"].Value);

                this.nCodigo_ma = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_ma"].Value);
                this.nCodigo_um = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_um"].Value);
                this.nCodigo_sf = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_sf"].Value);
                this.nCodigo_ad = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_ad"].Value);
                this.Mostrar_img(this.nCodigo);
                this.Puntos_Ventas_OK(this.Estadoguarda, this.nCodigo);
            }
        }
        private void Selecciona_item_ma()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_1.CurrentRow.Cells["codigo_ma"].Value))) // Convierte a string para evaluarlo
            {
                MessageBox.Show("Selecciona un registro", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Txt_descripcion_ma.Text = Convert.ToString(Dgv_1.CurrentRow.Cells["descripcion_ma"].Value);
                this.nCodigo_ma = Convert.ToInt32(Dgv_1.CurrentRow.Cells["Codigo_ma"].Value);
            }
        }
        private void Selecciona_item_um()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_2.CurrentRow.Cells["codigo_um"].Value))) // Convierte a string para evaluarlo
            {
                MessageBox.Show("Selecciona un registro", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Txt_descripcion_um.Text = Convert.ToString(Dgv_2.CurrentRow.Cells["descripcion_um"].Value);
                this.nCodigo_um = Convert.ToInt32(Dgv_2.CurrentRow.Cells["Codigo_um"].Value);
            }
        }
        private void Selecciona_item_sf()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_3.CurrentRow.Cells["codigo_sf"].Value))) // Convierte a string para evaluarlo
            {
                MessageBox.Show("Selecciona un registro", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Txt_descripcion_sf.Text = Convert.ToString(Dgv_3.CurrentRow.Cells["descripcion_sf"].Value);
                this.nCodigo_um = Convert.ToInt32(Dgv_3.CurrentRow.Cells["Codigo_sf"].Value);
            }
        }

        #endregion

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            this.Listado_pr("%");
            this.Listado_ma("%");
            this.Listado_um("%");
            this.Listado_sf("%");
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            this.Estadoguarda = 1; // valor de 1 significa nuevo registro
            this.Estado_BotonesPrincipales(false);
            this.Estado_BotonesProcesos(true);
            this.Limpia_Texto();
            this.Estado_Texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_descipcion_pr.Focus();
            //Btn_lupa_ma.Focus();
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
                if (Txt_precio_unitario.Text == string.Empty || Txt_descripcion_sf.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos(*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string Rpta = "";
                    E_SubFamilias oPrpiedad = new E_SubFamilias();
                    oPrpiedad.Codigo_sf = this.nCodigo;
                    oPrpiedad.Descripcion_sf = Txt_precio_unitario.Text.Trim();
                    oPrpiedad.Codigo_fa = this.nCodigo_ma;
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
                        this.nCodigo_ma = 0;
                        this.Listado_pr("%");
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
                Btn_lupa_sf.Focus();
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
                    Rpta = N_SubFamilias.Eliminar_sf(this.nCodigo);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_ma("%");
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
            this.Listado_pr(Txt_buscar.Text.Trim());
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
            Pnl_Listado_1.Location = Btn_lupa_sf.Location;
            Pnl_Listado_1.Visible = true;
            Txt_buscar1.Focus();
        }

        private void Dgv_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_item_ma();
            Pnl_Listado_1.Visible = false;
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_1.Visible = false;
        }

        private void Btn_buscar1_Click(object sender, EventArgs e)
        {
            this.Listado_ma(Txt_buscar1.Text.Trim());
        }

        private void Btn_lupa_ma_Click(object sender, EventArgs e)
        {
            Pnl_Listado_1.Location = Btn_lupa_ma.Location;
            Pnl_Listado_1.Visible = true;
            Txt_buscar1.Focus();
        }

        private void Btn_lupa_um_Click(object sender, EventArgs e)
        {
            Pnl_Listado_2.Location = Btn_lupa_um.Location;
            Pnl_Listado_2.Visible = true;
            Txt_buscar1.Focus();
        }

        private void Btn_retornar2_Click(object sender, EventArgs e)
        {
            Pnl_Listado_2.Visible = false;
        }

        private void Btn_buscar2_Click(object sender, EventArgs e)
        {
            this.Listado_um(Txt_buscar2.Text.Trim());
        }

        private void Dgv_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_item_ma();
            Pnl_Listado_2.Visible = false;
        }

        private void Btn_retornar3_Click(object sender, EventArgs e)
        {
            Pnl_Listado_3.Visible = false;
        }

        private void Btn_buscar3_Click(object sender, EventArgs e)
        {
            this.Listado_sf(Txt_buscar3.Text.Trim());
        }

        private void Dgv_3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_item_sf();
            Pnl_Listado_3.Visible = false;
            Txt_precio_unitario.Focus();
        }

        private void Btn_lupa_sf_Click(object sender, EventArgs e)
        {
            Pnl_Listado_3.Location = Btn_lupa_ma.Location;
            Pnl_Listado_3.Visible = true;
            Txt_buscar3.Focus();
        }
    }
}
