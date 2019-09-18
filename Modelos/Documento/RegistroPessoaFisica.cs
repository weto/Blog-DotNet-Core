using System;

namespace modelo_2.Modelos.Documento
{
    public class RegistroPessoaFisica
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public Pessoa pessoa { get; set; }

    }
}