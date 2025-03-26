using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_Online
{
    class Producto
    {
        private string Nombre;
        private string codigo;
        private int precio;
        
        public Producto(string nombre, string codigo, int precio)
        {
            this.Nombre = nombre;
            this.codigo = codigo;
            this.precio = precio;
        }


        public void modificarproducto(string nombre,string codigo , int precio)
        {
            this.Nombre = nombre;
            this.codigo = codigo;
            this.precio = precio;
        }
        public string obtenernombre()
        {
            return this.Nombre;
        }
        public int obtenerprecio()
        {
            return this.precio;
        }
        public string obtenercodigo()
        {
            return this.codigo;
        }
        
      
    }
}
