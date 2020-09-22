using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using WebAPI_NetCore.Validations;

namespace WebAPI_NetCore.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O nome deve ter entre  5 e 20 caracteres")]
        [PrimeiraLetraMaiuscula]
        public string Nome { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "A descrição deve ter no máximo {1} caracteres")]
        public string Descricao { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "O preço deve ter entre {1} e {2}")]
        public decimal Preco { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string ImageUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
