using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_Online
{   

    class Venta
    {
        private List<Producto> productosvendidos;
        public Venta()
        {
            productosvendidos = new List<Producto>();
        }
        public void confirmarventa(List<Producto> productosavender, ref List<Producto> Productos,ref Dictionary<string, List<Producto>> Categoria)
        {   
            if(productosavender == null || Productos == null || Categoria == null)
            {
                Console.WriteLine("No se puede vender productos nulos");
                return;
            }

            productosvendidos.AddRange(productosavender);
            foreach (Producto producto in productosavender)
            {
                    foreach(string categoria in Categoria.Keys.ToList())
                    {   

                        Categoria[categoria].Remove(producto);
                        
                
                    }
              
                    Productos.Remove(producto);
            }


        }

        public List<Producto> obtenerproductosvendidos()
        {
            return productosvendidos;
        }

        public void pantallacliente(List<Producto> productosacomprar,ref Inventario inventario,Usuario usuario,ref Pagos pago)
        {
            while (true) { 
           
            Console.WriteLine("CONFIRMAR VENTA");
            Console.WriteLine("Productos a comprar");
            foreach (Producto producto in productosacomprar)
            {
                Console.WriteLine(producto.obtenernombre());
            }
            Console.Write("Total a pagar:");
            Console.Write(pago.Totalapagar(productosacomprar));
            Console.WriteLine();
            Console.WriteLine("1.Confirmar venta    2.Cancelar venta");
            int opcion = new Errores().cin();
            if (opcion == 1)
            {
                List<Producto> productosavender = new List<Producto>();
                productosavender = inventario.obtenerproductos();
                Dictionary<string, List<Producto>> categorias = new Dictionary<string, List<Producto>>();
                categorias= inventario.ObtenerCategorias();
                if (pago.confirmarpago() == true)
                {
                    confirmarventa(productosacomprar, ref productosavender, ref categorias);
                    Console.WriteLine("desea factura? escriba si o no");
                        string factura = Console.ReadLine();
                        if (factura == "si")
                        {
                            Facturacion fact = new Facturacion();
                            fact.mostrarfactura(this.productosvendidos,usuario,pago);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Gracias por su compra");
                        }



                    }
                else
                {
                    Console.WriteLine("Pago no confirmado");
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();

                }
             
            }
            else
            {
                return;
            }
            Console.Clear();
            }
        }


    }
}
