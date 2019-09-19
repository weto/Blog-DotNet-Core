using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog_DotNet_Core.Repositories
{
    
    public interface IBlogRepository
    {
         List<Blog> TodosBlogs();

         Task<List<Blog>> PesquisarPorUrl();

         Task<Blog> pesquisarPorBlogID(int blogId);

         ActionResult<Blog> pesquisarPorBlogIDDois(int id);

         ActionResult<string> Salvar(BlogParam blog);

         ActionResult<string> Editar(int id, BlogParam blog);

         ActionResult<Boolean> Delete(int id);


    }
}