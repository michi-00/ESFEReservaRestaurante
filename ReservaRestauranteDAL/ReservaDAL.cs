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
    public class ReservaDAL
    {
        public static List<ReservaEN> MostrarReserva(ReservaEN reservaEN)
        {
            List<ReservaEN> _lista = new List<ReservaEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("MostrarReserva", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _lista.Add(new ReservaEN
                    {
                        Id = _reader.GetInt32(0),
                        Fecha = _reader.GetDateTime(1),
                        Hora = _reader.GetDateTime(2),
                        Estado = _reader.GetString(3),
                        NumeroPersonas = _reader.GetInt32(4),
                        Observacion = _reader.GetString(5)


                    });
                }
                _conn.Close();
            }
            return _lista;
        }
        public static int AgregarReserva(ReservaEN reservaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("GuardarReserva", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Fecha", reservaEN.Fecha));
                _comando.Parameters.Add(new SqlParameter("@Hora", reservaEN.Hora));
                _comando.Parameters.Add(new SqlParameter("@Estado", reservaEN.Estado));
                _comando.Parameters.Add(new SqlParameter("@NumeroPersonas", reservaEN.NumeroPersonas));
                _comando.Parameters.Add(new SqlParameter("@Observación", reservaEN.Observacion));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;

            }
        }
        public static int ModificarReserva(ReservaEN reservaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ModificarReserva", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", reservaEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Fecha", reservaEN.Fecha));
                _comando.Parameters.Add(new SqlParameter("@Hora", reservaEN.Hora));
                _comando.Parameters.Add(new SqlParameter("@Estado", reservaEN.Estado));
                _comando.Parameters.Add(new SqlParameter("@NumeroPersonas", reservaEN.NumeroPersonas));
                _comando.Parameters.Add(new SqlParameter("@Observación", reservaEN.Observacion));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }

        }
        public static int EliminarReserva(ReservaEN reservaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ModificarReserva", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", reservaEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;

            }
        }
    }
}
