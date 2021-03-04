using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFrases.MODELO
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }

        public Autor()
        {
            this.Id = 0;
            this.Foto = "";
            this.Nome = "";
        }


    }
}