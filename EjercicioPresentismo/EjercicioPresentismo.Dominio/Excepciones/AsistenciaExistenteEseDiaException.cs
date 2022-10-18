using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPresentismo.Dominio.Excepciones
{
    public class AsistenciaExistenteEseDiaException : Exception
    {
        public AsistenciaExistenteEseDiaException() : base("ERROR! El día que intenta registrar la asistencia ya se encuentra registrado, intente nuevamente.")
        {

        }
    }
}
