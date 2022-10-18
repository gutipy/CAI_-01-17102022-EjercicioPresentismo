using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPresentismo.InterfazGrafica
{
    public static class MenuHelper
    {
        public static void OpcionesMenuPrincipal()
        {
            Console.WriteLine(
                "¡Bienvenido al gestor de Presentismo! Seleccione una opción:" + Environment.NewLine +
                "1 - Tomar asistencia" + Environment.NewLine +
                "2 - Mostrar asistencia" + Environment.NewLine +
                "3 - Salir"
                )
                ;
        }
    }
}
