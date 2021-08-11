using Api_Produto.Context;
using Api_Produto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Api_Produto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {   
        private readonly ProdutoContext _db;
        public ProdutoController(ProdutoContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            var produto = _db.Produtos.ToList();
            _db.Produtos.Include(x => x.Fornecedor).ToList();
            return produto;
        }

        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            var produto = _db.Produtos.Find(id);
            return produto;
        }
       
        [HttpPost]
        public void Post([FromBody] Produto obj)
        {
            _db.Produtos.Add(obj);
            _db.SaveChanges();
            
        }

    
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Produto obj)
        {
            _db.Produtos.Update(obj);
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj = _db.Produtos.Find(id);
            _db.Produtos.Remove(obj);
            _db.SaveChanges();

        }
    }
}
