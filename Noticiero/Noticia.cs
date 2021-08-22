using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticiero
{
    public abstract class Noticia
    {
        string titulo, resumen, contenido;
        int codigoNoticia;
        DateTime fechaCreacion;

        static int id = 0;

        Periodista miPeriodista;

        public static int ID
        {
            get { return id; }
        }

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set
            {
                if (value > DateTime.Now)
                    throw new Exception("La fecha no puede ser a futuro.");
                fechaCreacion = value;
            }
        }

        public string Titulo
        {
            get { return titulo; }
            set
            {
                if (value.Length > 30)
                    throw new Exception("El titulo debe tener como maximo 30 caracteres.");
                else if (value.Length == 0)
                    throw new Exception("El titulo no puede estar vacio.");
                titulo = value;
            }
        }

        public string Resumen
        {
            get { return resumen; }
            set
            {
                if (value.Length > 100)
                    throw new Exception("El resumen debe tener como maximo 100 caracteres.");
                else if (value.Length == 0)
                    throw new Exception("El resumen no puede estar vacio.");
                resumen = value;
            }
        }

        public string Contenido
        {
            get { return contenido; }
            set 
            {
                if (value.Length == 0)
                    throw new Exception("El contenido no puede estar vacio.");
                contenido = value; 
            }
        }

        public Periodista MiPeriodista
        {
            get { return miPeriodista; }
            set
            {
                miPeriodista = value ?? throw new Exception("El periodista no puede estar vacio.");
            }
        }

        public int CodigoNoticia
        {
            get { return codigoNoticia; }
        }

        public Noticia(string pTitulo, string pResumen, string pContenido, DateTime pFechaCreacion, Periodista pMiPeriodista)
        {
            id++;

            Titulo = pTitulo;
            Resumen = pResumen;
            Contenido = pContenido;
            FechaCreacion = pFechaCreacion;
            MiPeriodista = pMiPeriodista;
            codigoNoticia = ID;
        }

        public override string ToString()
        {
            return "   " + miPeriodista.ToString() + "\n      Titulo: " + Titulo + "\n      Resumen: " + Resumen + "\n      Contenido: " + Contenido;
        }
    }
}
