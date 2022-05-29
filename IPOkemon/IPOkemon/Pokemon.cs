using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOkemon
{
    public class Pokemon
    {
        public string nombre { get; set; }
        public int nivel { get; set; }
        public double exp { get; set; }
        public string tipo { get; set; }
        public bool capturado { get; set; }
        public string descripcion { get; set; }
        public string sprite { get; set; }

        public Pokemon(string nombre, int nivel, double exp, string tipo, bool capturado, string descripcion, string sprite)
        {
            this.nombre = nombre;
            this.nivel = nivel;
            this.exp = exp;
            this.tipo = tipo;
            this.capturado = capturado;
            this.descripcion = descripcion;
            this.sprite = sprite;
        }
    }
}
