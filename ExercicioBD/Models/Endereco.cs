using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploBD.Models.DAO
{
    public class Endereco
    {
        public int Cod { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public Cliente Cliente { get; set; }
    }
}