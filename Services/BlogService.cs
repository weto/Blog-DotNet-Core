using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_DotNet_Core.Repositories;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog_DotNet_Core.Services
{
    public class BlogService : IBlogRepository
    {

        private readonly BloggingContext _bloggingContext;
        
        public BlogService(BloggingContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }

        public List<Blog> TodosBlogs()
        {
            return _bloggingContext.Blogs.ToList();
        }

        public async Task<List<Blog>> PesquisarPorUrl()
        {
            var blogs3 = await _bloggingContext.Blogs.Where(blog => blog.Url == "/teste/0").ToListAsync();
            return blogs3;
        }

        public async Task<Blog> pesquisarPorBlogID(int blogId)
        {
            return await _bloggingContext.Blogs.FirstAsync(blog => blog.BlogId == blogId);
        }

        public ActionResult<Blog> pesquisarPorBlogIDDois(int id)
        {
            var blog = _bloggingContext.Blogs.Find(id);

            return blog;
        }

        public ActionResult<string> Salvar(BlogParam blog)
        {
            _bloggingContext.Blogs.Add(new Blog()
            {
                BlogId = blog.Id,
                Url = blog.Url,
                Autor = blog.Autor
            });
            _bloggingContext.SaveChanges();

            return "OK";
        }

        public ActionResult<string> Editar(int id, BlogParam blog)
        {
            var blog1 = _bloggingContext.Blogs.First(f=> f.BlogId == id);
            blog1.Url = blog.Url;
            blog1.Autor = blog.Autor;
            _bloggingContext.SaveChanges();

            return "OK";
        }

        public ActionResult<bool> Delete(int id)
        {
            var blog1 = _bloggingContext.Blogs.Find(id);
            _bloggingContext.Blogs.Remove(blog1);
            _bloggingContext.SaveChanges();
            return true;
        }
    }
}