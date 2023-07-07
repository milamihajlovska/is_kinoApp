

using is_kino.Domain.DomainModels;
using System.Collections.Generic;


namespace is_kino.Domain.DTO
{
    public class AddToShoppingCartDto
    {
        public Ticket SelectedTicket { get; set; }
        public Guid TicketId { get; set; }
        public int Quantity  { get; set; }
    }
}
