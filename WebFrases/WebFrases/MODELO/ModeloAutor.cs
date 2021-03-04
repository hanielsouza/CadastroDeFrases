using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFrases.MODELO
{
    public class ModeloAutor
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Foto { get; set; }

        public ModeloAutor()
        {
            this.Id = 0;
            this.Foto = "";
            this.Nome = "";
        }
    }
}