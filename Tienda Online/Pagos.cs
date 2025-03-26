using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_Online
{
    class Pagos
    {

        private int total;
        public int Totalapagar(List<Producto> productos)
        {
            this.total = 0;
            foreach (Producto producto in productos)
            {
                this.total =total+ producto.obtenerprecio();
            }
            return this.total;
        }
        public int obtenertotal()
        {
            return total;
        }
        public bool confirmarpago()
        {
            Console.Clear();
            Console.WriteLine("Escriba su targeta de credito");
            string targeta = Console.ReadLine();
            if (targeta.Length == 16)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
