using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticiero
{
    public class Periodista
    {
        string nombre, correo;
        int codigoPeriodista;

        public string Nombre
        {
            get { return nombre; }
            set 
            {
                if (value.Length == 0)
                    throw new Exception("El nombre no puede estar vacio.");
                nombre = value; 
            }
        }

        public string Correo
        {
            get { return correo; }
            set 
            {
                if ((value.Replace(" ", String.Empty)).Length < value.Length)
                    throw new Exception("El correo no puede tener espacios.");
                else if (((value.Replace("@", String.Empty)).Length != value.Length-1) || (value.Length == 0))
                    throw new Exception("Ingrese un correo de tipo valido.");
                correo = value; 
            }
        }

        public int CodigoPeriodista
        {
            get { return codigoPeriodista; }
            set 
            {
                if (value < 0)
                    throw new Exception("El codigo no puede ser negativo.");
                codigoPeriodista = value; 
            }
        }

        public Periodista(string pNombre, string pCorreo, int pCodigoPeriodista)
        {
            Nombre = pNombre;
            Correo = pCorreo;
            CodigoPeriodista = pCodigoPeriodista;
        }

        public override string ToString()
        {
            return "Periodista N°" + CodigoPeriodista + " [" + Nombre + ", " + Correo + "]";
        }
    }
}
