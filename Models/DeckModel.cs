using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NotecardApp.Models
{
    public partial class DeckModel : DbContext
    {
        public DeckModel()
            : base("name=DeckModel")
        {
        }

        public virtual DbSet<Deck> Decks { get; set; }
        public virtual DbSet<Notecard> Notecards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deck>()
                .Property(x => x.Id)
                .IsRequired();

            modelBuilder.Entity<Deck>()
                .Property(x => x.Name)
                .IsRequired();
        }
    }
}
