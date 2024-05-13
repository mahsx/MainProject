using batch3.Models;

namespace batch3.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> List { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}