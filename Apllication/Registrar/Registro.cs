using modelo_2.Repositories;

namespace modelo_2.Apllication.Registrar
{
    public class Registro<T> where T : IRegistroCivil
    {
        public readonly T _registro;

        public readonly Pessoa _pessoa;

        public Registro(Pessoa pessoa, T registro)
        {
            _pessoa = pessoa;
            _registro = registro;
        }

        public void RegistrarNascimento()
        {
            _registro.GerarCertidaoNascimento(_pessoa);
            _registro.EmitirRegistroGeral(_pessoa);
        }
    }
}