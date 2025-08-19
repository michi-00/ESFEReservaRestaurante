using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservaRestauranteEN;
using ReservaRestauranteDAL;

namespace ReservaRestauranteBL
{
    public class RolBL
    {
        public List<RolEN> MostrarRol(RolEN rolEN)
        {
            return RolDAL.MostrarRol(rolEN);
        }
        public int GuardarRol(RolEN rolEN)
        {
            return RolDAL.AgregarRol(rolEN);
        }
        public int ModificarRol(RolEN rolEN)
        {
            return RolDAL.ModificarRol(rolEN);
        }
        public int EliminarRol(RolEN rolEN)
        {
            return RolDAL.EliminarRol(rolEN);
        }
    }
}
