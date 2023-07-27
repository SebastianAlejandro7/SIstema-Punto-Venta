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
using Sol_PuntoVenta.Entidades;
using System.IO;
using System.Xml.Linq;

namespace Sol_PuntoVenta.Presentacion.Procesos
{
    public partial class Frm_Mesa_Abierta : Form
    {
        #region "Varibales y Propiedades"
        public int Codigo_pr1 { get => _Codigo_pr1; set => _Codigo_pr1 = value; }
        public string Descripcion_pr1 { get => _Descripcion_pr1; set => _Descripcion_pr1 = value; }
        public string Preciounitario_pr1 { get => _Preciounitario_pr1; set => _Preciounitario_pr1 = value; }
        public string Impresora1 { get => _Impresora1; set => _Impresora1 = value; }
        public Image Imagen_pr1 { get => _imagen_pr1; set => _imagen_pr1 = value; }
        public string Archivo_txt1 { get => _Archivo_txt1; set => _Archivo_txt1 = value; }

        DataTable TablaDetalle = new DataTable();
        private int _Codigo_pr1;
        private string _Descripcion_pr1;
        private string _Preciounitario_pr1;
        private string _Impresora1;
        private Image _imagen_pr1;
        private string _Archivo_txt1;
        #endregion
        #region "Metodo de llenado de los productos"
        private void LlenarListadoProductos(FlowLayoutPanel Contenedor)
        {
            Contenedor.Controls.Clear();
            int nCodigo_pv, nCodigo_sf;
            byte[] bImagen = new byte[0];
            DataTable Tabla1 = new DataTable();

            //int.TryParse(Lbl_codigo_pv.Text, out nCodigo_pv);
            //int.TryParse(Dgv_listado_sf.CurrentRow.Cells["codigo_sf"].Value.ToString(), out nCodigo_sf);

            nCodigo_pv = Convert.ToInt32(Lbl_codigo_pv.Text);
            nCodigo_sf = Convert.ToInt32(Dgv_listado_sf.CurrentRow.Cells["codigo_sf"].Value);

            Tabla1 = N_MesaAbierta.ListarProductos_SubFamilias_RP(nCodigo_pv, nCodigo_sf);
            if (Tabla1.Rows.Count>0)
            {
                for (int nFila = 0; nFila <= Tabla1.Rows.Count-1; nFila++)
                {
                    Codigo_pr1 = Convert.ToInt32(Tabla1.Rows[nFila][0]);
                    Descripcion_pr1 = Convert.ToString(Tabla1.Rows[nFila][1]);
                    Preciounitario_pr1 = Convert.ToString(Tabla1.Rows[nFila][2]);
                    bImagen = (byte[])Tabla1.Rows[nFila][3];
                    MemoryStream ms = new MemoryStream(bImagen);
                    Imagen_pr1 = Image.FromStream(ms);
                    Impresora1 = Convert.ToString(Tabla1.Rows[nFila][4]);
                    Archivo_txt1 = Lbl_archivo_txt.Text.Trim(); // recibe la informacion y ...
                    //Creamos el control producto para cargar en el Layout
                    Controles.MiProducto oProducto = new Controles.MiProducto();
                    oProducto.Descripcion_pr = Descripcion_pr1;
                    oProducto.Preciounitario_pr = Preciounitario_pr1;
                    oProducto.Imagen_pr = Imagen_pr1;
                    oProducto.Impresora = Impresora1.Trim();
                    oProducto.Archivo_txt = Archivo_txt1; //compratimos aca

                    //Añadimos el control producto al Layout
                    Contenedor.Controls.Add(oProducto);
                }
            }
        }

