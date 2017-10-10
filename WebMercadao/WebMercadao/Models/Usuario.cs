using System;
namespace WebMercadao.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }

        public Usuario()
        {
            
        }
    }
}
