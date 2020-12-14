using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        [MaxLength(6)]
        public int Codigo { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        
        [Required]
        [MaxLength(10)]
        public double Preco { get; set; }
        
        [Required]
        [MaxLength(6)]
        public int Estoque { get; set; }
    }
}