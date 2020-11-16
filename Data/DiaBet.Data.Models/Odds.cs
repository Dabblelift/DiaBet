namespace DiaBet.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Odds
    {
        public Odds()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [ForeignKey(nameof(Game))]
        public string GameId { get; set; }

        public Game Game { get; set; }

        public double HomeWinOdds { get; set; }

        public double DrawOdds { get; set; }

        public double AwayWinOdds { get; set; }

        public double OverOdds { get; set; }

        public double UnderOdds { get; set; }

        public double BothTeamsToScoreOdds { get; set; }

        public double BothTeamsNotToScoreodds { get; set; }
    }
}
