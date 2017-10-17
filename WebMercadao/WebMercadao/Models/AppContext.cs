﻿using System;
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

        public DbSet<Produto> Produtos { get; set; }

    }
}
