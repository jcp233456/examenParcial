using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenParcial
{
    internal class Reporte
    {
        string iddoctor;
        string idpaciente;
        DateTime fechacita;
        DateTime horacita;

        public string Iddoctor { get => iddoctor; set => iddoctor = value; }
        public string Idpaciente { get => idpaciente; set => idpaciente = value; }
        public DateTime Fechacita { get => fechacita; set => fechacita = value; }
        public DateTime Horacita { get => horacita; set => horacita = value; }
    }
}
