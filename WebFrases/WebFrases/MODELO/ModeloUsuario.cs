using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFrases.MODELO
{
    public class ModeloUsuario
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }

        public ModeloUsuario()
        {
            this.Id = 0;
            this.Nome = "";
            this.Email = "";
            this.Senha = "";
        }
    }
}