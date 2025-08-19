using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservaRestauranteEN;
using ReservaRestauranteDAL;

namespace ReservaRestauranteBL
{
    public class UsuarioBL
    {
        public int VerificarUsuario(UsuarioEN pUsuarioEN)
        {
            return UsuarioDAL.VerificarUsuario(pUsuarioEN);
        }


        public List<UsuarioEN> MostrarUsuario(UsuarioEN pUsuarioEN)
        {
            return UsuarioDAL.MostrarUsuario(pUsuarioEN);
        }

        public int GuardarUsuario(UsuarioEN pUsuarioEN)
        {
            return UsuarioDAL.GuardarUsuario(pUsuarioEN);
        }

        public int EliminarUsuario(UsuarioEN pUsuarioEN)
        {
            return UsuarioDAL.EliminarUsuario(pUsuarioEN);
        }

        public int ModificarUsuario(UsuarioEN pUsuarioEN)
        {
            return UsuarioDAL.ModificarUsuario(pUsuarioEN);
        }
    }
}
