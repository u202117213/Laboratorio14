using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AdminAuto.BLL;

namespace AdminAuto.DAL
{

    internal class OficinaDAL
    {

        conexionDAL conexion;

        public OficinaDAL()
        {
            conexion = new conexionDAL();
        }

        public DataSet MostrarOficinas()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Oficinas");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
