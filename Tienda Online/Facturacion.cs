using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_Online
{
    class Facturacion
    {
        private DateTime fecha;


        
        public void mostrarfactura(List<Producto> productosvendidos,Usuario usuario , Pagos pago)
        {   Console.Clear();
            this.fecha = DateTime.Now;

            Console.WriteLine("Fecha: " + this.fecha);
            Console.WriteLine("Usuario: " + usuario.obtenerNombre());
            Console.WriteLine("Productos: ");
            foreach (Producto producto in productosvendidos)
            {
                Console.WriteLine(producto.obtenernombre());
            }
            Console.WriteLine("Total: " + pago.obtenertotal());



            Console.WriteLine("Gracias por su compra");

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();


        }

      



    }
}
