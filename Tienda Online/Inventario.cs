using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_Online
{
    class Inventario
    {
        private Dictionary<string, List<Producto>> Categoria;
        private List<Producto> Productos;
        public Inventario()
        {
            this.Categoria = new Dictionary<string, List<Producto>>();
            this.Productos = new List<Producto>();
        }

        public void agregarproductoenproductos(Producto producto)
        {
            if (producto == null)
            {
                Console.WriteLine("El producto no puede ser nulo");
                return;
            }

            this.Productos.Add(producto);
        }


        public void eliminarproductoenproductos(Producto producto)
        {
            this.Productos.Remove(producto);
        }
        public void editarproductoenproductos(Producto producto, Producto nuevoproducto)
        {
            foreach (Producto item in this.Productos)
            {
                if (item == producto)
                {
                    item.modificarproducto(nuevoproducto.obtenernombre(), nuevoproducto.obtenercodigo(), nuevoproducto.obtenerprecio());
                }
            }
        }
        public void vaciarproductos()
        {
            this.Productos.Clear();
            this.Categoria.Clear();
        }

        public void agregarcategoria(string categoria)
        {
            if (!this.Categoria.ContainsKey(categoria))
            {
                this.Categoria.Add(categoria, new List<Producto>());
            }
            else
            {
                Console.WriteLine("Esta categoria ya existe");
            }
        }
        public void eliminarcatergoria(string categoria)
        {
            if (this.Categoria.ContainsKey(categoria))
            {
                this.Categoria.Remove(categoria);
            }
            else
            {
                Console.WriteLine("Esta categoria no existe");
            }
        }

        public void editarnombrecategoria(string categoria, string nuevonombre)
        {
            if (this.Categoria.ContainsKey(categoria))
            {
                this.Categoria[nuevonombre] = this.Categoria[categoria];
                this.Categoria.Remove(categoria);
            }
            else
            {
                Console.WriteLine("Esta categoria no existe");
            }
        }
        public void vaciarCategoria(string categoria)
        {
            if (this.Categoria.ContainsKey(categoria))
            {
                this.Categoria[categoria].Clear();
            }
            else
            {
                Console.WriteLine("Esta categoria no existe");
            }
        }
        
        public void agregarproductosencategoria(string categoria, List<Producto> Productos)
        {
            if (this.Categoria.ContainsKey(categoria))
            {
                this.Categoria[categoria].AddRange(Productos);
            }
            else
            {
                Console.WriteLine("Esta categoria no existe");
            }
        }
        public void editarproductosencategoria(string categoria, List<Producto> Productos)
        {
            if (this.Categoria.ContainsKey(categoria))
            {
                this.Categoria[categoria] = Productos;
            }
            else
            {
                Console.WriteLine("Esta categoria no existe");
            }
        }
        public int obtenerstockdeproducto(string producto)
        {
            int stock = 0;
            foreach (var item in this.Productos)
            {
                if (item.obtenernombre() == producto)
                {
                    stock++;
                }
            }
            return stock;
        }
        public List<Producto> obtenerproductos()
        {
            return this.Productos;
        }
        public Dictionary<string, List<Producto>> ObtenerCategorias()
        {
            return this.Categoria;
        }
        public Producto obtenerproductopornombreenminuscula(string nombre)
        {
            foreach (Producto producto in this.Productos)
            {
                if (producto.obtenernombre().ToLower() == nombre.ToLower())
                {
                    return producto;
                }
            }
            return null;
        }

        public void mostrarproductos()
        {   Console.WriteLine("Productos en el inventario");
            foreach (Producto producto in this.Productos)
            {
                Console.WriteLine(producto.obtenernombre());
            }
            Console.WriteLine();
            Console.WriteLine();


        }
        public void mostrarcategoria_productos()
        {
            foreach (var item in this.Categoria)
            {
                Console.WriteLine("Categoria: " + item.Key);
                foreach (Producto producto in item.Value)
                {
                    Console.WriteLine(producto.obtenernombre());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }


    }
}
