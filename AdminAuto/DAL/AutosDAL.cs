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
    internal class AutosDAL
    {
        conexionDAL conexion;

        public AutosDAL()
        {
            conexion = new conexionDAL();
        }

        public bool Agregar(AutosBLL autosBLL)
        {
            return conexion.ejecutarComandoSinRetorno("INSERT INTO Autos (Placa, Marca, Modelo, Número_Asientos, Año_Fabricación, ID_Oficina) VALUES ('"+autosBLL.Placa+"', '"+autosBLL.Marca+"', '"+autosBLL.Modelo+"', "+autosBLL.Num_asientos+", "+autosBLL.Anio+", "+autosBLL.Oficina+");");
        }
        public int Eliminar(AutosBLL autosBLL)
        {

            conexion.ejecutarComandoSinRetorno("DELETE FROM Autos WHERE ID_Auto = "+autosBLL.ID);
            return 1;
        }

        public int Modificar(AutosBLL autosBLL)
        {

            conexion.ejecutarComandoSinRetorno("UPDATE Autos SET Placa='"+autosBLL.Placa+"', Marca = '"+autosBLL.Marca+"' ,Modelo = '"+autosBLL.Modelo+ "' ,Número_Asientos = '"+autosBLL.Num_asientos+ "' ,Año_Fabricación = '"+autosBLL.Anio+"' WHERE ID_Auto = "+autosBLL.ID);
            return 1;
        }
        public DataSet MostrarAutos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT au.ID_Auto, au.Placa, au.Marca, au.Modelo, au.Número_Asientos, au.Año_Fabricación, ofi.Ciudad as Oficina, au.ID_Oficina FROM Autos au INNER JOIN Oficinas ofi ON au.ID_Oficina = ofi.ID_Oficina");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet BuscarAuto(string tipo, string valor)
        {
            SqlCommand sentencia = new SqlCommand("SELECT au.ID_Auto, au.Placa, au.Marca, au.Modelo, au.Número_Asientos, au.Año_Fabricación, ofi.Ciudad as Oficina, au.ID_Oficina FROM Autos au INNER JOIN Oficinas ofi ON au.ID_Oficina = ofi.ID_Oficina WHERE au."+tipo+" = '"+valor+"' ");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
