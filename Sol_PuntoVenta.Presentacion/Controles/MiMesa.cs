﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sol_PuntoVenta.Negocio;

namespace Sol_PuntoVenta.Presentacion.Controles
{
    public partial class MiMesa : UserControl
    {
        public MiMesa()
        {
            InitializeComponent();
        }
        #region "Mis Variables y Propiedades"
        public int Codigo
        {
            get { return Convert.ToInt32(Lbl_codigo_me.Text); }
            set { Lbl_codigo_me.Text = Convert.ToString(value); }
        }

        public string Descripcion
        {
            get { return Lbl_descripcion_me.Text; }
            set { Lbl_descripcion_me.Text = value; }
        }

        public Image Disponible
        {
            get { return Pct_estado.Image; }
            set { Pct_estado.Image = value; }
        }

        public int Codigo_pv
        {
            get { return Convert.ToInt32(Lbl_codigo_pv.Text); }
            set { Lbl_codigo_pv.Text = Convert.ToString(value); }
        }

        public string Descripcion_pv
        {
            get { return Lbl_descripcion_pv.Text; }
            set { Lbl_descripcion_pv.Text = value; }
        }

        public int Codigo_us
        {
            get { return Convert.ToInt32(Lbl_codigo_us.Text); }
            set { Lbl_codigo_us.Text = Convert.ToString(value); }
        }

        public int Codigo_tu
        {
            get { return Convert.ToInt32(Lbl_codigo_tu.Text); }
            set { Lbl_codigo_tu.Text = Convert.ToString(value); }
        }
        #endregion
    }
}
