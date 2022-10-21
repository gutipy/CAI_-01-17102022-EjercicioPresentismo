using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPresentismo.Dominio.Entidades
{
    public class Asistencia
    {
        //Atributos
        private string _fechaReferencia;
        private DateTime _fechaHoraReal;
        private Preceptor _preceptor;
        private Alumno _alumno;
        private bool _estaPresente;

        //Constructores
        public Asistencia(string fechaReferencia, Preceptor preceptor, Alumno alumno, bool estaPresente)
        {
            _fechaReferencia = fechaReferencia;
            _fechaHoraReal = DateTime.Now;
            _preceptor = preceptor;
            _alumno = alumno;
            _estaPresente = estaPresente;
        }

        //Propiedades
        public string FechaReferencia { get => _fechaReferencia; }

        //Funciones-Métodos
        public override string ToString()
        {
            return string.Format(
                "{0} {1} {2} está presente por {3} registrado el {4}",
                _fechaReferencia,
                _alumno,//.Display(),
                _estaPresente ? "SÍ" : "NO",
                _preceptor,
                _fechaHoraReal.ToString()
                )
                ;
        }
    }
}
