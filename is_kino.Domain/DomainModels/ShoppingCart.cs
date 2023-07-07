using is_kino.Domain.Identity;

namespace is_kino.Domain.DomainModels
{
    public class ShoppingCart :BaseEntity
    {
       
        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        public virtual ICollection<TicketInShoppingCart> TicketsInShoppingCart { get; set; }
    }
}
