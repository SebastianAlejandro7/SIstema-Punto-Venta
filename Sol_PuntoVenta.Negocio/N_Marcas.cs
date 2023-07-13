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
    public class N_Marcas
    {
        public static DataTable Listado_ma(string cTexto)
        {
            D_Marcas Datos = new D_Marcas(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Listado_ma(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }

        public static string Guardar_ma(int nOpcion, E_Marcas oPropiedad) // Confirma que la informacion se guardo. El metodo que definimos se comunica con D_Puntos_Ventas(guardar_pv)
        {
            D_Marcas Datos = new D_Marcas();
            return Datos.Guardar_ma(nOpcion, oPropiedad); //nOpcion si es para un registro o escenario de actualizacion
        }

        public static string Eliminar_ma(int Ncodigo)
        {
            D_Marcas Datos = new D_Marcas();
            return Datos.Eliminar_ma(Ncodigo);
        }
    }
}
