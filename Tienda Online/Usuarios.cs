using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_Online
{
    class Usuarios
    {
        private List<Usuario> usuarios;
        private List<Admin> admins;
        public Usuarios()
        {   Admin admin = new Admin("admin", "admin", "admin", "1", "admin");
            this.usuarios = new List<Usuario>();
            this.admins = new List<Admin>();
            admins.Add(admin);
        }
        public (int salida ,Usuario usuario) pantalla()
        {
            while (true) {
            Console.WriteLine("Bienvenido a la tienda online");
            Console.WriteLine("Ingrese su tipo de usuario");
            Console.WriteLine("1. Administrador       2.Usuario      3.Salir");
            int entrada;
            entrada = new Errores().cin();
                if (entrada == 1)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("ADMINISTRADOR");
                        Console.WriteLine("1. Iniciar sesion    2. regresar");
                        int entrada2 = new Errores().cin();
                        if (entrada2 == 1)
                        {
                            foreach (Admin admin in admins)
                            {
                                Console.WriteLine("Ingrese su usuario o id");
                                string usuario = Console.ReadLine();
                                Console.WriteLine("Ingrese su contrasena");
                                string contrasena = Console.ReadLine();
                                if ((admin.confirmarcontrasena(contrasena) && admin.confirmarusuario(usuario)) || (admin.confirmarcontrasena(contrasena) && admin.confirmarcarnet(usuario)))
                                {
                                    return (1, admin);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Usuario o contrasena incorrecta");
                                    Console.WriteLine("aprete enter para continuar");
                                    Console.ReadLine();

                                }
                            }
                        }
                        else if (entrada2 == 2)
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {   Console.Clear();
                            Console.WriteLine("Opcion invalida");
                            Console.WriteLine("aprete enter para continuar");
                            Console.ReadLine();
                        }


                    }
                }

                else if (entrada == 2)
                {
                    while (true) { 
                    Console.Clear();
                    Console.WriteLine("Usuario");
                    Console.WriteLine("1.Iniciar sesion    2.Crear cuenta   3.Regresar");
                    int entrada2 = new Errores().cin();
                        if(entrada2 == 1)
                        {
                            if (usuarios.Count() == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("No hay usuarios registrados cree uno");
                                Console.WriteLine("aprete enter para continuar");
                                Console.ReadLine();
                            }
                            else { 
                                Console.WriteLine("Ingrese su carnet");
                            string carnet = Console.ReadLine();
                            foreach (Usuario usuario in usuarios)
                            {
                                if (usuario.obtenercarnet()==carnet)
                                {
                                    return (2, usuario);
                                    }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Usuario o contrasena incorrecta");
                                    Console.WriteLine("aprete enter para continuar");
                                    Console.ReadLine();
                                }
                            }
                            }
                        }
                        else if (entrada2 == 2)
                        {
                            Console.WriteLine("Ingrese su nombre");
                            string nombre = Console.ReadLine();
                            bool pase = true;
                            string carnet;
                            do {
                                pase = true;
                                Console.WriteLine("Ingrese su carnet");
                                carnet = Console.ReadLine();
                                foreach (Usuario usuario2 in usuarios)
                                {
                                    if (usuario2.obtenercarnet() == carnet)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Carnet ya registrado escriba otro");
                                        Console.WriteLine("aprete enter para continuar");
                                        Console.ReadLine();
                                        Console.Clear();
                                        pase = false;
                                        break;
                                    }
                                }


                            }while(pase!=true);





                            Console.WriteLine("Ingrese su apellido");
                            string apellido = Console.ReadLine(); 
                            Usuario usuario = new Usuario(nombre, carnet, apellido);
                            usuarios.Add(usuario);
                            Console.Clear();
                            Console.WriteLine("Usuario creado exitosamente");
                            Console.WriteLine("aprete enter para continuar");
                            Console.ReadLine();
                        }
                        else if (entrada2 == 3)
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Opcion invalida");
                            Console.WriteLine("aprete enter para continuar");
                            Console.ReadLine();
                        }


                    }
                }
                else if (entrada == 3)
                {
                    return(3, null);
                }
                else
                {
                    Console.WriteLine("Opcion invalida");
                }
            
            }


        }
        
        
        public void agregarusuarioadmin(Admin admin)
        {   
            this.admins.Add(admin);
        }

        public void mostrarusuarios()
        {   Console.WriteLine("Usuarios registrados:");
            foreach (Usuario usuario in usuarios)
            {
                Console.WriteLine(usuario.obtenerNombre());
            }
            Console.WriteLine();
        }

        public void mostraradmins()
        {
            Console.WriteLine("Administradores registrados");
            foreach (Admin admin in admins)
            {
                Console.WriteLine(admin.obtenerNombre());
            }
            Console.WriteLine();
        }






    }
}
