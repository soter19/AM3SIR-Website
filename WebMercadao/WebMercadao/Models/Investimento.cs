using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMercadao.Models
{
	public class Investimento
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Descricao { get; set; }
		public float Valor { get; set; }
		public int Quantidade { get; set; }
	}
}