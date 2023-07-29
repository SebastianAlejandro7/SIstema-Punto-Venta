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
        public static DataTable Busquedarapida_pr(string cTexto)
        {
            D_MesaAbierta Datos = new D_MesaAbierta(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Busquedarapida_pr(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
        public static DataTable Busqueda_cl(string cTexto)
        {
            D_MesaAbierta Datos = new D_MesaAbierta(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Busqueda_cl(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
        public static DataTable Guardar_RP(E_RegristroPedido oRP, DataTable Detalle_ticket)
        {
            D_MesaAbierta Datos = new D_MesaAbierta(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Guardar_RP(oRP, Detalle_ticket); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
        public static DataTable Imprimir_comanda(string cImpresora, int nCodigo_ti)
        {
            D_MesaAbierta Datos = new D_MesaAbierta(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Imprimir_comanda(cImpresora, nCodigo_ti); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
        public static DataTable Mostrar_Tickets_Mesa(int nCodigo_me)
        {
            D_MesaAbierta Datos = new D_MesaAbierta(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Mostrar_Tickets_Mesa(nCodigo_me); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
        public static DataTable Mostra_Ticket(int nCodigo_ti)
        {
            D_MesaAbierta Datos = new D_MesaAbierta(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Mostra_Ticket(nCodigo_ti); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
        public static DataTable Reimprimir_comanda(int nCodigo_ti)
        {
            D_MesaAbierta Datos = new D_MesaAbierta(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Reimprimir_comanda(nCodigo_ti); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
        public static DataTable Usuario_Admin(int nCodigo_us)
        {
            D_MesaAbierta Datos = new D_MesaAbierta(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Usuario_Admin(nCodigo_us); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
        public static string Eliminar_ti(int nCodigo_ti, int nCodigo_me, string cObsanulado_ti)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.Eliminar_ti(nCodigo_ti, nCodigo_me, cObsanulado_ti);
        }
    }
}