using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Produto.Models
{
    public class Fornecedor
    {
        [Key]
        public new int Id { get; set; }

        public string  Nome { get; set;}


    }
}
