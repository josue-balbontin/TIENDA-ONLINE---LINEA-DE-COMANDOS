using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_Online
{

     class Usuario
    {
        private string nombre;
        private string carnet;
        private string apellido;

        public Usuario(string nombre, string carnet, string apellido)
        {
            this.nombre = nombre;
            this.carnet = carnet;
            this.apellido = apellido;
        }
        public Usuario()
        {

        }


        public string obtenerNombre()
        {
            return this.nombre;
        }
        public void editarnombre(string nombre)
        {
            this.nombre = nombre;

        }
        public string obtenercarnet()
        {
            return this.carnet;
        }
        
        public string obtenerapellido()
        {
            return this.apellido;
        }
        public void editarapellido(string apellido)
        {
            this.apellido = apellido;
        }
        public int pantalla(Usuario usuario)
        {
            while (true) { 
            Console.WriteLine("Bienvenido " + usuario.nombre);
            Console.WriteLine("1.Editar usuario    2.Comprar    3.Salir");
            int opcion = new Errores().cin();
            if (opcion == 1)
            {
                while (true)
                {
                        Console.Clear();
                    Console.WriteLine("Usuario actual: ");
                    Console.WriteLine("Nombre: " + usuario.nombre);
                    Console.WriteLine("Carnet: " + usuario.carnet);
                    Console.WriteLine("Apellido: " + usuario.apellido);

                    Console.WriteLine("ingrese que quiere cambiar");
                    Console.WriteLine("1.Nombre    2.Apellido    3.nada");
                    int opciointe = new Errores().cin();
                    string entrada;
                    if (opciointe == 1)
                    {
                        Console.WriteLine("Ingrese el nuevo nombre");
                        entrada = Console.ReadLine();
                        usuario.editarnombre(entrada);
                    }
                    else if (opciointe == 2)
                    {
                        Console.WriteLine("Ingrese el nuevo apellido");
                        entrada = Console.ReadLine();
                        usuario.editarapellido(entrada);
                    }
                    else if (opciointe == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opcion invalida");
                    }
                    Console.Clear();
                }
                Console.Clear();
                Console.WriteLine("Usuario actualizado");
                


            }
            else if (opcion == 2)
            {
                Console.Clear();
                    return 2;
            }
            else if (opcion == 3)
            {
                Console.WriteLine("Saliendo");
                return -1;
            }

            }

        }

    }


}
