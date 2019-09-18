using System.Collections.Generic;
using modelo_2.Modelos.Documento;

namespace workspace.Domain
{
    public class Pessoa
    {
        public string Nome { get; set; }

        public RegistroPessoaFisica CPF { get; set; }

        public ICollection<RegistroGeral> Identidades { get; set; }

    }
}