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

        public string Fecha_trabajo
        {
            get { return Lbl_fecha_trabajo.Text; }
            set { Lbl_fecha_trabajo.Text = value; }
        }

        #endregion

        private void Pct_imagenmesa_Click(object sender, EventArgs e)
        {
            Procesos.Frm_Mesa_Abierta oFrm_mesaabierta = new Procesos.Frm_Mesa_Abierta();
            oFrm_mesaabierta.Lbl_codigo_me.Text = Convert.ToString(Codigo);
            oFrm_mesaabierta.Txt_mesaseleccionada.Text = Descripcion;
            oFrm_mesaabierta.Txt_puntodeventa.Text = Descripcion_pv;
            oFrm_mesaabierta.Lbl_codigo_pv.Text = Convert.ToString(Codigo_pv);
            oFrm_mesaabierta.Lbl_codigo_tu.Text = Convert.ToString(Codigo_tu);
            oFrm_mesaabierta.Lbl_archivo_txt.Text = Convert.ToString(DateTime.Now.Ticks); //638260061064767794.txt Asigna el valor de DateTime.Now.Ticks convertido a cadena al texto del control Lbl_archivo_txt.
            oFrm_mesaabierta.Lbl_fecha_trabajo.Text = Fecha_trabajo;
            oFrm_mesaabierta.Btn_nuevopedido.Focus();
            try
            {
                oFrm_mesaabierta.Dgv_listado_sf.DataSource = N_MesaAbierta.Listar_SubFamilias_RP(Codigo_pv);
                //Dando formato al Datagriedview de subfamilia
                oFrm_mesaabierta.Dgv_listado_sf.Columns[0].Width = 250;
                oFrm_mesaabierta.Dgv_listado_sf.Columns[0].HeaderText = "SUBFAMILIAS";
                oFrm_mesaabierta.Dgv_listado_sf.Columns[1].Visible = false;
                oFrm_mesaabierta.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
