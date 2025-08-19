using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ReservaRestauranteEN;

namespace ReservaRestauranteDAL
{
    public  class ClienteDAL
    {
        //Obtiene una lista de cliente desde la base de datos ejecutando el procedimiento almacenado MostrarCliente//
        public static List<ClienteEN> MostrarCliente(ClienteEN clienteEN)
        {
            List<ClienteEN> _lista = new List<ClienteEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("MostrarCliente", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.AddWithValue("@Id", clienteEN.Id);
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _lista.Add(new ClienteEN
                    {
                        Id = _reader.GetInt64(0),
                        Nombre = _reader.GetString(1),
                        Telefono = _reader.GetString(2),
                        Direccion = _reader.GetString(3)

                    });
                }
                _conn.Close();
            }
            return _lista;
        }

        //Agrega un nuevo cliente a la base de datos ejecutando el procedimiento almacenado GuardarCliente//
        public static int AgregarCliente(ClienteEN clienteEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("GuardarCliente", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Nombre", clienteEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Dirección", clienteEN.Direccion));
                _comando.Parameters.Add(new SqlParameter("@Teléfono", clienteEN.Telefono));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }

        //Modifica un cliente en la base de datos ejecutando el procedimiento almacenado ModificarCliente//
        public static int ModificarCliente(ClienteEN clienteEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ModificarCliente", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", clienteEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Nombre", clienteEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Dirección", clienteEN.Direccion));
                _comando.Parameters.Add(new SqlParameter("@Teléfono", clienteEN.Telefono));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }

        //Elimina un cliente en la base de datos ejecutando el procedimiento almacenado EliminarCliente//
        public static int EliminarCliente(ClienteEN clienteEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("EliminaCliente", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", clienteEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
    }
}
