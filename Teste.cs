using System;

namespace modelo_2
{
    public interface IName
    {
        string GetNome();
    }

    public class Pessoa : IName
    {
        private readonly string _nome;
        public Pessoa(string nome)
        { 
            _nome = nome;
        }

        public string GetNome()
        {
            return _nome;
        }
    }

    public class Teste<T> where T : IName
    {
        private readonly T _valor;

        public Teste(T valor)
        {
            _valor = valor;
        }

        public void Imprime()
        {
            Console.WriteLine(_valor.GetNome());
        }
    }
}