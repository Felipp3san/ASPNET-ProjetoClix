using AspNet_ProjetoClix.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNet_ProjetoClix.ViewModel
{
    public class ClientesItems
    {
        public SelectList Clientes { get; set; } = default!;
        public ICollection<Item> Items { get; set; } = default!;    
        public ICollection<Tipo> Tipos { get; set; } = default!; 
    }
}