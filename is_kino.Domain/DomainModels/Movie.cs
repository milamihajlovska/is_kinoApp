namespace is_kino.Domain.DomainModels
{
    public class Movie :BaseEntity
    {
        

        public string Name { get; set; }
        public DateTime Duration { get; set; }

        public string Genre { get; set; }


        public virtual ICollection<Ticket>? Tickets { get; set; }

    }
}
