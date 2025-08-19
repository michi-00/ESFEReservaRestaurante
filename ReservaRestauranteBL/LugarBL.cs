using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservaRestauranteEN;
using ReservaRestauranteDAL;

namespace ReservaRestauranteBL
{
    public class LugarBL
    {
        public List<LugarEN> MostrarLugar(LugarEN lugarEN)
        {
            return LugarDAL.MostrarLugar(lugarEN);
        }
        public int GuardarLugar(LugarEN lugarEN)
        {
            return LugarDAL.AgregarLugar(lugarEN);
        }
        public int ModificarLugar(LugarEN lugarEN)
        {
            return LugarDAL.ModificarLugar(lugarEN);
        }
        public int EliminarLugar(LugarEN lugarEN)
        {
            return LugarDAL.EliminarLugar(lugarEN);
        }
    }
}
