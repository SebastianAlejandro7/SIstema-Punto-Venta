using Sol_PuntoVenta.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sol_PuntoVenta.Entidades;
using Sol_PuntoVenta.Datos;

namespace Sol_PuntoVenta.Negocio
{
    public class N_Registro_Pedidos
    {
        public static DataTable Listado_pv(string cTexto)
        {
            D_Registro_Pedidos Datos = new D_Registro_Pedidos(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Listado_pv(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
        public static DataTable Estado_turno_pv(int nCodigo_pv)
        {
            D_Registro_Pedidos Datos = new D_Registro_Pedidos(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Estado_turno_pv(nCodigo_pv); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
        public static DataTable Mostrar_me_rp(int nCodigo_pv)
        {
            D_Registro_Pedidos Datos = new D_Registro_Pedidos(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Mostrar_me_rp(nCodigo_pv); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
    }
}
