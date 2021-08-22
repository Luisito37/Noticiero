using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticiero
{
    public class Internacional : Noticia
    {
        string origen;

        public string Origen
        {
            get { return origen; }
            set 
            {
                if (value.Length == 0)
                    throw new Exception("El origen no puede estar vacio.");
                origen = value; 
            }
        }

        public Internacional(string pTitulo, string pResumen, string pContenido, DateTime pFechaCreacion, Periodista pMiPeriodista, string pOrigen)
            : base(pTitulo, pResumen, pContenido, pFechaCreacion, pMiPeriodista)
        {
            Origen = pOrigen;
        }

        public override string ToString()
        {
            return "   Noticia N°" + CodigoNoticia + " [Internacional, " + Origen + ", " + FechaCreacion.ToShortDateString() + "]\n" + base.ToString();
        }
    }
}
