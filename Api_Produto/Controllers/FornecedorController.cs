using Api_Produto.Context;
using Api_Produto.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Api_Produto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {

        private readonly ProdutoContext _db;
        public FornecedorController(ProdutoContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<Fornecedor> Get()
        {
            var fornecedor = _db.Fornecedores.ToList();
            return fornecedor;
        }

        
        [HttpGet("{id}")]
        public Fornecedor Get(int id)
        {
            var fornecedor = _db.Fornecedores.Find(id);
            return fornecedor;
        }


        [HttpPost]
        public void Post([FromBody] Fornecedor obj)
        {
            _db.Fornecedores.Add(obj);
            _db.SaveChanges();

        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Fornecedor obj)
        {
            _db.Fornecedores.Update(obj);
            _db.SaveChanges();
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj = _db.Fornecedores.Find(id);
            _db.Fornecedores.Remove(obj);
            _db.SaveChanges();

        }
    }
}
