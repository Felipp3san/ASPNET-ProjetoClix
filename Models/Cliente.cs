using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNet_ProjetoClix.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome Cliente")]
        [StringLength(80, ErrorMessage="Nome Inválido")]
        public string NomeCliente { get; set; } = default!;

        [StringLength(80, ErrorMessage="Referência Inválida")]
        public string? Referencia { get; set; }
    }
}