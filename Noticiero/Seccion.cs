using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticiero
{
    public class Seccion
    {
        string nombre, codigoSeccion;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("El nombre de la seccion no puede estar vacio.");
                nombre = value;
            }
        }

        public string CodigoSeccion
        {
            get { return codigoSeccion; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("El codigo de la seccion no puede estar en blanco.");
                else if (value.Length != 3)
                    throw new Exception("El codigo de la seccion debe tener 3 letras.");
                codigoSeccion = value.ToUpper();
            }
        }

        public Seccion(string pNombre, string pCodigoSeccion)
        {
            Nombre = pNombre;
            CodigoSeccion = pCodigoSeccion;
        }

        public override string ToString()
        {
            return "Seccion [" + CodigoSeccion + ", " + Nombre + "]";
        }
    }
}