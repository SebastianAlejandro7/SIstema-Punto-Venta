using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_PuntoVenta.Presentacion
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_DashBoard());
            // REVISAR UNIDADES MEDIDAS, (guardar/crear)
            // Area despacho (crud)
            //Forms fuera de margen, (no visualizado) %Marcas, Unidad de medida, %subfamilia, %familia, %punto venta, %mesas, %area despacho
            //Subfamilia (no agrega producto)
            
        }
    }
}