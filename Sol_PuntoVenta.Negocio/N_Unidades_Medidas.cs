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
    public class N_Unidades_Medidas
    {
        public static DataTable Listado_um(string cTexto)
        {
            D_Unidades_Medidas Datos = new D_Unidades_Medidas(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Listado_um(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }

        public static string Guardar_um(int nOpcion, E_Unidades_Medidas oPropiedad) // Confirma que la informacion se guardo. El metodo que definimos se comunica con D_Puntos_Ventas(guardar_pv)
        {
            D_Unidades_Medidas Datos = new D_Unidades_Medidas();
            return Datos.Guardar_um(nOpcion, oPropiedad); //nOpcion si es para un registro o escenario de actualizacion
        }

        public static string Eliminar_um(int Ncodigo)
        {
            D_Unidades_Medidas Datos = new D_Unidades_Medidas();
            return Datos.Eliminar_um(Ncodigo);
        }
    }
}
