using is_kino.Domain.Identity;

namespace is_kino.Domain.DomainModels
{
    public class Order :BaseEntity
    {
      

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public IEnumerable<TicketInOrder> TicketInOrders { get; set; }

    }
}
