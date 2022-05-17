using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace proyecto_final_DB1_0900_19_5983
{
    class conexion
    {
        
        public static SqlConnection ConectarDB()
        {
            //EN LA PARTE DE SERVER ES DONDE TIENE QUE AGREGAR EL SERVER QUE LE APARECE AL ENTRAR AL SQL SERVE
            SqlConnection nuevo = new SqlConnection("SERVER=LAPTOP-KNVL7684\\SQLEXPRESS;DATABASE=fase_2;Integrated security=true");
            nuevo.Open();
            return nuevo;
        }

        public static SqlConnection desconectarDB()
        {
            //EN LA PARTE DE SERVER ES DONDE TIENE QUE AGREGAR EL SERVER QUE LE APARECE AL ENTRAR AL SQL SERVE
            SqlConnection nuevo = new SqlConnection("SERVER=LAPTOP-KNVL7684\\SQLEXPRESS;DATABASE=fase_2;Integrated security=true");
            nuevo.Close();
            return nuevo;
        }


    }
}
