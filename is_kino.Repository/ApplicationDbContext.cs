using is_kino.Domain.DomainModels;
using is_kino.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace is_kino.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Movie> Movies { get; set; } 
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TicketInShoppingCart> TicketsInShoppingCart { get; set; }

        public virtual DbSet<TicketInOrder> TicketInOrders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }
       

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ticket>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Movie>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            //builder.Entity<TicketInShoppingCart>()
            //    .HasKey(t => new { t.TicketId, t.ShoppingCartId });

            builder.Entity<TicketInShoppingCart>()
              .HasOne(t => t.Ticket)
              .WithMany(t => t.TicketsInShoppingCart)
              .HasForeignKey(t => t.ShoppingCartId);

            builder.Entity<TicketInShoppingCart>()
              .HasOne(t => t.ShoppingCart)
              .WithMany(t => t.TicketsInShoppingCart)
              .HasForeignKey(t => t.TicketId);

            builder.Entity<ShoppingCart>()
                .HasOne<ApplicationUser>(t => t.Owner)
                .WithOne(t => t.UserCart)
                .HasForeignKey<ShoppingCart>(t => t.OwnerId);

            builder.Entity<Ticket>()
                .HasOne(t => t.Movie) // Ticket has one Movie
                .WithMany(t => t.Tickets)          // Movie can have many Tickets
                .HasForeignKey(t => t.MovieId); // Foreign key property in Ticket model

            //builder.Entity<TicketInOrder>()
            //   .HasKey(t => new { t.TicketId, t.OrderId });

            builder.Entity<TicketInOrder>()
              .HasOne(t => t.OrderedTicket)
              .WithMany(t => t.TicketInOrders)
              .HasForeignKey(t => t.OrderId);

            builder.Entity<TicketInOrder>()
              .HasOne(t => t.UserOrder)
              .WithMany(t => t.TicketInOrders)
              .HasForeignKey(t => t.TicketId);


        }

    }
}