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
        
        DataTable TablaDetalle = new DataTable();
        private int _Codigo_pr1;
        private string _Descripcion_pr1;
        private string _Preciounitario_pr1;
        private string _Impresora1;
        private Image _imagen_pr1;
        #endregion
        #region "Metodo de llenado de los productos"
        private void LlenarListadoProductos(FlowLayoutPanel Contenedor)
        {
            Contenedor.Controls.Clear();
            int nCodigo_pv, nCodigo_sf;
            byte[] bImagen = new byte[0];
            DataTable Tabla1 = new DataTable();

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
                    //Creamos el control producto para cargar en el Layout
                    Controles.MiProducto oProducto = new Controles.MiProducto();
                    oProducto.Descripcion_pr = Descripcion_pr1;
                    oProducto.Preciounitario_pr = Preciounitario_pr1;
                    oProducto.Imagen_pr = Imagen_pr1;
                    oProducto.Impresora = Impresora1.Trim();

                    //Añadimos el control producto al Layout
                    Contenedor.Controls.Add(oProducto);
                }
            }
        }

        private void Crear_TablaDetalle()
        {
            this.TablaDetalle = new DataTable("TablaDetalles");
            this.TablaDetalle.Columns.Add("Descripcion_pr", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Preciounitrario_pr", System.Type.GetType("System.String"));
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
    }
}
