using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMercadao.Models
{
    public class RegistroDeCompra
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int InvestimentoId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Investimento Investimento { get; set; }
    }
}