        private void Crear_TablaDetalle()
        {
            this.TablaDetalle = new DataTable("TablaDetalles");
            this.TablaDetalle.Columns.Add("Descripcion_pr", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Preciounitario_pr1", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Cantidad", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Total", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Obs", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Codigo_pr", System.Type.GetType("System.Int32"));
            this.TablaDetalle.Columns.Add("Impresora", System.Type.GetType("System.String"));

            Dgv_detalle.DataSource = this.TablaDetalle;
            Dgv_detalle.Columns[0].Width = 210;
            Dgv_detalle.Columns[0].HeaderText = "PRODUCTO";
            Dgv_detalle.Columns[1].Width = 75;
            Dgv_detalle.Columns[1].HeaderText = "P.UNIT.";
            Dgv_detalle.Columns[2].Width = 75;
            Dgv_detalle.Columns[2].HeaderText = "CANTIDAD.";
            Dgv_detalle.Columns[3].Width = 75;
            Dgv_detalle.Columns[3].HeaderText = "TOTAL S/.";
            Dgv_detalle.Columns[4].Width = 40;
            Dgv_detalle.Columns[4].HeaderText = "OBS.";
            Dgv_detalle.Columns[5].Visible = false;
            Dgv_detalle.Columns[6].Visible = false;
        }

        private void Agregar_item(string cDescripcion_pr, string cPreciounitario_pr, string cCantidad, string cTotal, string cObs, int nCodigo_pr, string cImpresora)
        {
            DataRow Fila = TablaDetalle.NewRow();
            Fila["Descripcion_pr"] = cDescripcion_pr;
            Fila["Preciounitario_pr1"] = cPreciounitario_pr;
            Fila["Cantidad"] = cCantidad;
            Fila["Total"] = cTotal;
            Fila["Obs"] = cObs;
            Fila["Codigo_pr"] = nCodigo_pr;
            Fila["Impresora"] = cImpresora;
            this.TablaDetalle.Rows.Add(Fila);
        }

        #endregion
        #region "Metodo para busqueda rapida de productos"
        private void Formato_busqueda_pr()
        {
            Dgv_1.Columns[0].Width = 250;
            Dgv_1.Columns[0].HeaderText = "PRODUCTO";
            Dgv_1.Columns[1].Width = 60;
            Dgv_1.Columns[1].HeaderText = "P.UNIT.";
            Dgv_1.Columns[2].Width = 250;
            Dgv_1.Columns[2].HeaderText = "SUBFAMILIA";
            Dgv_1.Columns[3].Visible = false;
            Dgv_1.Columns[4].Visible = false;
        }

        private void Busquedarapida_pr(string cTexto)
        {
            try
            {
                Dgv_1.DataSource = N_MesaAbierta.Busquedarapida_pr(cTexto);
                this.Formato_busqueda_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_dgv_busqueda_pr()
        {
            string bDescripcion_pr;
            string bPreciounitraio_pr;
            int bCodigo_pr;
            string bImpresora;

            bDescripcion_pr = Convert.ToString(Dgv_1.CurrentRow.Cells["descripcion_pr"].Value);
            bPreciounitraio_pr = Convert.ToString(Dgv_1.CurrentRow.Cells["precio_unitario"].Value);
            bCodigo_pr = Convert.ToInt32(Dgv_1.CurrentRow.Cells["codigo_pr"].Value);
            bImpresora = Convert.ToString(Dgv_1.CurrentRow.Cells["impresora"].Value);

            // Se agrega de manera automatica al dgv_1
            this.Agregar_item(bDescripcion_pr, bPreciounitraio_pr, "1.00", bPreciounitraio_pr, "", bCodigo_pr, bImpresora);

            TablaDetalle.AcceptChanges();
            const int nCoulmna = 3;
            decimal nSuma = 0;
            foreach (DataGridViewRow nRow in Dgv_detalle.Rows)
            {
                nSuma += Convert.ToDecimal(nRow.Cells[nCoulmna].Value);
            }
            Lbl_total.Text = Convert.ToString(nSuma);
        }

        #endregion
        public Frm_Mesa_Abierta()
        {
            InitializeComponent();
        }

        private void Dgv_listado_sf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.LlenarListadoProductos(Flp_listadoproductos);
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void Frm_Mesa_Abierta_Load(object sender, EventArgs e)
        {
            Tbc_principal.Controls["tabPage1"].Enabled = false;
            Tbc_principal.Controls["tabPage2"].Enabled = false;
            this.Crear_TablaDetalle();
        }

        private void Btn_nuevopedido_Click(object sender, EventArgs e)
        {
            Tbc_principal.Controls["tabPage1"].Enabled = true;
            Tbc_principal.Controls["tabPage2"].Enabled = false;
            Tbc_principal.SelectedIndex = 0;
            timer1.Enabled = true;
        }

        private void Btn_visualizarpedido_Click(object sender, EventArgs e)
        {
            Tbc_principal.Controls["tabPage1"].Enabled = false;
            Tbc_principal.Controls["tabPage2"].Enabled = true;
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_1_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "1";
        }

        private void Btn_2_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "2";
        }

        private void Btn_3_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "3";
        }

        private void Btn_4_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "4";
        }

        private void Btn_5_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "5";
        }

