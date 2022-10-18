using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPresentismo.InterfazGrafica
{
    public static class ValidacionesInputHelper
    {
        public static string FuncionValidacionOpcionMenuPrincipal(ref string opcion)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                opcion = Console.ReadLine();

                if (string.IsNullOrEmpty(opcion))
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }
                else if (opcion == "1" || opcion == "2" || opcion == "3")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("ERROR! La opción " + opcion + " no es una opción válida, intente nuevamente.");
                }
            } while (flag == false);

            return opcion;
        }

        public static bool FuncionValidacionFecha(ref string fecha, string campo)
        {
            bool flag = false;
            DateTime fechaValidada;

            if (!DateTime.TryParse(fecha, out fechaValidada))
            {
                Console.WriteLine("El campo " + campo + " debe tener un formato válido del tipo dd/mm/aaaa, intente nuevamente.");
            }
            else if (fechaValidada > DateTime.Now)
            {
                Console.WriteLine("La fecha ingresada no puede ser superior al día de hoy, intente nuevamente.");
            }
            else
            {
                flag = true;
                fecha = fechaValidada.ToString();
            }

            return flag;
        }
    }
}
