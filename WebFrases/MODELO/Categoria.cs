using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFrases.MODELO
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public Categoria()
        {
            this.Id = 0;
            this.Nome = "";
        }
    }
}