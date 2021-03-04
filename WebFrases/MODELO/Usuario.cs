using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFrases.MODELO
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }


        public Usuario()
        {
            this.Id = 0;
            this.Nome = "";
            this.Email = "";
            this.Senha = "";
        }
    }
}