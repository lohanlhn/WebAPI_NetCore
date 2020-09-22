using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_NetCore.Context;
using WebAPI_NetCore.Filters;
using WebAPI_NetCore.Models;
using WebAPI_NetCore.Services;

namespace WebAPI_NetCore.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;        
        public ProdutosController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet("saudacao/{nome}")]
        public ActionResult<string> GetSaudacao([FromServices] IMeuServico meuServico, string nome)
        {
            return meuServico.Saudacao(nome);
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAsync()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}", Name = "ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.ProdutoId == id);

            if(produto == null)
            {
                return NotFound();
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _context.Produtos.Find(id);

            if(produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return produto;
        }
    }
}
