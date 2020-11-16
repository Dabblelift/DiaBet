namespace DiaBet.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using DiaBet.Data.Models.Enums;

    public class Bet
    {
        public Bet()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Game))]
        public string GameId { get; set; }

        public virtual Game Game { get; set; }

        public DateTime CreatedOn { get; set; }

        public BetType BetType { get; set; }

        public string Prediction { get; set; }

        public decimal Amount { get; set; }

        public double BetOdds { get; set; }

        public BetStatus BetStatus { get; set; }
    }
}
