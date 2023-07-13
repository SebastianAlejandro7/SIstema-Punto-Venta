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
    public class N_SubFamilias
    {
        public static DataTable Listado_sf(string cTexto)
        {
            D_SubFamilias Datos = new D_SubFamilias(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Listado_sf(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }

        public static string Guardar_sf(int nOpcion, E_SubFamilias oPropiedad) // Confirma que la informacion se guardo. El metodo que definimos se comunica con D_Puntos_Ventas(guardar_pv)
        {
            D_SubFamilias Datos = new D_SubFamilias();
            return Datos.Guardar_sf(nOpcion, oPropiedad); //nOpcion si es para un registro o escenario de actualizacion
        }

        public static string Eliminar_sf(int Ncodigo)
        {
            D_SubFamilias Datos = new D_SubFamilias();
            return Datos.Eliminar_sf(Ncodigo);
        }
        public static DataTable Listado_fa(string cTexto)
        {
            D_SubFamilias Datos = new D_SubFamilias(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Listado_fa(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
    }
}
