using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NotecardApp.Models
{
    public partial class NotecardModel : DbContext
    {
        public NotecardModel()
            : base("name=NotecardModel")
        {
        }

        public virtual DbSet<Deck> Decks { get; set; }
        public virtual DbSet<Notecard> Notecards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notecard>()
                .Property(x => x.Id)
                .IsRequired();

            modelBuilder.Entity<Notecard>()
                .Property(x => x.Question)
                .IsRequired();

            modelBuilder.Entity<Notecard>()
                .Property(x => x.Answer)
                .IsRequired();

            modelBuilder.Entity<Notecard>()
                .HasOptional(x => x.Deck)
                .WithMany(x => x.Notecards)
                .HasForeignKey(x => x.DeckId);

        }
    }
}
