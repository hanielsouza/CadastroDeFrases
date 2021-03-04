using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFrases.MODELO
{
    public class Frase
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public int Autor { get; set; }
        public int Categoria { get; set; }

        public Frase()
        {
            this.Id = 0;
            this.Texto = "";
            this.Autor = 0;
            this.Categoria = 0;
        }
    }
}