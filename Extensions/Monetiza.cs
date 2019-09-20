using EFGetStarted.AspNetCore.NewDb.Models;

namespace Blog_DotNet_Core.Modelos.Extensions
{
    public static class Monetiza
    {
        public static double PageView(this Blog blog, int view, int tipo)
        {
            return view + tipo;
        }

        public static string Acessos(this Blog blog)
        {
            return "#### acessando sintax sugar 'Acessos' ####";
        }
        
    }
}