using System.ComponentModel.DataAnnotations;

namespace AspNet_ProjetoClix.Models
{
    public class Tipo 
    {
        [Key]
        public int Id { get; set; } 

        [StringLength(80, ErrorMessage="Descrição Inválida")]
        public string Descricao { get; set; } = default!;
    }
}