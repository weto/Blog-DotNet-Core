namespace modelo_2.Repositories
{
    public interface IRegistroCivil
    {

        void GerarCertidaoNascimento(Pessoa pessoa);
        // Certidao nascimento

        void EmitirRegistroGeral(Pessoa pessoa);
        // Emitir RG

    }
}