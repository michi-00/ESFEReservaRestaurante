using ReservaRestauranteEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaRestauranteDAL
{
    public class EmpleadoDAL
    {
        public static List<EmpleadoEN> MostrarEmpleado(EmpleadoEN empleadoEN)
        {
            List<EmpleadoEN> _lista = new List<EmpleadoEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("MostrarEmpleado", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _lista.Add(new EmpleadoEN
                    {
                        Id = _reader.GetInt32(0),
                        Nombre = _reader.GetString(1),
                        Contraseña = _reader.GetString(2),
                        Direccion = _reader.GetString(3),
                        IdRol = _reader.GetInt32(4)
                    });
                }
                _conn.Close();
            }
            return _lista;
        }
        public static int AgregarEmpleado(EmpleadoEN empleadoEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("GuardarEmpleado", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Nombre", empleadoEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Contraseña", empleadoEN.Contraseña));
                _comando.Parameters.Add(new SqlParameter("@Dirección", empleadoEN.Direccion));
                _comando.Parameters.Add(new SqlParameter("@IdRol", empleadoEN.IdRol));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int ModificarEmpleado(EmpleadoEN empleadoEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ModificarEmpleado", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", empleadoEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Nombre", empleadoEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Contraseña", empleadoEN.Contraseña));
                _comando.Parameters.Add(new SqlParameter("@Dirección", empleadoEN.Direccion));
                _comando.Parameters.Add(new SqlParameter("@IdRol", empleadoEN.IdRol));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int EliminarEmpleado(EmpleadoEN empleadoEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ModificarEmpleado", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", empleadoEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }

        }
    }
}
