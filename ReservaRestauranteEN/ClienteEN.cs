using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaRestauranteEN
{
    public class ClienteEN : PersonaEN
    {
        public Int64 Id { get; set; }
        
        public string Nombre { get; set; }

        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public override string ObtenerInfo()
        {
            return $"Cliente: {Nombre}, Teléfono: {Telefono}, Dirección: {Direccion}";
        }

    }
}
