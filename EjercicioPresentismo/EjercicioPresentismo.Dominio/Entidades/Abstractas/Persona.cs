using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPresentismo.Dominio
{
    public abstract class Persona
    {
        //Atributos
        protected string _nombre;
        protected string _apellido;

        //Constructores
        public Persona(string nombre, string apellido)
        {
            _nombre = nombre;
            _apellido = apellido;
        }

        //Propiedades
        public string Nombre { get => _nombre; }
        public string Apellido { get => _apellido; }

        //Funciones-Métodos
        public override string ToString()
        {
            return this.Display();
        }

        internal abstract string Display();
    }
}
