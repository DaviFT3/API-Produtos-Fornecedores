using Api_Produto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Produto.Context
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext (DbContextOptions<ProdutoContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set;}

        public DbSet<Fornecedor> Fornecedores { get; set;}

        
    }
}
