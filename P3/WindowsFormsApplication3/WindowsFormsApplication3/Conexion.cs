using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    namespace WindowsFormsApplication3
    {
        class Conexion
        {
            public static SqlConnection conexion()
            {
                string servidor = "localhost";
                string bd = "imagenes";
                string usuario = "usuario324";
                string password = "123456";

                string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id= " + usuario + "; Password=" + password + "";

                try
                {
                    SqlConnection conexionBD = new SqlConnection(cadenaConexion);
                    return conexionBD;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                    return null;
                }
            }
        }
    }
}
