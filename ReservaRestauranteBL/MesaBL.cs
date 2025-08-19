using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservaRestauranteEN;
using ReservaRestauranteDAL;

namespace ReservaRestauranteBL
{
    public class MesaBL
    {
        public List<MesaEN> MostrarMesa(MesaEN mesaEN)
        {
            return MesaDAL.MostrarMesa(mesaEN);
        }
        public int GuardarMesa(MesaEN mesaEN)
        {
            return MesaDAL.AgregarMesa(mesaEN);
        }
        public int ModificarMesa(MesaEN mesaEN)
        {
            return MesaDAL.ModificarMesa(mesaEN);
        }
        public int EliminarMesa(MesaEN mesaEN)
        {
            return MesaDAL.EliminarMesa(mesaEN);
        }
    }
}
