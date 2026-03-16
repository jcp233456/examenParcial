using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenParcial
{
    internal class Doctor
    {
        string id;
        string nombre;
        string especialidad;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
    }
}
