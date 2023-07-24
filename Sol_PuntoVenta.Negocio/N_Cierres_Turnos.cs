using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Sol_PuntoVenta.Datos;
using Sol_PuntoVenta.Entidades;

namespace Sol_PuntoVenta.Negocio
{
    public class N_Cierres_Turnos
    {
        public static string Abrir_turnos(string cFecha_ct, int nCodigo_pv, int nCodigo_tu)
        {
            D_Cierres_Turnos Datos = new D_Cierres_Turnos();
            return Datos.Abrir_turnos(cFecha_ct, nCodigo_pv, nCodigo_tu);
        }
        public static string Cerrar_turnos(string cFecha_ct, int nCodigo_pv, int nCodigo_tu)
        {
            D_Cierres_Turnos Datos = new D_Cierres_Turnos();
            return Datos.Cerrar_turnos(cFecha_ct, nCodigo_pv, nCodigo_tu);
        }
        public static DataTable Listado_pv(string cTexto)
        {
            D_Cierres_Turnos Datos = new D_Cierres_Turnos(); // Instanciamos la capa de datos y cargamos a una variable
            return Datos.Listado_pv(cTexto); // Con esa variable se comunica directamente con Listado_pv de (Sol_PuntoVenta.Datos)
        }
        public static DataTable Estado_gestion_turno_pv(int nCodigo_pv)
        {
            D_Cierres_Turnos Datos = new D_Cierres_Turnos();
            return Datos.Estado_gestion_turno_pv(nCodigo_pv);
        }
    }
}
