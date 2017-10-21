using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMercadao.Models
{
    public class MainViewModel
    {
        public Atendente Atendente { get; set; }
        public Usuario Usuario { get; set; }
        public Mercado Mercado { get; set; }
        public Produto Produto { get; set; }
        public Noticia Noticia { get; set; }
        public Contato Contato { get; set; }
		public Investimento Investimento { get; set; }


		public IEnumerable<Atendente> Atendentes { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }
        public IEnumerable<Mercado> Mercados { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
        public IEnumerable<Noticia> Noticias { get; set; }
        public IEnumerable<Contato> Contatos { get; set; }
		public IEnumerable<Investimento> Investimentos { get; set; }

		public MainViewModel()
        {
            Usuario = new Usuario();
            Atendente = new Atendente();
            Mercado = new Mercado();
            Produto = new Produto();
            Noticia = new Noticia();
            Contato = new Contato();
			Investimento = new Investimento();
        }
    }
}