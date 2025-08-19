using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaRestauranteEN
{
    public class EmpleadoEN : PersonaEN
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Direccion { get; set; }
        public int IdRol { get; set; }
        public override string ObtenerInfo()
        {
            return $"Nombre: {Nombre}, Contraseña: {Contraseña}, Dirección, {Direccion}";
        }
    }
}
