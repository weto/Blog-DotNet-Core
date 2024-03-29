﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly BloggingContext _bloggingContext;

        public BlogsController(BloggingContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }

        [HttpGet]
        public ActionResult<List<Blog>> todos()
        {
            return _bloggingContext.Blogs.ToList();
        }

        [HttpGet]
        public async Task<List<Blog>> pesquisarPorUrl()
        {
            // 1
            // var blogs = from blog in _bloggingContext.Blogs where blog.Url == "/teste/10" select blog;
            // return await blogs.ToListAsync();

            // 2
            // var blogs2 = await blogs.Where(b => b.Url == "/teste/10").ToListAsync();

            // 3
            var blogs3 = await _bloggingContext.Blogs.Where(blog => blog.Url == "/teste/0").ToListAsync();

            return blogs3;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Insert(int id)
        {
            _bloggingContext.Blogs.Add(new Blog()
            {
                BlogId = id,
                Url = "/teste/" + id
            });
            _bloggingContext.SaveChanges();

            return "OK";
        }

        [HttpPost]
        public ActionResult Teste([FromBody] Name id)
        {
            var palvras = new[] { "Casa", "Carro" };
            var vogais = new[] { 'a', 'e', 'i', 'o', 'u' };
            var resposta = palvras.Select(p => new
            {
                Palavra = p,
                PrimeiraLetra = p.First(),
                Tamanho = p.Count(),
                Vogais = p.ToLower().Count(c => vogais.Contains(c))
            });

            Console.WriteLine("Wellington");

            Console.WriteLine("Wellington Conceição");

            return new JsonResult(resposta)
            {
                StatusCode = 423
            };
        }

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
