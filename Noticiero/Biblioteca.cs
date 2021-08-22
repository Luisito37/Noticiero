using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticiero
{
    public class Biblioteca
    {
        List<Noticia> noticias;
        List<Periodista> periodistas;
        List<Seccion> secciones;

        public Biblioteca()
        {
            noticias = new List<Noticia>();
            periodistas = new List<Periodista>();
            secciones = new List<Seccion>();
        }

        #region Operaciones de Periodistas.
        // Buscamos un periodista en nuestra coleccion de periodistas.
        public Periodista BuscarPeriodista(int codigoPeriodista)
        {
            foreach (Periodista periodista in periodistas)
                if (periodista.CodigoPeriodista == codigoPeriodista)
                    return periodista;
            return null;
        }

        // Agregamos un periodista a nuestra coleccion de periodistas.
        public bool AgregarPeriodista(Periodista miPeriodista)
        {
            // Primero verificamos que el periodista no fue agregado anteriorimente.
            if (BuscarPeriodista(miPeriodista.CodigoPeriodista) != null)
                throw new Exception("Ya existe un periodista con el codigo " + miPeriodista.CodigoPeriodista + ".");

            periodistas.Add(miPeriodista);
            return true;
        }

        // Eliminamos un periodista de nuestra coleccion de periodistas.
        public bool EliminarPeriodista(Periodista miPeriodista)
        {
            // Primero verificamos que el periodista no tenga noticias vinculadas.
            foreach (Noticia not in noticias)
                if (not.MiPeriodista == miPeriodista)
                    throw new Exception("No se pueden eliminar periodistas con noticias vinculadas.");

            foreach (Periodista per in periodistas)
                if (per == miPeriodista)
                {
                    periodistas.Remove(per);
                    return true;
                }

            return false;
        }

        // Modificamos un periodista de nuestra coleccion de periodistas.
        public bool ModificarPeriodista(Periodista miPeriodista) 
        {
            bool eliminado = false;
            foreach (Periodista per in periodistas)
                if (per == miPeriodista)
                {
                    periodistas.Remove(per);
                    eliminado = true;
                    break;
                }

            if (eliminado)
                return (AgregarPeriodista(miPeriodista));
            else
                return false;
        }

        // Devolvemos la cantidad de periodistas que hay en nuestra coleccion de periodistas.
        public int CantidadPeriodistas()
        {
            return periodistas.Count;
        }
        #endregion


        #region Operaciones de Secciones.
        // Buscamos una seccion en nuestra coleccion de secciones.
        public Seccion BuscarSeccion(string CodigoSeccion)
        {
            foreach (Seccion seccion in secciones)
                if (seccion.CodigoSeccion == CodigoSeccion)
                    return seccion;

            return null;
        }

        // Agregamos una seccion a nuestra coleccion de secciones.
        public bool AgregarSeccion(Seccion miSeccion)
        {
            // Primero verificamos que la seccion no fue agregada anteriormente.
            if (BuscarSeccion(miSeccion.CodigoSeccion) != null)
                throw new Exception("Ya existe una seccion con el codigo " + miSeccion.CodigoSeccion + ".");

            secciones.Add(miSeccion);
            return true;
        }

        // Eliminamos una seccion de nuestra coleccion de secciones.
        public bool EliminarSeccion(Seccion miSeccion)
        {
            // Primero verificamos que la seccion no tenga noticias vinculadas.
            foreach(Noticia not in noticias)
                if (not is Nacional && ((Nacional)not).MiSeccion == miSeccion)
                    throw new Exception("No se pueden eliminar secciones con noticias vinculadas.");

            foreach (Seccion seccion in secciones)
                if ( seccion == miSeccion)
                {
                    secciones.Remove(seccion);
                    return true;
                }

            return false;
        }

        // Modificamos una seccion de nuestra coleccion de secciones.
        public bool ModificarSeccion(Seccion miSeccion)
        {
            bool eliminado = false;
            foreach (Seccion sec in secciones)
                if (sec == miSeccion)
                {
                    secciones.Remove(sec);
                    eliminado = true;
                    break;
                }

            if (eliminado)
                return (AgregarSeccion(miSeccion));
            else
                return false;
        }

        // Devolvemos la cantidad de secciones que hay en nuestra coleccion de secciones.
        public int CantidadSecciones()
        {
            return secciones.Count;
        }
        #endregion


        #region Operaciones de Noticias.
        // Buscamos una noticia en nuestra coleccion de noticias.
        public Noticia BuscarNoticia(int identificador)
        {
            foreach (Noticia noticia in noticias)
                if (noticia.CodigoNoticia == identificador)
                    return noticia;

            return null;
        }

        // Agregamos una noticia a nuestra coleccion de noticias.
        public bool AgregarNoticia(Noticia miNoticia)
        {
            noticias.Add(miNoticia);
            return true;
        }

        // Devolvemos la ultima noticia agregada a nuestra coleccion de noticias.
        public Noticia MostrarUltimaNoticia()
        {
            if (noticias.Count == 0)
                return null;
            return noticias[noticias.Count-1];
        }

        // Devolvemos la cantidad de noticias en nuestra coleccion de noticias.
        public int CantidadNoticias()
        {
            return noticias.Count;
        }
        #endregion


        #region Operaciones de ordenamiento.
        // Devolvemos una copia de la lista recibida ordenada por fecha de creacion.
        private List<Noticia> OrdenarPorFecha(List<Noticia> listaOriginal)
        {
            List<Noticia> copia = new List<Noticia>();

            foreach (Noticia noticia in listaOriginal)
                copia.Add(noticia);

            Noticia aux;
            
            // Algoritmo de ordenacion por insercion
            // Este for va del segundo al último
            for (int i = 1; i < copia.Count; i++)
            {
                int j = i;

                // Si j no es cero y vector[j] es menor que vector[j - 1] los intercambiamos             
                while ((j > 0) && (copia[j].FechaCreacion < copia[j - 1].FechaCreacion))
                {
                    aux = copia[j];
                    copia[j] = copia[j - 1];
                    copia[j - 1] = aux;
                    j--;
                }
                // En cada ciclo se va insertando el valor en el lugar que le corresponde, con respecto a los anteriores
            }
            return copia;
        }

        // Devolvemos una copia de nuestra coleccion de noticias ordenada por fecha.
        public List<Noticia> ListadoNoticias()
        {
            return OrdenarPorFecha(noticias);
        }

        // Devolvemos una lista de las noticias que estan en nuestra coleccion de noticias a partir de una fecha.
        public List<Noticia> ListadoNoticiasPorFecha(DateTime fecha)
        {
            List<Noticia> noticiasEnFecha = new List<Noticia>();

            foreach (Noticia noticia in noticias)
                if (noticia.FechaCreacion.Date == fecha.Date)
                    noticiasEnFecha.Add(noticia);

            return OrdenarPorFecha(noticiasEnFecha);
        }

        // Devolvemos una lista de las noticias que estan en nuestra coleccion de noticias con la misma seccion.
        public List<Noticia> ConsultaNoticiasPorSeccion(Seccion seccion)
        {
            List<Noticia> noticiasEnSeccion = new List<Noticia>();

            foreach (Noticia noticia in noticias)
                if (noticia is Nacional)
                    if (((Nacional)noticia).MiSeccion == seccion)
                        noticiasEnSeccion.Add(noticia);

            return OrdenarPorFecha(noticiasEnSeccion);
        }
        #endregion
    }
}
