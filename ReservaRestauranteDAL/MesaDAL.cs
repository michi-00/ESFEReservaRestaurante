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
    public class MesaDAL
    {
        public static List<MesaEN> MostrarMesa(MesaEN mesaEN)
        {
            List<MesaEN> _lista = new List<MesaEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("MostrarMesa", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _lista.Add(new MesaEN
                    {
                        Id = _reader.GetInt32(0),
                        Numero = _reader.GetInt32(1),
                        Capacidad = _reader.GetInt32(2),
                        Estado = _reader.GetString(3)
                    });
                }
                _conn.Close();
            }
            return _lista;


        }
        public static int AgregarMesa(MesaEN mesaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("GuardarMesa", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Numero", mesaEN.Numero));
                _comando.Parameters.Add(new SqlParameter("@Capacidad", mesaEN.Capacidad));
                _comando.Parameters.Add(new SqlParameter("@Estado", mesaEN.Estado));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int ModificarMesa(MesaEN mesaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ModificarMesa", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", mesaEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Numero", mesaEN.Numero));
                _comando.Parameters.Add(new SqlParameter("@Capacidad", mesaEN.Capacidad));
                _comando.Parameters.Add(new SqlParameter("@Estado", mesaEN.Estado));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int EliminarMesa(MesaEN mesaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("EliminarMesa", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", mesaEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
    }
}
