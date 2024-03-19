using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNet_ProjetoClix.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [DisplayName("Nome Cliente")]
        [RegularExpression(@"^[A-Za-z\s]{1,40}$", ErrorMessage ="O nome deve conter apenas letras.")]
        public string NomeCliente { get; set; } = default!;

        public string? Referencia { get; set; }
    }
}