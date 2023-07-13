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
    public class N_Familias
    {
        public static DataTable Listado_fa(string cTexto)
        {
            D_Familias Datos = new D_Familias(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Listado_fa(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }

        public static string Guardar_fa(int nOpcion, E_Familias oPropiedad) // Confirma que la informacion se guardo. El metodo que definimos se comunica con D_Puntos_Ventas(guardar_pv)
        {
            D_Familias Datos = new D_Familias();
            return Datos.Guardar_fa(nOpcion, oPropiedad); //nOpcion si es para un registro o escenario de actualizacion
        }

        public static string Eliminar_fa(int Ncodigo)
        {
            D_Familias Datos = new D_Familias();
            return Datos.Eliminar_fa(Ncodigo);
        }
    }
}
