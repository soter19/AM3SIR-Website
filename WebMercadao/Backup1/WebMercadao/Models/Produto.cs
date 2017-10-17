using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMercadao.Models
{
    public class Produto
    {
        public string id { get; set; }
        public string nome { get; set; }
        public float preco { get; set; }

        public Produto(string id) {
            this.id = id;
            this.nome = "banana";
            this.preco = 1.20f;
        }

    }
}