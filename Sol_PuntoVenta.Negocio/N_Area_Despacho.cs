using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Sol_PuntoVenta.Entidades;
using Sol_PuntoVenta.Datos;

namespace Sol_PuntoVenta.Negocio
{
    public class N_Area_Despacho
    {
        public static DataTable Listado_ad(string cTexto)
        {
            D_Area_Despacho Datos = new D_Area_Despacho(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Listado_ad(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }

        public static string Guardar_ad(int nOpcion, E_Area_Despacho oPropiedad) // Confirma que la informacion se guardo. El metodo que definimos se comunica con D_Puntos_Ventas(guardar_pv)
        {
            D_Area_Despacho Datos = new D_Area_Despacho();
            return Datos.Guardar_ad(nOpcion, oPropiedad); //nOpcion si es para un registro o escenario de actualizacion
        }

        public static string Eliminar_ad(int Ncodigo)
        {
            D_Area_Despacho Datos = new D_Area_Despacho();
            return Datos.Eliminar_ad(Ncodigo);
        }
    }
}
