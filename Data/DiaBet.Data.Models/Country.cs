namespace DiaBet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public Country()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Teams = new HashSet<Team>();
        }

        public string Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public string FlagUrl { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
