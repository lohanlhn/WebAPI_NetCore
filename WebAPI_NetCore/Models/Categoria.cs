using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_NetCore.Models
{
    public class Categoria
    {
        //Boa Pratica
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
