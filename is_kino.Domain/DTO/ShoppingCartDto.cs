

using is_kino.Domain.DomainModels;
using System.Collections.Generic;


namespace is_kino.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<TicketInShoppingCart>? Tickets { get; set; }

        public double TotalPrice { get; set; }
    }
}
