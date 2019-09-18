using System;
using modelo_2.Repositories;

namespace modelo_2.Services
{
    public class RegistroCivil : IRegistroCivil
    {

        public readonly Pessoa _pessoa;

        public RegistroCivil(Pessoa pessoa)
        {
            _pessoa = pessoa;
        }

        public void EmitirRegistroGeral(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public void GerarCertidaoNascimento(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }
    }
}