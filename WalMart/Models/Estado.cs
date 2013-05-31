using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Walmart.Models
{
    public class Estado
    {
        //Entidade espelho da tabela ESTADO
        [Required]
        public int CodEstado { get; set; }
        public string Pais { get; set; }
        public string Nome { get; set; }
        [MaxLength(2), Required]
        public string Sigla { get; set; }
        public string Regiao { get; set; }
    }
}