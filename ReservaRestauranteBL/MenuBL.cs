using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservaRestauranteEN;
using ReservaRestauranteDAL;

namespace ReservaRestauranteBL
{
    public class MenuBL
    {
        public List<MenuEN> MostrarMenú(MenuEN menúEN)
        {
            return MenuDAL.MostrarMenú(menúEN);
        }
        public int GuardarMenú(MenuEN menúEN)
        {
            return MenuDAL.AgregarMenú(menúEN);
        }
        public int ModificarMenú(MenuEN menúEN)
        {
            return MenuDAL.ModificarMenú(menúEN);
        }
        public int EliminarMenú(MenuEN menúEN)
        {
            return MenuDAL.EliminarMenú(menúEN);
        }
    }
}
