using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPresentismo.Dominio.Entidades
{
    public sealed class AlumnoRegular : Alumno
    {
        //Atributos
        private string _email;

        //Constructores
        public AlumnoRegular(string nombre, string apellido, int registro, string email) : base(nombre, apellido, registro)
        {
            _email = email;
        }

        //Propiedades
        public string Email { get => _email; }

        //Funciones-Métodos

    }
}
