using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPresentismo.Dominio.Entidades
{
    public abstract class Alumno : Persona
    {
        //Atributos
        private int _registro;

        //Constructores
        public Alumno(string nombre, string apellido, int registro) : base(nombre, apellido)
        {
            _registro = registro;
        }

        //Propiedades
        public int Registro { get => _registro; }

        //Funciones-Métodos
        internal override string Display()
        {
            return String.Format("{0} ({1})", Nombre, _registro);
        }
    }
}
