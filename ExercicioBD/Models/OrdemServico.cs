using ExemploBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioBD.Models
{
    public class OrdemServico
    {
        public int Numero { get; set; }
        public String DataSolicitacao { get; set; }
        public int PrazoEntrega { get; set; }
        public double Total { get; set; }
        public String Status { get; set; }
        public Cliente Cliente { get; set; }
    }
}