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
    public class MenuDAL
    {
        public static List<MenuEN> MostrarMenú(MenuEN menúEN)
        {
            List<MenuEN> _lista = new List<MenuEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("MostrarMenú", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _lista.Add(new MenuEN
                    {
                        Id = _reader.GetInt32(0),
                        Nombre = _reader.GetString(1),
                        Descripcion = _reader.GetString(2),
                        Precio = _reader.GetDecimal(3)
                    });
                }
                _conn.Close();
            }
            return _lista;
        }

        public static int AgregarMenú(MenuEN menúEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("GuardarMenú", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Nombre", menúEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Descripción", menúEN.Descripcion));
                _comando.Parameters.Add(new SqlParameter("@Precio", menúEN.Precio));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;

            }

        }
        public static int ModificarMenú(MenuEN menúEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ModificarMenú", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", menúEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Nombre", menúEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Descripción", menúEN.Descripcion));
                _comando.Parameters.Add(new SqlParameter("@Precio", menúEN.Precio));

                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int EliminarMenú(MenuEN menúEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("EliminarMenú", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", menúEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
    }
}
