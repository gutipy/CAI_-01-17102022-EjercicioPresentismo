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
        private List<string> _fechas;

        //Constructores
        public Presentismo()
        {
            _preceptores = new List<Preceptor>();
            _alumnos = new List<Alumno>();
            _asistencias = new List<Asistencia>();
            _fechas = new List<string>();
        }

        //Propiedades
        public List<Preceptor> Preceptores { get => _preceptores; }
        public List<Alumno> Alumnos { get => _alumnos; }
        public List<Asistencia> Asistencias { get => _asistencias; }
        public List<string> Fechas { get => _fechas; }

        //Funciones-Métodos
        private bool AsistenciaRegistrada(string _fecha)
        {
            if (_asistencias.Find(a => a.FechaReferencia == _fecha) == null)
            {
                throw new AsistenciaInconsistenteException();
            }
            else
            {
                return _asistencias.Any(reg => reg.FechaReferencia == _fecha);
            }
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

        public void AgregarAsistencia(List<Asistencia> _asistencias)
        {
            if (_asistencias == null || _asistencias.Count == 0)
            {
                throw new Exception("No hay asistencias para agregar");
            }
    
            else if (_asistencias.Count != this.GetCantidadAlumnosRegulares())
            {
                throw new AsistenciaInconsistenteException();
            }
                
            else if (AsistenciaRegistrada(_asistencias.First().FechaReferencia))
            {
                throw new AsistenciaExistenteEseDiaException();
            }

            else
            {
                this._asistencias.AddRange(_asistencias);
            }    

            
        }
    }
}
