using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticiero
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Biblioteca miBiblioteca = new Biblioteca();
                MenuPrincipal(miBiblioteca);
                Console.Clear();
                Console.CursorVisible = false;
                Console.Title = "Adios :(";
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~ The New York Times ~~~~~~~~~~~~~~~~~~~~\n"); 
                Console.WriteLine("   Gracias por usar nuestra aplicacion.\n   Presione cualquier tecla para finalizar.\n");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inesperado. " + ex.Message);
            }
            Console.ReadKey();
        }

        // Logica de Menu principal.
        static void MenuPrincipal(Biblioteca miBiblioteca)
        {
            bool modoOscuro = true;
            int opcion = -1;

            while (opcion != 0)
            {
                MenuInicial(modoOscuro);
                opcion = NumeroValido(0, 2);

                switch (opcion)
                {
                    case 0: // Salir.
                        break;
                    case 1: // Menu de gestion de periodico.
                        AdministrarPeriodico(miBiblioteca);
                        break;
                    case 2: // Activar o desactivar modo oscuro.
                        ModoOscuro(ref modoOscuro);
                        break;
                    default:
                        break;
                }
            }
        }

        // Operacion para cambiar el tema de la consola.
        static void ModoOscuro(ref bool modoOscuro)
        {
            if (modoOscuro)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                modoOscuro = false;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                modoOscuro = true;
            }
        }

        // Desplegamos el Menu principal.
        static void MenuInicial(bool modoOscuro)
        {
            Console.Title = "The New York Times.";
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~ The New York Times ~~~~~~~~~~~~~~~~~~~~\n");
            Console.WriteLine("                " + DateTime.Now.ToString("dd/MM/yyyy hh:mm") + "\n");
            Console.WriteLine("   1 - Administrar periodico");
            Console.WriteLine("   2 - " + (modoOscuro ? "Desactivar" : "Activar") + " modo oscuro\n");
            Console.WriteLine("   0 - Salir\n");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
        }

        // Logica de Administrar periodico.
        static void AdministrarPeriodico(Biblioteca miBiblioteca)
        {
            int opcion = -1;
            while (opcion != 0)
            {
                MenuAPeriodico(miBiblioteca);
                opcion = NumeroValido(0, 7);

                switch (opcion)
                {
                    case 0: // Salir.
                        break;
                    case 1: // Mantenimiento de secciones.
                        MantenimientoSecciones(miBiblioteca);
                        break;
                    case 2: // Mantenimiento de periodistas.
                        MantenimientoPeriodistas(miBiblioteca);
                        break;
                    case 3:  // Agrega una noticia internacional.
                        AgregarInternacional(miBiblioteca);
                        break;
                    case 4: // Agrega una noticia nacional.
                        AgregarNacional(miBiblioteca);
                        break;
                    case 5:  // Lista todas las noticias ordenadas por fecha de creacion.
                        Console.Clear();
                        Console.Title = "Listar todas las noticias.";
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~ NYT - Listar noticias ~~~~~~~~~~~~~~~~~~\n");

                        if (miBiblioteca.CantidadNoticias() == 0)
                        {
                            Console.CursorVisible = false;
                            Console.WriteLine("   Debe agregar al menos 1 noticia para poder listarlas.\n");
                            Console.WriteLine("   Presione cualquier tecla para volver.\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Acceso restringido ~~~~");
                            Console.ReadKey();
                            Console.CursorVisible = true;
                        }
                        else
                            ListarNoticias(miBiblioteca);

                        break;
                    case 6: // Lista todas las noticias que tienen una fecha posterior o igual a la indicada.
                        Console.Clear();
                        Console.Title = "Listar noticias en fecha.";
                        Console.WriteLine("~~~~~~~~~~~~~~ NYT - Listar noticias en fecha ~~~~~~~~~~~~~~\n");

                        // Verificam que haya al menos 1 noticia agregada.
                        if (miBiblioteca.CantidadNoticias() == 0)
                        {
                            Console.CursorVisible = false;
                            Console.WriteLine("   Debe agregar al menos 1 noticia para poder listarlas.\n");
                            Console.WriteLine("   Presione cualquier tecla para volver.\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Acceso restringido ~~~~");
                            Console.ReadKey();
                            Console.CursorVisible = true;
                        }
                        else
                        {
                            DateTime fecha;
                            Console.Write("   Ingrese la fecha en la que desea buscar las noticias (mes dia año).\n > ");
                            while (true)
                            {
                                try
                                {
                                    fecha = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine();
                                    break;
                                }
                                catch
                                {
                                    Console.Write("\n   Ingrese una fecha de tipo valido (mes dia año).\n > ");
                                }
                            }
                            ListarNoticias(miBiblioteca, fecha);
                        }

                        break;
                    case 7: // Lista todas las noticias que pertenecen a la seccion indicada.
                        Console.Clear();
                        Console.Title = "Listar noticias por seccion.";
                        Console.WriteLine("~~~~~~~~~~~~ NYT - Listar noticias por seccion ~~~~~~~~~~~~~\n");
                        // Verifica que hayan noticias y secciones agregadas.
                        if (miBiblioteca.CantidadNoticias() == 0)
                        {
                            Console.CursorVisible = false;
                            Console.WriteLine("   Debe agregar al menos 1 noticia para poder listarlas.\n");
                            Console.WriteLine("   Presione cualquier tecla para volver.\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
                            Console.ReadKey();
                            Console.CursorVisible = true;
                        }
                        else if (miBiblioteca.CantidadSecciones() == 0)
                        {
                            Console.CursorVisible = false;
                            Console.WriteLine("   Debe agregar al menos 1 seccion para poder buscarlas.\n");
                            Console.WriteLine("   Presione cualquier tecla para volver.\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
                            Console.ReadKey();
                            Console.CursorVisible = true;
                        }
                        else
                        {
                            Console.Write("   Ingrese el codigo de la seccion.\n > ");
                            string codigo = TextoIDSeccion(false);
                            Seccion miSeccion = miBiblioteca.BuscarSeccion(codigo);
                            if (miSeccion == null)
                            {
                                Console.CursorVisible = false;
                                Console.WriteLine("\n   La seccion "+ codigo +" nunca fue agregada.\n");
                                Console.WriteLine("   Presione cualquier tecla para volver.\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
                                Console.ReadKey();
                                Console.CursorVisible = true;
                                break;
                            }
                            Console.WriteLine();
                            ListarNoticias(miBiblioteca, miSeccion);
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        // Desplega el menu Administrar periodico.
        static void MenuAPeriodico(Biblioteca miBiblioteca)
        {
            Console.Title = "The New York Times.";
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~ The New York Times ~~~~~~~~~~~~~~~~~~~~\n");
            Console.WriteLine("   Noticias(" + miBiblioteca.CantidadNoticias() + ") Periodistas(" + miBiblioteca.CantidadPeriodistas() + ") Secciones(" + miBiblioteca.CantidadSecciones() + ")\n");
            Console.WriteLine("   1 - Mantenimiento de secciones");
            Console.WriteLine("   2 - Mantenimiento de periodistas");
            Console.WriteLine("   3 - Agregar noticia internacional");
            Console.WriteLine("   4 - Agregar noticia nacional");
            Console.WriteLine("   5 - Listar todas las noticias");
            Console.WriteLine("   6 - Listar noticias por fecha");
            Console.WriteLine("   7 - Listar noticias por seccion\n");
            Console.WriteLine("   0 - Salir\n");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
        }

        // Logica donde veremos si el usuario agregara, modificara o eliminara una seccion.
        static void MantenimientoSecciones(Biblioteca miBiblioteca)
        {
            Console.Title = "Mantenimiento de secciones.";
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~ NYT - Mantenimiento de secciones ~~~~~~~~~~~~~\n");
            Console.WriteLine("   Ingrese el codigo identificador");
            Console.Write(" > ");

            string codigoSeccion = TextoIDSeccion(false);
            Seccion sec = miBiblioteca.BuscarSeccion(codigoSeccion);

            // Si la seccion no existe, se crea uno nuevos con ese codigo.
            if (sec == null)
                AgregarSeccion(codigoSeccion, miBiblioteca);
            else
            {
                int opcion = -1;
                while (opcion != 0)
                {
                    Console.Title = "Mantenimiento de secciones.";
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~ NYT - Seccion (" + codigoSeccion + ") ~~~~~~~~~~~~~~~~~~~~~\n");
                    Console.WriteLine("   1 - Editar seccion");
                    Console.WriteLine("   2 - Eliminar seccion \n");
                    Console.WriteLine("   0 - Volver\n");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");

                    opcion = NumeroValido(0, 2);
                    switch (opcion)
                    {
                        case 0: // Volver.
                            break;
                        case 1: // Modificar seccion.
                            EditarSeccion(sec, miBiblioteca);
                            opcion = 0;
                            break;
                        case 2: // Eliminar seccion.
                            Console.CursorVisible = false;
                            Console.Clear();

                            try
                            {
                                miBiblioteca.EliminarSeccion(sec);
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~ NYT - Seccion (" + codigoSeccion + ") ~~~~~~~~~~~~~~~~~~~~~\n");
                                Console.WriteLine("   La seccion " + codigoSeccion + " fue eliminada correctamente.\n");
                                Console.WriteLine("   Presione cualquier tecla para continuar.\n");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~ NYT - Seccion (" + codigoSeccion + ") ~~~~~~~~~~~~~~~~~~~~~\n");
                                Console.WriteLine("   " + ex.Message + "\n");
                                Console.WriteLine("   Presione cualquier tecla para continuar.\n");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
                            }

                            Console.ReadKey();
                            Console.CursorVisible = true;
                            opcion = 0;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        // Crea una nueva seccion y se agrega.
        static void AgregarSeccion(string codigoSeccion, Biblioteca miBiblioteca)
        {
            Console.Title = "Agregar seccion.";
            Console.Clear();

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~ NYT - Agregar seccion ~~~~~~~~~~~~~~~~~~\n");
            Console.WriteLine("   Ingrese el nombre de la seccion (" + codigoSeccion + ")");
            Console.Write(" > ");
            string nombre = TextoValido(1, int.MaxValue);

            Seccion nuevaSeccion = new Seccion(nombre, codigoSeccion);

            try
            {
                if (miBiblioteca.AgregarSeccion(nuevaSeccion))
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.WriteLine("~~~~~~~~~~~~~ NYT - Seccion agregada con exito ~~~~~~~~~~~~~~\n");
                    Console.WriteLine("   " + nuevaSeccion.ToString());
                    Console.WriteLine("\n   Presione cualquier tecla para continuar.");
                    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
                }
            }
            catch (Exception ex)
            {
                Console.CursorVisible = false;
                Console.WriteLine("\n   " + ex.Message + "\n   Presione cualquier tecla para volver.");
            }

            Console.ReadKey();
            Console.CursorVisible = true;
        }

        // Modifica la seccion indicada en funcion a la desicion del usuario.
        static void EditarSeccion(Seccion sec, Biblioteca miBiblioteca)
        {
            Console.Title = "Editar seccion (" + sec.CodigoSeccion + ")";
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~ NYT - Editar Seccion ~~~~~~~~~~~~~~~~~~\n   ");

            string nuevoNombre;

            try
            {
                Console.WriteLine(sec.ToString() + "\n");
                Console.Write("   Ingrese un nuevo nombre <enter para no cambiar>\n > ");
                nuevoNombre = Console.ReadLine().Trim();
                if (nuevoNombre != "")
                    sec.Nombre = nuevoNombre;

                if (miBiblioteca.ModificarSeccion(sec))
                {
                    Console.WriteLine("\n   Edicion completada con exito.\n   ");
                    Console.WriteLine(sec.ToString());
                    Console.WriteLine("\n   Presione cualquier tecla para continuar.");
                    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
                    Console.CursorVisible = false;
                }
                else
                {
                    Console.CursorVisible = false;
                    Console.WriteLine("\n   No se realizo la modificacion, la seccion no existe.\n \n   Presione cualquier tecla para continuar.\n");
                }
            }
            catch (Exception ex)
            {
                Console.CursorVisible = false;
                Console.WriteLine("\n   " + ex.Message + "\n   Presione cualquier tecla para volver.");

            }

            Console.ReadKey();
            Console.CursorVisible = true;
        }

        // Logica donde veremos si el usuario agregara, modificara o eliminara un periodista.
        static void MantenimientoPeriodistas(Biblioteca miBiblioteca)
        {
            Console.Title = "Mantenimiento de periodistas.";
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~ NYT - Mantenimiento de periodistas ~~~~~~~~~~~~\n");
            Console.WriteLine("   Ingrese el codigo identificador del periodista.");
            int codigoPeriodista = NumeroValido(0, int.MaxValue);
            Periodista per = miBiblioteca.BuscarPeriodista(codigoPeriodista);

            // Si el periodista no existe, se crea uno nuevos con ese codigo.
            if (per == null)
                AgregarPeriodista(codigoPeriodista, miBiblioteca);
            else
            {
                int opcion = -1;
                while (opcion != 0)
                {
                    Console.Title = "Mantenimiento de periodista.";
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~ NYT - periodista (" + per.Nombre + ") ~~~~~~~~~~~~~~~\n");
                    Console.WriteLine("   1 - Editar informacion");
                    Console.WriteLine("   2 - Eliminar peridosita\n");
                    Console.WriteLine("   0 - Volver\n");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~\n");

                    opcion = NumeroValido(0, 2);
                    switch (opcion)
                    {
                        case 0: // Volver.
                            break;
                        case 1: // Modificar periodista.
                            EditarPeriodista(per, miBiblioteca);
                            opcion = 0;
                            break;
                        case 2: // Eliminar periodista.
                            Console.CursorVisible = false;
                            Console.Clear();

                            try
                            {
                                miBiblioteca.EliminarPeriodista(per);
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~ NYT - Periodista N°" + codigoPeriodista + " ~~~~~~~~~~~~~~~~~~~\n");
                                Console.WriteLine("   El periodista N°" + codigoPeriodista + " fue eliminada correctamente.\n");
                                Console.WriteLine("   Presione cualquier tecla para continuar.\n");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~ NYT - Periodista N°" + codigoPeriodista + " ~~~~~~~~~~~~~~~~~~~\n");
                                Console.WriteLine("   " + ex.Message + "\n");
                                Console.WriteLine("   Presione cualquier tecla para continuar.\n");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~\n");
                            }

                            Console.ReadKey();
                            Console.CursorVisible = true;
                            opcion = 0;
                            break;
                        default:
                            break;
                    }
                }
            }

        }

        // Crea un nuevo periodista y lo agrega.
        static void AgregarPeriodista(int codigoPeriodista, Biblioteca miBiblioteca)
        {
            Console.Title = "Agregar periodista.";
            Console.Clear();

            Console.WriteLine("~~~~~~~~~~~~~~~~~ NYT - Agregar periodista ~~~~~~~~~~~~~~~~~\n");
            Console.WriteLine("   Codigo Identificador: " + codigoPeriodista);

            Console.Write("   Nombre completo: ");
            string nombre = TextoValido(1, int.MaxValue);

            Console.Write("   Correo electronico: ");
            string correo;
            while (true)
            {
                correo = TextoValido(1, int.MaxValue);
                // Verifica que el texto sea un correo valido.
                if ((correo.Replace("@", String.Empty)).Length != correo.Length - 1)
                {
                    Console.Write("   Ingrese un correo electronico valido: ");
                }
                else
                    break;
            }

            Periodista nuevoPeriodista = new Periodista(nombre, correo, codigoPeriodista);

            try
            {
                if (miBiblioteca.AgregarPeriodista(nuevoPeriodista))
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.WriteLine("~~~~~~~~~~~ NYT - Periodista agregado con exito ~~~~~~~~~~~~\n");
                    Console.WriteLine("   " + nuevoPeriodista.ToString());
                    Console.WriteLine("\n   Presione cualquier tecla para continuar.");
                    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
                }
            }
            catch (Exception ex)
            {
                Console.CursorVisible = false;
                Console.WriteLine("\n   " + ex.Message + "\n   Presione cualquier tecla para volver.");
            }
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        // Modifica el periodista indicado en funcion a la desicion del usuario.
        static void EditarPeriodista(Periodista per, Biblioteca miBiblioteca)
        {
            Console.Title = "Editar informacion";
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~ NYT - Editar informacion ~~~~~~~~~~~~~~~~~\n   ");

            string nuevoNombre, nuevoCorreo;

            while (true)
                try
                {
                    Console.WriteLine(per.ToString());
                    Console.Write("\n   Ingrese un nuevo nombre <enter para no cambiar>\n > ");
                    nuevoNombre = Console.ReadLine().Trim();
                    if (nuevoNombre != "")
                        per.Nombre = nuevoNombre;

                    Console.Write("\n   Ingrese un nuevo correo <enter para no cambiar>\n > ");
                    while (true)
                    {
                        nuevoCorreo = Console.ReadLine();
                        if (nuevoCorreo == "")
                            break;
                        else if ((nuevoCorreo.Replace(" ", String.Empty)).Length < nuevoCorreo.Length)
                            Console.Write("   !! El correo no puede tener espacios !!\n > ");
                        else if (((nuevoCorreo.Replace("@", String.Empty)).Length != nuevoCorreo.Length - 1))
                            Console.Write("   !! El correo debe tener un arroba !!\n > ");
                        else
                        {
                            per.Correo = nuevoCorreo;
                            break;
                        }
                    }

                    if (miBiblioteca.ModificarPeriodista(per))
                    {
                        Console.WriteLine("\n   Edicion completada con exito.\n   ");
                        Console.WriteLine(per.ToString());
                        Console.WriteLine("\n   Presione cualquier tecla para continuar.");
                        Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
                        Console.CursorVisible = false;
                    }
                    else
                    {
                        Console.CursorVisible = false;
                        Console.WriteLine("\n   No se realizo la modificacion.\n \n   Presione cualquier tecla para continuar.\n");
                    }

                    break;
                }
                catch (Exception ex)
                {
                    Console.CursorVisible = false;
                    Console.WriteLine("\n   " + ex.Message + "\n   Presione cualquier tecla para volver.");
                    break;
                }
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        // Crea y agrega una noticia internacional.
        static void AgregarInternacional(Biblioteca miBiblioteca)
        {

            string titulo, resumen, contenido, origen;
            int autor;
            DateTime fechaCreacion;
            Periodista periodistaAutor;

            try
            {
                Console.Title = "Agregar noticia internacional.";
                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~ NYT - Agregar noticia internacional ~~~~~~~~~~~~");

                if (miBiblioteca.CantidadPeriodistas() == 0)
                    throw new Exception("Debe agregar al menos un periodista para poder agregar una noticia.");

                Console.Write("\n   Ingrese el identificador del periodista que genera la noticia.\n");

                autor = NumeroValido(0, int.MaxValue);
                periodistaAutor = miBiblioteca.BuscarPeriodista(autor);
                if (periodistaAutor == null)
                    throw new Exception("No existe ningun periodista con el codigo " + autor + ".");

                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~ NYT - Agregar noticia internacional ~~~~~~~~~~~~\n");
                Console.WriteLine("   Periodista: " + periodistaAutor.Nombre + "\n");
                Console.Write("   Ingrese el pais de origen de la noticia.\n > ");
                origen = TextoValido(1, 56);

                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~ NYT - Agregar noticia internacional ~~~~~~~~~~~~\n");
                Console.WriteLine("   Periodista: " + periodistaAutor.Nombre);
                Console.WriteLine("   Pais de origen: " + origen + "\n");
                Console.Write("   Ingrese la fecha de creacion de la noticia (mes dia año).\n > ");
                fechaCreacion = FechaValida(DateTime.Now, false);

                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~ NYT - Agregar noticia internacional ~~~~~~~~~~~~\n");
                Console.WriteLine("   Periodista: " + periodistaAutor.Nombre);
                Console.WriteLine("   Pais de origen: " + origen);
                Console.WriteLine("   Fecha de creacion: " + fechaCreacion.ToString("MM/dd/yyyy") + "\n");
                Console.Write("   Ingrese el titulo de la noticia (Maximo 30 caracteres).\n > ");
                titulo = TextoValido(1, 30);

                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~ NYT - Agregar noticia internacional ~~~~~~~~~~~~\n");
                Console.WriteLine("   Periodista: " + periodistaAutor.Nombre);
                Console.WriteLine("   Pais de origen: " + origen);
                Console.WriteLine("   Fecha de creacion: " + fechaCreacion.ToString("MM/dd/yyyy"));
                Console.WriteLine("   Titulo: " + titulo + "\n");
                Console.Write("   Ingrese un resumen de la noticia (Maximo 100 caracteres).\n > ");
                resumen = TextoValido(1, 100);

                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~ NYT - Agregar noticia internacional ~~~~~~~~~~~~\n");
                Console.WriteLine("   Periodista: " + periodistaAutor.Nombre);
                Console.WriteLine("   Pais de origen: " + origen);
                Console.WriteLine("   Fecha de creacion: " + fechaCreacion.ToString("MM/dd/yyyy"));
                Console.WriteLine("   Titulo: " + titulo);
                Console.WriteLine("   Resumen: " + resumen + "\n");
                Console.Write("   Ingrese el contenido de la noticia.\n > ");
                contenido = TextoValido(1, int.MaxValue);

                Noticia miNoticia = new Internacional(titulo, resumen, contenido, fechaCreacion, periodistaAutor, origen);
                miBiblioteca.AgregarNoticia(miNoticia);

                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("~~~~~~~~~~~~~~~~~ NYT - Noticia agregada! ~~~~~~~~~~~~~~~~~~\n");
                Console.WriteLine(miBiblioteca.MostrarUltimaNoticia().ToString());
            }
            catch (Exception ex)
            {
                Console.CursorVisible = false;
                Console.WriteLine("\n   " + ex.Message);
            }
            Console.WriteLine("\n   Presione cualquier tecla para continuar.");
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        // Crea y agrega una noticia nacional.
        static void AgregarNacional(Biblioteca miBiblioteca)
        {
            string titulo, resumen, contenido, codigo;
            int autor;
            DateTime fechaCreacion;
            Periodista periodistaAutor;
            Seccion seccionNoticia;

            try
            {
                Console.Title = "Agregar noticia nacional.";
                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~~~~ NYT - Agregar noticia nacional ~~~~~~~~~~~~~~");

                if (miBiblioteca.CantidadPeriodistas() == 0)
                    throw new Exception("Debe agregar al menos un periodista para poder agregar una noticia.");
                if (miBiblioteca.CantidadSecciones() == 0)
                    throw new Exception("Debe agregar al menos una seccion para poder agregar una noticia.");


                Console.Write("\n   Ingrese el identificador del periodista que genera la noticia.\n");

                autor = NumeroValido(0, int.MaxValue);
                periodistaAutor = miBiblioteca.BuscarPeriodista(autor);
                if (periodistaAutor == null)
                    throw new Exception("No existe ningun periodista con el codigo " + autor + ".");

                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~~~~ NYT - Agregar noticia nacional ~~~~~~~~~~~~~~\n");
                Console.WriteLine("   Periodista: " + periodistaAutor.Nombre + "\n");
                Console.Write("   Ingrese la seccion de la noticia.\n > ");

                codigo = TextoIDSeccion(false);
                seccionNoticia = miBiblioteca.BuscarSeccion(codigo);
                if (seccionNoticia == null)
                    throw new Exception("No existe ninguna seccion con el codigo " + codigo + ".");

                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~~~~ NYT - Agregar noticia nacional ~~~~~~~~~~~~~~\n");
                Console.WriteLine("   Periodista: " + periodistaAutor.Nombre);
                Console.WriteLine("   Seccion: " + seccionNoticia.Nombre + "\n");
                Console.Write("   Ingrese la fecha de creacion de la noticia (mes dia año).\n > ");
                fechaCreacion = FechaValida(DateTime.Now, false);

                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~~~~ NYT - Agregar noticia nacional ~~~~~~~~~~~~~~\n");
                Console.WriteLine("   Periodista: " + periodistaAutor.Nombre);
                Console.WriteLine("   Seccion: " + seccionNoticia.Nombre);
                Console.WriteLine("   Fecha de creacion: " + fechaCreacion.ToString("MM/dd/yyyy") + "\n");
                Console.Write("   Ingrese el titulo de la noticia (Maximo 30 caracteres).\n > ");
                titulo = TextoValido(1, 30);

                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~~~~ NYT - Agregar noticia nacional ~~~~~~~~~~~~~~\n");
                Console.WriteLine("   Periodista: " + periodistaAutor.Nombre);
                Console.WriteLine("   Seccion: " + seccionNoticia.Nombre);
                Console.WriteLine("   Fecha de creacion: " + fechaCreacion.ToString("MM/dd/yyyy"));
                Console.WriteLine("   Titulo: " + titulo + "\n");
                Console.Write("   Ingrese un resumen de la noticia (Maximo 100 caracteres).\n > ");
                resumen = TextoValido(1, 100);

                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~~~~ NYT - Agregar noticia nacional ~~~~~~~~~~~~~~\n");
                Console.WriteLine("   Periodista: " + periodistaAutor.Nombre);
                Console.WriteLine("   Seccion: " + seccionNoticia.Nombre);
                Console.WriteLine("   Fecha de creacion: " + fechaCreacion.ToString("MM/dd/yyyy"));
                Console.WriteLine("   Titulo: " + titulo);
                Console.WriteLine("   Resumen: " + resumen + "\n");
                Console.Write("   Ingrese el contenido de la noticia.\n > ");
                contenido = TextoValido(1, int.MaxValue);

                Noticia miNoticia = new Nacional(titulo, resumen, contenido, fechaCreacion, periodistaAutor, seccionNoticia);
                miBiblioteca.AgregarNoticia(miNoticia);

                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("~~~~~~~~~~~~~~~~~ NYT - Noticia agregada! ~~~~~~~~~~~~~~~~~~\n");
                Console.WriteLine(miBiblioteca.MostrarUltimaNoticia().ToString());
            }
            catch (Exception ex)
            {
                Console.CursorVisible = false;
                Console.WriteLine("\n   " + ex.Message);
            }

            Console.WriteLine("\n   Presione cualquier tecla para continuar.");
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Acceso restringido ~~~~");
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        // Desplega en consola una lista de noticias.
        static void ListarNoticias(Biblioteca miBiblioteca)
        {
            Console.CursorVisible = false;
            List<Noticia> noticiasOrdenadas = miBiblioteca.ListadoNoticias();

            foreach (Noticia not in noticiasOrdenadas)
                Console.WriteLine(not.ToString() + "\n");

            Console.WriteLine("   Presione cualquier tecla para volver.\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Acceso restringido ~~~~");
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        // Desplega en consola todas las noticias que tengan una fecha posterior o igual a la indicada.
        static void ListarNoticias(Biblioteca miBiblioteca, DateTime fecha)
        {
            Console.CursorVisible = false;
            List<Noticia> noticiasEnFecha = miBiblioteca.ListadoNoticiasPorFecha(fecha);

            // Verificamos que haya al menos 1 noticia en la nueva lista.
            if (noticiasEnFecha.Count > 0)
                foreach (Noticia not in noticiasEnFecha)
                    Console.WriteLine(not.ToString() + "\n");
            else
                Console.WriteLine("   No hay noticias en esa fecha.\n");

            Console.WriteLine("   Presione cualquier tecla para volver.\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Acceso restringido ~~~~");
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        // Desplega en consola todas las noticias que pertenezcan a la seccion indicada.
        static void ListarNoticias(Biblioteca miBiblioteca, Seccion miSeccion)
        {
            List<Noticia> noticiasEnSeccion = miBiblioteca.ConsultaNoticiasPorSeccion(miSeccion);
            Console.CursorVisible = false;

            // Verifica que haya al menos 1 noticia en la nueva lista.
            if (noticiasEnSeccion.Count > 0)
                foreach (Noticia not in noticiasEnSeccion)
                    Console.WriteLine(not.ToString() + "\n");
            else
                Console.WriteLine("   No hay noticias en la seccion " + miSeccion.CodigoSeccion + "\n");

            Console.WriteLine("   Presione cualquier tecla para volver.\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Acceso restringido ~~~~");
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        // Devuelve un numero valido que este dentro del rango indicado.
        static int NumeroValido(int a, int b)
        {
            int numero;
            while (true)
            {
                Console.Write(" > ");
                try
                {
                    numero = Convert.ToInt32(Console.ReadLine());
                    // Controlamos que el numero este en el intervalo deseado.
                    if (numero < a || numero > b)
                        Console.WriteLine("   Debe escribir un numero entre " + a + " y " + b + ".");
                    else
                        break;
                }
                catch
                {
                    Console.WriteLine("   Debe ingresar un numero valido.");
                }
            }
            return (numero);
        }

        // Devuelve una cadena de tipo seccion (De 3 letras y en mayusculas) o una cadena vacia.
        static string TextoIDSeccion(bool aceptaVacio)
        {
            string codigo;

            while (true)
            {
                codigo = Console.ReadLine().ToUpper();
                if (aceptaVacio && codigo == "")
                    break;
                else if (codigo.Length == 3 && (char.IsLetter(Convert.ToChar(codigo.Substring(0, 1)))) && (char.IsLetter(Convert.ToChar(codigo.Substring(1, 1)))) && (char.IsLetter(Convert.ToChar(codigo.Substring(2, 1)))))
                    break;
                Console.WriteLine("   El codigo de la seccion debe tener 3 letras" + (aceptaVacio ? " <Enter para no cambiar>" : "."));
                Console.Write(" > ");
            }

            return codigo;
        }

        // Devuelve un texto con un maximo y minimo de caracteres
        static string TextoValido(int min, int max)
        {
            string texto = Console.ReadLine();
            string mensaje;

            // Determina que tipo de string debe ingresar el usuario
            if (min == int.MinValue)
                mensaje = "   El texto debe tener como maximo " + max + " letras.";
            else if (max == int.MaxValue)
                mensaje = "   El texto debe tener como minimo " + min + " letras.";
            else if (max == min)
                mensaje = "   El texto ingresado debe tener " + min + " letras.";
            else
                mensaje = "   El texto ingresado debe tener entre " + min + " y " + max + " letras.";

            while (true)
            {
                // Verificamos que cumpla las condiciones.
                if (texto.Trim().Length < min || texto.Trim().Length > max)
                    Console.WriteLine(mensaje);
                else
                    return texto;

                Console.Write(" > ");
                texto = Console.ReadLine();
            }
        }

        // Devuelve una fecha que no sea posterior a la fecha indicada,
        // Devuelve el maximo valor en caso de que se admitan vacios y el usuario no pase ninguna fecha.
        static DateTime FechaValida(DateTime maximo, bool admiteVacio)
        {
            string usuario;
            if(admiteVacio)
            {
                while (true)
                {
                    usuario = Console.ReadLine();
                    try
                    {
                        if (usuario == "")
                            return DateTime.MaxValue;

                        if (Convert.ToDateTime(usuario) > maximo)
                            Console.Write("   La fecha no puede ser posterior a " + maximo.ToShortDateString() + ".\n > ");
                        else
                            return Convert.ToDateTime(usuario);
                    }
                    catch
                    {
                        Console.Write("   La fecha debe ser de tipo (mes dia año).\n > ");
                    }
                }
            }
            else
            {
                while (true)
                {
                    usuario = Console.ReadLine();
                    try
                    {
                        if (Convert.ToDateTime(usuario) > maximo)
                            Console.Write("   La fecha no puede ser posterior a " + maximo.ToShortDateString() + ".\n > ");
                        else
                            return Convert.ToDateTime(usuario);
                    }
                    catch
                    {
                        Console.Write("   La fecha debe ser de tipo (mes dia año).\n > ");
                    }
                }
            }
        }

    }
}
