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
    public class N_Punto_Venta
    {
        public static DataTable Listado_pv(string cTexto)
        {
            D_Punto_Venta Datos = new D_Punto_Venta(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Listado_pv(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }

        public static string Guardar_pv(int nOpcion, E_Punto_Ventas oPropiedad) // Confirma que la informacion se guardo. El metodo que definimos se comunica con D_Puntos_Ventas(guardar_pv)
        {
            D_Punto_Venta Datos = new D_Punto_Venta();
            return Datos.Guardar_pv(nOpcion, oPropiedad); //nOpcion si es para un registro o escenario de actualizacion
        }

        public static string Eliminar_pv(int Ncodigo)
        {
            D_Punto_Venta Datos = new D_Punto_Venta();
            return Datos.Eliminar_pv(Ncodigo);
        }
    }
}
