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
    public class CobroDAL
    {
        public static List<CobroEN> MostrarCobro(CobroEN cobroEN)
        {
            List<CobroEN> _lista = new List<CobroEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("MostrarCobro", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;

                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _lista.Add(new CobroEN
                    {
                        Id = _reader.GetInt32(0),
                        Fecha = _reader.GetDateTime(1),
                        MetodoPago = _reader.GetString(2),
                        MontoTotal = _reader.GetDecimal(3),
                        IdReserva = _reader.GetInt32(4)


                    });

                }
                _conn.Close();
            }
            return _lista;
        }
        public static int AgregarCobro(CobroEN cobroEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("GuardarCobro", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Fecha", cobroEN.Fecha));
                _comando.Parameters.Add(new SqlParameter("@MetodoPago", cobroEN.MetodoPago));
                _comando.Parameters.Add(new SqlParameter("@MontoTotal", cobroEN.MontoTotal));
                _comando.Parameters.Add(new SqlParameter("@IdReserva", cobroEN.IdReserva));

                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int ModificarCobro(CobroEN cobroEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ModificarCobro", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", cobroEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Fecha", cobroEN.Fecha));
                _comando.Parameters.Add(new SqlParameter("@MetodoPago", cobroEN.MetodoPago));
                _comando.Parameters.Add(new SqlParameter("@MontoTotal", cobroEN.MontoTotal));
                _comando.Parameters.Add(new SqlParameter("@IdReserva", cobroEN.IdReserva));

                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int EliminarCobro(CobroEN cobroEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("EliminarCobro", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", cobroEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
    }
}
