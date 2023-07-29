using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sol_PuntoVenta.Datos;
using Sol_PuntoVenta.Entidades;


namespace Sol_PuntoVenta.Negocio
{
    public class N_Login
    {
        public static DataTable Acceder_us(string cLogin_us, string cPassword_us)
        {
            D_Login Datos = new D_Login();
            return Datos.Acceder_us(cLogin_us, cPassword_us);
        }
    }
}
