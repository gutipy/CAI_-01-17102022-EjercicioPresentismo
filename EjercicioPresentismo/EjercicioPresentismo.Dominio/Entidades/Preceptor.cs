using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPresentismo.Dominio.Entidades
{
    public class Preceptor : Persona
    {
        //Atributos
        private int _legajo;

        //Constructores
        public Preceptor(string nombre, string apellido, int legajo) : base(nombre, apellido)
        {
            _legajo = legajo;
        }

        //Propiedades
        public int Legajo { get => _legajo; }

        //Funciones-Métodos
        internal override string Display()
        {
            return String.Format("{0} - {1}", Apellido, _legajo);
        }
    }
}
