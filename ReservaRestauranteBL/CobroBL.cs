using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservaRestauranteEN;
using ReservaRestauranteDAL;

namespace ReservaRestauranteBL
{
    public class CobroBL
    {
        public List<CobroEN> MostrarCobro(CobroEN cobroEN)
        {
            return CobroDAL.MostrarCobro(cobroEN);
        }
        public int GuardarCobro(CobroEN cobroEN)
        {
            return CobroDAL.AgregarCobro(cobroEN);
        }
        public int ModificarCobro(CobroEN cobroEN)
        {
            return CobroDAL.ModificarCobro(cobroEN);
        }
        public int EliminarCobro(CobroEN cobroEN)
        {
            return CobroDAL.EliminarCobro(cobroEN);
        }
    }
}
