using EFGetStarted.AspNetCore.NewDb.Models;

namespace Blog_DotNet_Core.Modelos.Extensions
{
    public static class Monetiza
    {
        public static double PageView(this Blog value)
        {
            return 1.0;
        }
        
    }
}