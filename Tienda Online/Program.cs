using System.ComponentModel;
using Tienda_Online;

internal class Program
{
    private static void Main(string[] args)
    {
        

        Inventario inventario = new Inventario();

        inventario.agregarproductoenproductos(new Producto("Samsung Galaxy", "5678910", 150));
        inventario.agregarproductoenproductos(new Producto("Iphone 12", "1234567", 200));
        inventario.agregarproductoenproductos(new Producto("Xiaomi Redmi Note 10", "89101112", 100));
        inventario.agregarcategoria("celulares");
        inventario.agregarproductosencategoria("celulares", inventario.obtenerproductos());

        Usuarios usuarios = new Usuarios();
        Venta venta = new Venta();
        Pagos pagos = new Pagos();


        while (true)
        {   Console.Clear();
            var retorno = usuarios.pantalla();
            if (retorno.Item1 == 1)
            {
                int entrada2;
                Admin admin = new Admin();
                admin=(Admin)retorno.Item2;
                entrada2 =admin.pantallaaccion(admin);
                if (entrada2 == 1)
                {
                    admin.pantallaadmin(admin,ref inventario,ref usuarios,venta,pagos);
                }
                else if (entrada2==2)
                {
                    int entrada;
                    Usuario usuario = new Usuario();
                    Console.Clear();
                    usuario = retorno.Item2;
                    entrada = usuario.pantalla(usuario);
                    //comprar
                    if (entrada == 2)
                    {
                        Carrito carrito = new Carrito();
                        List<Producto> productosacomprar = carrito.pantalla(inventario);
                        if (productosacomprar != null)
                        {
                            Console.Clear();
                            venta.pantallacliente(productosacomprar, ref inventario, usuario,ref pagos);
                        }


                    }
                    //salir
                    else if (entrada == 3)
                    {
                        return;
                    }

                }
                else if (entrada2==3)
                {
                    break;
                }

            }
            else if (retorno.Item1 == 2)
            {
                int entrada;
                Usuario usuario = new Usuario();
                Console.Clear();
                usuario = retorno.Item2;
                entrada = usuario.pantalla(usuario);
                //comprar
                if (entrada == 2)
                {
                    Carrito carrito = new Carrito();
                    List<Producto> productosacomprar = carrito.pantalla(inventario);
                    if (productosacomprar != null)
                    {
                        Console.Clear();
                        venta.pantallacliente(productosacomprar, ref inventario, usuario,ref pagos);
                    }


                }
                //salir
                else if (entrada == 3)
                {
                    return;
                }
            
            
            }
            else
            {
                return;
            }
        }









    }
}