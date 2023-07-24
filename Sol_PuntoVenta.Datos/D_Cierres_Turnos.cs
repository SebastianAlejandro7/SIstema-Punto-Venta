using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sol_PuntoVenta.Entidades;
using System.Data.SqlClient;

namespace Sol_PuntoVenta.Datos
{
    public  class D_Cierres_Turnos
    {
        public string Abrir_turnos(string cFecha_ct, int nCodigo_pv, int nCodigo_tu) // Tipo formato cFecha_ct, si tiene el formato/pocisiones de fecha SQL lo convierte
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_abrir_turno", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@fFecha_ct", SqlDbType.Date).Value = cFecha_ct;
                Comando.Parameters.Add("@nCodigo_pv", SqlDbType.Int).Value = nCodigo_pv;
                Comando.Parameters.Add("@nCodigo_tu", SqlDbType.Int).Value = nCodigo_tu;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo abrir el turno";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Cerrar_turnos(string cFecha_ct, int nCodigo_pv, int nCodigo_tu) // Tipo formato cFecha_ct, si tiene el formato/pocisiones de fecha SQL lo convierte
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_cerrar_turno", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@fFecha_ct", SqlDbType.Date).Value = cFecha_ct;
                Comando.Parameters.Add("@nCodigo_pv", SqlDbType.Int).Value = nCodigo_pv;
                Comando.Parameters.Add("@nCodigo_tu", SqlDbType.Int).Value = nCodigo_tu;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo cerrar el turno";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public DataTable Listado_pv(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Listado_pv", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally // una vez llega a destino la informacion, se cierra sql
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public DataTable Estado_gestion_turno_pv(int nCodigo_pv)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_estado_gestion_turno_pv", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nCodigo_pv", SqlDbType.Int).Value = nCodigo_pv;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
