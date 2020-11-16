namespace DiaBet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        public Game()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Bets = new HashSet<Bet>();
        }

        public string Id { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(HomeTeam))]
        public string HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        [ForeignKey(nameof(AwayTeam))]
        public string AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }

        [ForeignKey(nameof(Result))]
        public string ResultId { get; set; }

        public virtual Result Result { get; set; }

        [ForeignKey(nameof(Odds))]
        public string OddsId { get; set; }

        public virtual Odds Odds { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
