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
    public class N_MesaAbierta
    {
        public static DataTable Listar_SubFamilias_RP(int nCodigo_pv)
        {
            D_MesaAbierta Datos = new D_MesaAbierta(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Listar_SubFamilias_RP(nCodigo_pv); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
        public static DataTable ListarProductos_SubFamilias_RP(int nCodigo_pv, int nCodigo_sf)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.ListarProductos_SubFamilias_RP(nCodigo_pv, nCodigo_sf);
        }
    }
}