using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Walmart.Models
{
    public class Cidade
    {
        //Entidade que espelha a tabela Cidade
        [Required]
        public int CodCidade { get; set; }
        public int CodEstado { get; set; }
        public string Nome { get; set; }
        public bool Capital { get; set; }
    }
}