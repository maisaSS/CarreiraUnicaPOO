using System;
using System.Collections.Generic;
using System.Text;


namespace projeto2.Models
{
    public class Conta 
    {
        public string Titular { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public string Senha { get; set; }

    }
}
