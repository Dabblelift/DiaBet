namespace DiaBet.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using DiaBet.Data.Models.Enums;

    public class Result
    {
        public Result()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [ForeignKey(nameof(Game))]
        public string GameId { get; set; }

        public Game Game { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public FullTimeResult FullTimeResult { get; set; }

        public MatchGoalsResult MatchGoalsResult { get; set; }

        public BothTeamsToScoreResult BothTeamsToScoreResult { get; set; }
    }
}
