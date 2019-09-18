using System;

namespace modelo_2.Modelos.Documento
{
    public class RegistroGeral
    {
        public string NumeroInscricao { get; set; }

        public DateTime DataExpedicao { get; set; }

        public int Via { get; set; }

        public Pessoa pessoa { get; set; }

    }
}