using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioBD.Models
{
    public class Servico
    {
        public int Codigo { get; set; }
        public String Nome { get; set; }
        public double Valor { get; set; }
        public int TempoMedio { get; set; }

    }
}