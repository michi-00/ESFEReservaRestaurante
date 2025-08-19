using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaRestauranteDAL
{
     class ComunBD
     {
        public enum TipoBD 
        {
            SqlServer, Oracle, BD2
        }
        /// <Sumary>
        /// Cadena de conexión para SQL Server.
        /// Ajusta esta cadena según tu servidor y base de datos
        /// </Sumary>
        public const string Sqlconn = @"Data Source=./; Initial Catalog = DBReservaRestaurante; Integrated Security = True; TrustServerCertificate=True";
        public static IDbConnection ObtenerConexion(TipoBD pTipoBD)
        {
            IDbConnection _conn;
            if (pTipoBD == TipoBD.SqlServer)
            {
                _conn = new SqlConnection(Sqlconn);
                return _conn;
            }
            return null;
        }
    }
}
