using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_PuntoVenta.Presentacion.Controles
{
    public partial class MiProducto : UserControl
    {
        #region "Mis Variables y Propiedades"
        public int Codigo_pr
        {
            get { return Convert.ToInt32(Lbl_codigo_pr.Text); }
            set { Lbl_codigo_pr.Text = Convert.ToString(value); }
        }

        public string Descripcion_pr
        {
            get { return Lbl_descripcion_pr.Text; }
            set { Lbl_descripcion_pr.Text = value; }
        }

        public string Preciounitario_pr
        {
            get { return Lbl_preciounitario_pr.Text; }
            set { Lbl_preciounitario_pr.Text = value; }
        }

        public string Impresora
        {
            get { return Lbl_impresora.Text; }
            set { Lbl_impresora.Text = value; }
        }

        public Image Imagen_pr
        {
            get { return Pct_imagen_pr.Image; }
            set { Pct_imagen_pr.Image = value; }
        }

        #endregion
        public MiProducto()
        {
            InitializeComponent();
        }
    }
}
