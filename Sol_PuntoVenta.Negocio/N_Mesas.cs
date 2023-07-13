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
    public class N_Mesas
    {
        public static DataTable Listado_me(string cTexto)
        {
            D_Mesas Datos = new D_Mesas(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Listado_me(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }

        public static string Guardar_me(int nOpcion, E_Mesas oPropiedad) // Confirma que la informacion se guardo. El metodo que definimos se comunica con D_Puntos_Ventas(guardar_pv)
        {
            D_Mesas Datos = new D_Mesas();
            return Datos.Guardar_me(nOpcion, oPropiedad); //nOpcion si es para un registro o escenario de actualizacion
        }

        public static string Eliminar_me(int Ncodigo)
        {
            D_Mesas Datos = new D_Mesas();
            return Datos.Eliminar_me(Ncodigo);
        }
        public static DataTable Listado_pv(string cTexto)
        {
            D_Mesas Datos = new D_Mesas(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Listado_pv(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
    }
}
