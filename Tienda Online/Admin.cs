using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_Online
{
     class Admin : Usuario
    {
        private string usuario;
        private string contrasena;

        public Admin(string usuario, string contrasena, string nombre, string carnet, string apellido) : base(nombre, carnet, apellido)
        {
            this.usuario = usuario;
            this.contrasena = contrasena;
        }
        public Admin()
        {

        }
        public bool confirmarcontrasena(string contrasena)
        {
            if (this.contrasena == contrasena)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool confirmarusuario(string usuario)
        {
            if (this.usuario == usuario)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool confirmarcarnet(string carnet)
        {
            if (this.obtenercarnet() == carnet)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int pantallaaccion(Admin admin)
        {   Console.Clear();
            Console.WriteLine("Bienvenido " + admin.obtenerNombre());
            Console.WriteLine("1.Modo admin      2.Modo usuario      3.Salir");
            int entrada = Convert.ToInt32(Console.ReadLine());
            return entrada;
        }
        public void pantallaadmin(Admin admin, ref Inventario inventario, ref Usuarios usuarios, Venta venta, Pagos pago)
        {
            while (true) { 
            
                Console.Clear();
                Console.WriteLine("Bienvenido " + admin.obtenerNombre());
                Console.WriteLine("1.Agregar producto    2.Eliminar producto    3.Editar producto    4.Agregar categoria    5.Eliminar categoria    6.Editar categoria   ");
                Console.WriteLine("7.Agregar productos a categoria    8.Crear Usuario admin      9.Mostrar Usuarios      10.Reportes      11.stock      12.salir");
                int entrada = Convert.ToInt32(Console.ReadLine());
                if (entrada == 1)
                {
                    Console.Clear();
                    inventario.mostrarproductos();
                    Console.WriteLine("Agregar producto");
                    Console.WriteLine("Ingrese el nombre del producto");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el codigo del producto");
                    string codigo = Console.ReadLine();
                    Console.WriteLine("Ingrese el precio del producto");
                    int precio = Convert.ToInt32(Console.ReadLine());
                    Producto producto = new Producto(nombre, codigo, precio);
                    inventario.agregarproductoenproductos(producto);
                }
                else if (entrada == 2)
                {
                    Console.Clear();
                    inventario.mostrarproductos();
                    Console.WriteLine("Eliminar producto");
                    Console.WriteLine("Ingrese el nombre del producto que desea eliminar o escriba all para eliminar todos los productos");
                    string nombre = Console.ReadLine();
                    if(nombre== "all")
                    {
                        inventario.vaciarproductos();
                        continue;
                    }
                    Producto producto = inventario.obtenerproductopornombreenminuscula(nombre);
                    inventario.eliminarproductoenproductos(producto);
                }
                else if (entrada == 3)
                {
                    Console.Clear();
                    inventario.mostrarproductos();
                    Console.WriteLine("Editar producto");
                    Console.WriteLine("Ingrese el nombre del producto que desea editar");
                    string nombre = Console.ReadLine();
                    Producto producto = inventario.obtenerproductopornombreenminuscula(nombre);
                    Console.WriteLine("Ingrese el nuevo nombre del producto");
                    string nuevonombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo codigo del producto");
                    string nuevocodigo = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo precio del producto");
                    int nuevoprecio = Convert.ToInt32(Console.ReadLine());
                    Producto nuevoproducto = new Producto(nuevonombre, nuevocodigo, nuevoprecio);
                    inventario.editarproductoenproductos(producto, nuevoproducto);
                }
                else if (entrada == 4)
                {
                    Console.Clear();
                    inventario.mostrarcategoria_productos();
                    Console.WriteLine("Agregar categoria");
                    Console.WriteLine("Ingrese el nombre de la categoria");
                    string nombre = Console.ReadLine();
                    inventario.agregarcategoria(nombre);
                }
                else if (entrada == 5)
                {
                    Console.Clear();
                    inventario.mostrarcategoria_productos();
                    Console.WriteLine("Eliminar categoria");
                    Console.WriteLine("Ingrese el nombre de la categoria que desea eliminar");
                    string nombre = Console.ReadLine();
                    inventario.eliminarcatergoria(nombre);
                }
                else if (entrada == 6)
                {
                    Console.Clear();
                    inventario.mostrarcategoria_productos();
                    Console.WriteLine("Editar categoria");
                    Console.WriteLine("Ingrese el nombre de la categoria que desea editar");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo nombre de la categoria");
                    string nuevonombre = Console.ReadLine();
                    inventario.editarnombrecategoria(nombre, nuevonombre);

                }
                else if (entrada == 7)
                {
                    List<Producto> productoscategoria = new List<Producto>();
                    Console.WriteLine("Agregar productos a categoria");
                    inventario.mostrarproductos();
                    Console.WriteLine("Ingrese el nombre del producto que desea agregar a la categoria");
                    string nombre = Console.ReadLine();
                    Producto productonombre = inventario.obtenerproductopornombreenminuscula(nombre);
                    productoscategoria.Add(productonombre);
                    Console.WriteLine("Ingrese el nombre de la categoria");
                    string nombrecategoria = Console.ReadLine();
                    inventario.agregarproductosencategoria(nombrecategoria, productoscategoria);

                }
                else if (entrada == 8)
                {
                    Console.WriteLine("Crear Usuario admin");
                    Console.WriteLine("Ingrese el nombre del usuario");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el carnet del usuario");
                    string carnet = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido del usuario");
                    string apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese el usuario del usuario");
                    string usuario = Console.ReadLine();
                    Console.WriteLine("Ingrese la contrasena del usuario");
                    string contrasena = Console.ReadLine();
                    Admin adminnuevo = new Admin(usuario, contrasena, nombre, carnet, apellido);
                    usuarios.agregarusuarioadmin(adminnuevo);
                }
                else if (entrada == 9) 
                { 
                    Console.WriteLine("Mostrar Usuarios");
                    usuarios.mostrarusuarios();
                    usuarios.mostraradmins();
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                }
                else if (entrada == 10) {
                    Reportes reportes = new Reportes();

                    reportes.CrearReporte(venta,pago);
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();

                }
                else if (entrada == 11)
                {
                    Console.Clear();
                    Console.WriteLine("Stock");
                    inventario.mostrarproductos();
                    Console.WriteLine("Ingrese el nombre del producto para buscar el stock");
                    string entradaproducto = Console.ReadLine();
                    Console.WriteLine("Stock: " + inventario.obtenerstockdeproducto(entradaproducto));
                    Console.WriteLine("Aprete enter para continuar");
                    Console.ReadLine();


                }
                else if (entrada == 12)
                {

                    break;
                    
                }
                else
                {
                    Console.WriteLine("Opcion no valida");
                }
            }

        }
    }



}
