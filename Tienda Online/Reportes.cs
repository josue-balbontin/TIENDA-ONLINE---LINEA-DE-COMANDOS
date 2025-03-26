using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_Online
{
    class Reportes
    {
        public void CrearReporte(Venta venta,Pagos total) 
        {
             Console.WriteLine("Productos Vendidos: ");
            foreach (Producto producto in venta.obtenerproductosvendidos())
            {
                Console.WriteLine(producto.obtenernombre());
            }
            Console.WriteLine("Total Ganado: " + total.obtenertotal());

        }

        
    }
}
