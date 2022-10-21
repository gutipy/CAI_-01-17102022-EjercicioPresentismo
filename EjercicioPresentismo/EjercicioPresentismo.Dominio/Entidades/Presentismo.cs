using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EjercicioPresentismo.Dominio.Excepciones;

namespace EjercicioPresentismo.Dominio.Entidades
{
    public class Presentismo
    {
        //Atributos
        private List<Preceptor> _preceptores;
        private List<Alumno> _alumnos;
        private List<Asistencia> _asistencias;
        //private List<string> _fechas;

        //Constructores
        public Presentismo()
        {
            _preceptores = new List<Preceptor>();
            _alumnos = new List<Alumno>();
            _asistencias = new List<Asistencia>();
            //_fechas = new List<string>();

            _alumnos.Add(new AlumnoRegular("Carlos", "Juarez", 123, "cjua@gmail.com"));
            _alumnos.Add(new AlumnoRegular("Carla", "Jaime", 124, "cjai@gmail.com"));
            _alumnos.Add(new AlumnoOyente("Ramona", "Vals", 320));
            _alumnos.Add(new AlumnoOyente("Alejandro", "Medina", 321));

            _preceptores.Add(new Preceptor("Jorgelina", "Ramos", 5));

        }

        //Propiedades
        public List<Preceptor> Preceptores { get => _preceptores; }
        public List<Alumno> Alumnos { get => _alumnos; }
        public List<Asistencia> Asistencias { get => _asistencias; }
        //public List<string> Fechas { get => _fechas; }

        //Funciones-Métodos
        private bool AsistenciaRegistrada(string _fecha)
        {
            return _asistencias.Any(registro => registro.FechaReferencia == _fecha);
        }

        private int GetCantidadAlumnosRegulares()
        {
            //Declaración de variables
            int cantidadAlumnosRegulares = 0;

            if (_alumnos.Count == 0)
            {
                throw new SinAlumnosRegistradosException();
            }
            else
            {
                foreach (Alumno a in _alumnos)
                {
                    if (a is AlumnoRegular)
                    {
                        cantidadAlumnosRegulares++;
                    }
                }

                return cantidadAlumnosRegulares;
            }
        }

        public Preceptor GetPreceptorActivo()
        {
            return _preceptores.First();
        }

        public List<Alumno> GetListaAlumnos()
        {
            if (_alumnos.Count == 0)
            {
                throw new SinAlumnosRegistradosException();
            }
            else
            {
                return _alumnos;
            }
        }

        public void AgregarAsistencia(List<Asistencia> _asistenciasAAgregar, string _fecha)
        {
            if (_asistenciasAAgregar == null || _asistenciasAAgregar.Count == 0)
            {
                throw new Exception("No hay asistencias para agregar");
            }

            else if (_asistenciasAAgregar.Count != this.GetCantidadAlumnosRegulares())
            {
                throw new AsistenciaInconsistenteException();
            }

            else if (AsistenciaRegistrada(_asistenciasAAgregar.First().FechaReferencia))
            {
                throw new AsistenciaExistenteEseDiaException();
            }

            else
            {
                _asistencias.AddRange(_asistenciasAAgregar);
                //_fechas.Add(_fecha);
            }
        }

        public List<Asistencia> GetAsistenciasPorFecha(string _fecha)
        {
            //Declaración de variables
            List<Asistencia> _asistenciasPorFecha = new List<Asistencia>();

            if (_asistencias.Count == 0)
            {
                throw new Exception("No se encuentra ninguna asistencia registrada en el Sistema.");
            }

            else if (_asistencias.Find(a => a.FechaReferencia == _fecha) == null)
            {
                throw new Exception("No hay ninguna asistencia registrada en la fecha " + _fecha);
            }

            else
            {
                foreach (Asistencia a in _asistencias)
                {
                    if (a.FechaReferencia == _fecha)
                    {
                        _asistenciasPorFecha.Add(a);
                    }
                }
            }

            return _asistenciasPorFecha;
        }
    }
}
