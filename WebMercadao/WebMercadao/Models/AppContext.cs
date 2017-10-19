using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebMercadao.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("mercadao")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Atendente> Atendentes { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Contato> Contatos { get; set; }

    }
}
