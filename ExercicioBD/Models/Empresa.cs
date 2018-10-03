using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioBD.Models
{
    public class Empresa
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}