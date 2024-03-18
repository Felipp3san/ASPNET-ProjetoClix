using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNet_ProjetoClix.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(80, ErrorMessage="Item 1 Inválido")]
        public string? Item1 { get; set; }

        [StringLength(80, ErrorMessage="Item 2 Inválido")]
        public string? Item2 { get; set; }

        [StringLength(80, ErrorMessage="Texto Inválido")]
        public string? Texto { get; set; }

        [DisplayName("ID do Cliente")]
        public int ClienteId { get; set; }

        [DisplayName("ID do Tipo")]
        public int TipoId { get; set; }
    }
}
