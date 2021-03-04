using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFrases.MODELO
{
    public class ModeloFrase
    {
        public int Id { get; set; }
        public String Texto { get; set; }
        public int Autor { get; set; }
        public int Categoria { get; set; }

        public ModeloFrase()
        {
            this.Id = 0;
            this.Autor = 0;
            this.Categoria = 0;
            this.Texto = "";

        }
    }
}