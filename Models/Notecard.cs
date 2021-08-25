namespace NotecardApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notecard
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public string Hint { get; set; }

        public int DeckId { get; set; }

        public virtual Deck Deck { get; set; }
    }
}