        private void Btn_6_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "6";
        }

        private void Btn_7_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "7";
        }

        private void Btn_8_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "8";
        }

        private void Btn_9_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "9";
        }

        private void Btn_0_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "0";
        }

        private void Btn_c_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Users\Public\Documents\" + Lbl_archivo_txt.Text.Trim() + ".txt") == true)
            {
                string xDescripcion_pr;
                string xPreciounitario_pr;
                string xCodigo_pr;
                string xImpresora;
                StreamReader Leer = new StreamReader(@"C:\Users\Public\Documents\" + Lbl_archivo_txt.Text.Trim() + ".txt");

                xDescripcion_pr = Leer.ReadLine();
                xPreciounitario_pr = Leer.ReadLine();
                xCodigo_pr = Leer.ReadLine();
                xImpresora = Leer.ReadLine();
                Leer.Close();
                File.Delete(@"C:\Users\Public\Documents\" + Lbl_archivo_txt.Text.Trim() + ".txt");
                this.Agregar_item(xDescripcion_pr.Substring(15, xDescripcion_pr.Length - 15),
                    xPreciounitario_pr.Substring(18, xPreciounitario_pr.Length - 18),
                    "1.00", 
                    xPreciounitario_pr.Substring(18, xPreciounitario_pr.Length - 18),
                    "", 
                    Convert.ToInt32(xCodigo_pr.Substring(10, xCodigo_pr.Length - 10)),
                    xImpresora.Substring(10, xImpresora.Length - 10));
                TablaDetalle.AcceptChanges();

                const int nCoulmna = 3;
                decimal nSuma = 0;
                foreach (DataGridViewRow nRow in Dgv_detalle.Rows)
                {
                    nSuma += Convert.ToDecimal(nRow.Cells[nCoulmna].Value);
                }
                Lbl_total.Text = Convert.ToString(nSuma);
            }
        }

        private void Btn_actualizar_prod_Click(object sender, EventArgs e)
        {
            if (Dgv_detalle.SelectedRows.Count>0 && Lbl_cantidad.Text.Length>0)
            {
                DataGridViewRow nFila = Dgv_detalle.CurrentRow;
                if (nFila  == null)
                {
                    return;
                }
                nFila.Cells["Cantidad"].Value = " " + Lbl_cantidad.Text + ".00";
                nFila.Cells["Total"].Value = Convert.ToString(Convert.ToDecimal(nFila.Cells["Preciounitario_pr1"].Value) * Convert.ToDecimal(Lbl_cantidad.Text));
                Lbl_cantidad.Text = "";
                TablaDetalle.AcceptChanges();

                const int nCoulmna = 3;
                decimal nSuma = 0;
                foreach (DataGridViewRow nRow in Dgv_detalle.Rows)
                {
                    nSuma += Convert.ToDecimal(nRow.Cells[nCoulmna].Value);
                }
                Lbl_total.Text = Convert.ToString(nSuma);
            }
        }

        private void Btn_quitarproducto_Click(object sender, EventArgs e)
        {
            if (Dgv_detalle.SelectedRows.Count>0)
            {
                Dgv_detalle.Rows.Remove(Dgv_detalle.CurrentRow);
                TablaDetalle.AcceptChanges();

                const int nCoulmna = 3;
                decimal nSuma = 0;
                foreach (DataGridViewRow nRow in Dgv_detalle.Rows)
                {
                    nSuma += Convert.ToDecimal(nRow.Cells[nCoulmna].Value);
                }
                Lbl_total.Text = Convert.ToString(nSuma);
            }
        }

        private void Dgv_detalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_detalle.SelectedRows.Count>0)
            {
                DataGridViewRow nFila2 = Dgv_detalle.CurrentRow;
                if (nFila2 == null)
                {
                    return;
                }
                Txt_observacion.Text = Convert.ToString(nFila2.Cells["Obs"].Value);
                Dgv_detalle.Enabled = false; // Bloque las siguientes filas para que no se pueda seleccionar/mover/desplazar otras filas.
                Pnl_observacion.Visible = true;
                Txt_observacion.Focus(); 
            }
        }

        private void Btn_retornar_obs_Click(object sender, EventArgs e)
        {
            if (Dgv_detalle.SelectedRows.Count>0)
            {
                DataGridViewRow nFila2 = Dgv_detalle.CurrentRow;
                if (nFila2 == null)
                {
                    return;
                }
                nFila2.Cells["Obs"].Value = Txt_observacion.Text.Trim();
                TablaDetalle.AcceptChanges();
                Pnl_observacion.Visible = false;
                Dgv_detalle.Enabled = true;
            }
        }

        private void Btn_busquedarapida_Click(object sender, EventArgs e)
        {
            Pnl_busqueda_pr.Visible = true;
        }

        private void Btn_retornar_pr_Click(object sender, EventArgs e)
        {
            Pnl_busqueda_pr.Visible = false;
        }

        private void Btn_buscar_pr_Click(object sender, EventArgs e)
        {
            this.Busquedarapida_pr(Txt_buscar_pr.Text.Trim());
        }

        private void Dgv_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pasar el producto seleccionado al detalle
            this.Selecciona_dgv_busqueda_pr();
            Pnl_busqueda_pr.Visible = false;
        }
    }
}
