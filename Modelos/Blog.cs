using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class Blog
    {
        public int BlogId { get; set;}

        [Required( ErrorMessage = "Url não informado." )]
        public string Url { get; set;}

        // [Required( ErrorMessage = "Autor não informado." )]
        // [StringLength(50, MinimumLength = 3, ErrorMessage = "Tamanho do Autor não pode ser menor que 3 e maior que 8 letras.")]
        public string Autor { get; set;}

        public ICollection<Post> Posts { get; set; }
    }
}