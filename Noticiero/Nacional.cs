using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticiero
{
    public class Nacional : Noticia
    {
        Seccion miSeccion;

        public Seccion MiSeccion
        {
            get { return miSeccion; }
            set
            {
                if (value == null)
                    throw new Exception("La seccion no puede estar vacia.");
                miSeccion = value;
            }
        }

        public Nacional(string pTitulo, string pResumen, string pContenido, DateTime pFechaCreacion,Periodista pMiPeriodista, Seccion pMiSeccion)
            : base(pTitulo, pResumen, pContenido, pFechaCreacion, pMiPeriodista)
        {
            MiSeccion = pMiSeccion;
        }

        public override string ToString()
        {
            return "   Noticia N°" + CodigoNoticia + " [Nacional, " + FechaCreacion.ToShortDateString() + "]\n   " + MiSeccion.ToString() + "\n" + base.ToString();
        }
    }
}