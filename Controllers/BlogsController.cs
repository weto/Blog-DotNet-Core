using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_DotNet_Core.Repositories;
using Blog_DotNet_Core.Services;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace modelo_2.Controllers
{
    public class Name
    {
        public int Id { get; set; }
    }
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogService;

        public BlogsController(IBlogRepository _bloggingContext)
        {
            _blogService = _bloggingContext;
        }

        [HttpGet]
        public ActionResult<List<Blog>> todos()
        {
            return _blogService.TodosBlogs();
        }

        [HttpGet]
        public async Task<List<Blog>> pesquisarPorUrl()
        {
            return await _blogService.PesquisarPorUrl();
        }

        [HttpGet("{blogId}")]
        public async Task<Blog> pesquisarPorBlogID(int blogId)
        {
            return await _blogService.pesquisarPorBlogID(blogId);
        }

        [HttpGet("{id}")]
        public ActionResult<Blog> pesquisarPorBlogIDDois(int id)
        {
            return _blogService.pesquisarPorBlogIDDois(id);
        }

        [HttpPost]
        public ActionResult<string> Salvar([FromBody] BlogParam blog)
        {
            _blogService.Salvar(blog);
            return "OK";
        }

        [HttpPut("{id}")]
        public ActionResult<string> Editar(int id, [FromBody] BlogParam blog)
        {
            _blogService.Editar(id, blog);
            return "OK";
        }

        [HttpDelete("{id}")]
        public ActionResult<Boolean> Delete(int id)
        {
            _blogService.Delete(id);
            return true;
        }


        // [HttpPost]
        // public ActionResult Teste([FromBody] Name id)
        // {
        //     var palvras = new[] { "Casa", "Carro" };
        //     var vogais = new[] { 'a', 'e', 'i', 'o', 'u' };
        //     var resposta = palvras.Select(p => new
        //     {
        //         Palavra = p,
        //         PrimeiraLetra = p.First(),
        //         Tamanho = p.Count(),
        //         Vogais = p.ToLower().Count(c => vogais.Contains(c))
        //     });

        //     Console.WriteLine("Wellington");

        //     Console.WriteLine("Wellington Conceição");

        //     return new JsonResult(resposta)
        //     {
        //         StatusCode = 423
        //     };
        // }

        // // GET api/values/5
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return "value";
        // }

        // POST api/values
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
