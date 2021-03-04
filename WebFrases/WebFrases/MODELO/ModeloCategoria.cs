using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFrases.MODELO
{
    public class ModeloCategoria
    {
        public int Id { get; set; }
        public String Nome { get; set; }

        public ModeloCategoria()
        {
            this.Id = 0;
            this.Nome = "";
        }
    }
}