using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Produto.Models
{
    public class Produto
    {
        [Key]
        public new int Id { get; set;}

        public string Name { get; set;}
        
        public double Value { get; set;}

        public string Brand { get; set;}


        [ForeignKey("Fornecedor")]
        public int FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }





    }
}
