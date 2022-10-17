using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPresentismo.Dominio.Excepciones
{
    public class SinAlumnosRegistradosException : Exception
    {
        public SinAlumnosRegistradosException() : base("No se encuentran alumnos registrados en el Sistema, intente nuevamente.")
        {

        }
    }
}
