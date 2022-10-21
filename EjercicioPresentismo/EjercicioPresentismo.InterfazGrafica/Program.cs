using EjercicioPresentismo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPresentismo.InterfazGrafica
{
    public class Program
    {
        private static Presentismo _presentismo;

        static Program()
        {
            _presentismo = new Presentismo();
        }
        static void Main(string[] args)
        {
            //Declaración de variables
            bool _consolaActiva = true;
            string _opcionMenu = "";

            Preceptor preceptorActivo = _presentismo.GetPreceptorActivo();

            try
            {
                while (_consolaActiva)
                {
                    //Despliego en pantalla las opciones para que el usuario decida
                    MenuHelper.OpcionesMenuPrincipal();

                    //Se valida que la opcion ingresada no sea vacío y/o distinta de las opciones permitidas
                    ValidacionesInputHelper.FuncionValidacionOpcionMenuPrincipal(ref _opcionMenu);

                    //Estructura condicional para controlar el flujo del programa
                    switch (_opcionMenu)
                    {
                        case "1":
                            //Tomo la asistencia
                            TomarA(preceptorActivo);
                            break;

                        case "2":
                            //Muestro la asistencia
                            MostrarA();
                            break;

                        case "3":
                            //Salgo del programa
                            Salir();
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static void TomarA(Preceptor preceptor)
        {
            //Declaración de variables
            string _fecha;
            bool _flag;
            List<Alumno> _alumnosPresentes = new List<Alumno>();
            string _estaPresente;
            List<Asistencia> _asistencias = new List<Asistencia>();

            try
            {
                //Permito al usuario ingresar la fecha a tomar la asistencia
                do
                {
                    Console.WriteLine("Ingrese la fecha (en formato yyyy-mm-dd) sobre la cual va a tomar asistencia:");
                    _fecha = Console.ReadLine();
                    _flag = ValidacionesInputHelper.FuncionValidacionFecha(ref _fecha, "Fecha de asistencia");

                } while (_flag == false);

                //Muestro el listado de alumnos donde se debe indicar solo si está presente
                _alumnosPresentes = _presentismo.GetListaAlumnos();

                foreach (Alumno a in _alumnosPresentes)
                {
                    if (a is AlumnoRegular)
                    {
                        bool resp = false;

                        do
                        {
                            Console.WriteLine("{0} ({1}) está presente? S/N", a.Nombre, a.Registro);
                            _estaPresente = Console.ReadLine();
                            _flag = ValidacionesInputHelper.FuncionValidacionOpcionSoN(_estaPresente, "Estado alumno");

                        } while (_flag == false);
                        

                        if (_estaPresente == "S")
                        {
                            resp = true;
                        }

                        Asistencia _asistenciaAAgregar = new Asistencia(_fecha, preceptor, a, resp);
                        _asistencias.Add(_asistenciaAAgregar);
                    }

                    else
                    {
                        Console.WriteLine("El alumno {0} ({1}) es oyente", a.Nombre, a.Registro);
                    }
                }

                _presentismo.AgregarAsistencia(_asistencias, _fecha);

                Console.WriteLine("Presione Enter para elegir otra opción");

                Console.ReadKey();
                Console.Clear();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void MostrarA()
        {
            //Declaración de variables
            string _fecha;
            bool _flag;
            List<Asistencia> _asistenciasPorFecha = new List<Asistencia>();
            string _resultado = "";

            try
            {
                //Permito al usuario ingresar la fecha a tomar la asistencia
                do
                {
                    Console.WriteLine("Ingrese la fecha (en formato yyyy-mm-dd) sobre la cual quiere ver la asistencia:");
                    _fecha = Console.ReadLine();
                    _flag = ValidacionesInputHelper.FuncionValidacionFecha(ref _fecha, "Fecha de asistencia");

                } while (_flag == false);

                _asistenciasPorFecha = _presentismo.GetAsistenciasPorFecha(_fecha);

                foreach (Asistencia a in _asistenciasPorFecha)
                {
                    _resultado += Environment.NewLine + a.ToString();
                }

                Console.WriteLine("El listado de asistencia de alumnos para la fecha " + _fecha + " es: " + Environment.NewLine + _resultado);

                Console.WriteLine("Presione Enter para elegir otra opción");

                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }

        public static void Salir()
        {
            Console.WriteLine("Usted ha salido del gestor de la facultad, presione Enter");
            Console.ReadKey();

            Environment.Exit(0);
        }
    }
    
}
