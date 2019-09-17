using System.ComponentModel.DataAnnotations;
using EFGetStarted.AspNetCore.NewDb.Models;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class Post
    {
        public int PostId { get; set; }

        // [Required(ErrorMessage = "Title não informado.")]
        // [StringLength(20, MinimumLength = 10, ErrorMessage = "Tamanho do Title não pode ser menor que 10 e maior que 20 letras.")]
        public string Title { get; set; }

        // [Required( ErrorMessage = "Content não informado." )]
        // [StringLength(400, MinimumLength = 200, ErrorMessage = "Tamanho do Content não pode ser menor que 200 e maior que 400 letras.")]
        public string Content { get; set; }

        // [Required(ErrorMessage = "Blog não informado.")]
        public int BlogId { get; set; }

        // [Required]
        public Blog Blog { get; set; }
    }
}