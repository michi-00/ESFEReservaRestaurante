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
    public class LugarDAL
    {
        public static List<LugarEN> MostrarLugar(LugarEN lugarEN)
        {
            List<LugarEN> _lista = new List<LugarEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("MostrarLugar", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _lista.Add(new LugarEN
                    {
                        Id = _reader.GetInt32(1),
                        Nombre = _reader.GetString(2),
                         Descripcion = _reader.GetString(3)
                    });
                }
                _conn.Close();

            }
            return _lista;


        }
        public static int AgregarLugar(LugarEN lugarEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("GuardarLugar", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Nombre", lugarEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Descripción", lugarEN.Descripcion));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;

            }
        }
        public static int ModificarLugar(LugarEN lugarEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ModificarLugar", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", lugarEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Nombre", lugarEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Descripción", lugarEN.Descripcion));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int EliminarLugar(LugarEN lugarEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("EliminarLugar", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", lugarEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
    }
}
