namespace is_kino.Domain.DomainModels
{
    public class Ticket :BaseEntity
    {
       
        public int SeatNum { get; set; }
        public DateTime Date { get; set; }
        public Guid MovieId { get; set; }

        public virtual Movie? Movie { get; set; }

        public int Price { get; set; }

        public virtual ICollection<TicketInShoppingCart>? TicketsInShoppingCart { get; set; }

        public IEnumerable<TicketInOrder>? TicketInOrders { get; set; }

    }
}
