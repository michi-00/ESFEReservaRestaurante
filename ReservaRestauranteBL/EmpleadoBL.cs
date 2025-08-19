using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservaRestauranteEN;
using ReservaRestauranteDAL;

namespace ReservaRestauranteBL
{
    public class EmpleadoBL
    {
        public List<EmpleadoEN> MostrarEmpleado(EmpleadoEN empleadoEN)
        {
            return EmpleadoDAL.MostrarEmpleado(empleadoEN);
        }
        public int GuardarEmpleado(EmpleadoEN empleadoEN)
        {
            return EmpleadoDAL.AgregarEmpleado(empleadoEN);
        }
        public int ModificarEmpleado(EmpleadoEN empleadoEN)
        {
            return EmpleadoDAL.ModificarEmpleado(empleadoEN);
        }
        public int EliminarEmpleado(EmpleadoEN empleadoEN)
        {
            return EmpleadoDAL.EliminarEmpleado(empleadoEN);
        }
    }
}
