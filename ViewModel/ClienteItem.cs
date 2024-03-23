using AspNet_ProjetoClix.Models;

namespace AspNet_ProjetoClix.ViewModel
{
    public class ClienteItem
    {
        public Cliente Cliente { get; set; } = default!;
        public Item Item { get; set; } = default!; 
    }
}