namespace DiaBet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        public Team()
        {
            this.Id = Guid.NewGuid().ToString();
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
        }

        public string Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string League { get; set; }

        [MaxLength(30)]
        public string Stadium { get; set; }

        public string LogoUrl { get; set; }

        [ForeignKey(nameof(Country))]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<Game> HomeGames { get; set; }

        public virtual ICollection<Game> AwayGames { get; set; }
    }
}
