using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_Online
{
    class Carrito
    {
        private List<Producto> productosacomprar;
        public Carrito()
        {
            this.productosacomprar = new List<Producto>();
        }

        public void agregarproducto(Producto producto)
        {
            this.productosacomprar.Add(producto);
        }

        public void eliminarproducto(Producto producto) 
        { 
            this.productosacomprar.Remove(producto);
        }
       
        
        public void vaciarcarrito()
        {
            this.productosacomprar.Clear();
        }
        
        
        public List<Producto> pantalla(Inventario inventario)
        {
            List<Producto> productos = new List<Producto>(inventario.obtenerproductos());
            while (true) { 
            Console.WriteLine("Bienvenido al carrito de compras");
            Console.WriteLine("Productos en el carrito");
                foreach (Producto producto in this.productosacomprar)
                {
                    Console.Write(producto.obtenernombre());
                    Console.Write(" | ");
                }
                Console.WriteLine("\n1.Agregar producto al carrito    2.Eliminar producto del carrito    3.Vaciar carrito    4.Comprar    5.Salir");
                 int opcion = Convert.ToInt32(Console.ReadLine());
               
                if (opcion == 1)
                {
                    Console.WriteLine("Productos disponibles");
                    foreach (Producto producto in productos)
                    {
                        Console.Write(producto.obtenernombre());
                        Console.Write(" | ");
                    }
                    Console.WriteLine("\nIngrese el nombre del producto que desea agregar al carrito");
                    string nombre = Console.ReadLine();
                    Producto productoaquitar = inventario.obtenerproductopornombreenminuscula(nombre);
                    if (!productos.Contains(productoaquitar))
                    {
                        Console.Clear();
                        Console.WriteLine("Producto no disponible");
                        continue;
                    }
                    this.agregarproducto(productoaquitar);
                    productos.Remove(productoaquitar);

                    Console.Clear();
                }
                else if (opcion == 2)
                {
                    Console.WriteLine("Ingrese el nombre del producto a eliminar");
                    string nombre = Console.ReadLine();
                    Producto productoaquitar = inventario.obtenerproductopornombreenminuscula(nombre);
                    if (productos.Contains(productoaquitar))
                    {
                        Console.Clear();
                        Console.WriteLine("Producto no disponible");
                        continue;
                    }
                    productos.Add(productoaquitar);
                    this.productosacomprar.Remove(productoaquitar);
                    Console.Clear();
                }
                else if (opcion==3)
                {
                    vaciarcarrito();
                    productos = new List<Producto>(inventario.obtenerproductos());
                    Console.Clear();
                }
                else if (opcion == 4)
                {
                    return this.productosacomprar;
                }
                else if (opcion == 5)
                {
                    break;
                }
                else
                {   Console.Clear();
                    Console.WriteLine("Opcion invalida");
                }




            }
            return null;
        }


    }
}
