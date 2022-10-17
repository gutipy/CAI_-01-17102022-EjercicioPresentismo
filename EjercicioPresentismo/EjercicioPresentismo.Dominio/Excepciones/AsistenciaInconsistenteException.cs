using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPresentismo.Dominio.Excepciones
{
    public class AsistenciaInconsistenteException : Exception
    {
        public AsistenciaInconsistenteException() : base("En la fecha ingresada no se registró ninguna asistencia, intente nuevamente.")
        {

        }
    }
}
