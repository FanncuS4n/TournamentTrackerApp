using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        /// <summary>
        /// Unique identifier for the matchup.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Set of teams that were involved in this match.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        /// <summary>
        /// ID from the database that will be used to identify the winner.
        /// </summary>
        public int WinnerId { get; set; }
        /// <summary>
        /// Winner of the match.
        /// </summary>
        public TeamModel? Winner { get; set; }
        /// <summary>
        /// Which round this match is a part of.
        /// </summary>
        public int MatchupRound { get; set; }

        public string DisplayName 
        { 
            get 
            {
                string Output = "";

                foreach (MatchupEntryModel Me in Entries)
                {
                    if (Me.TeamCompeting != null)
                    {
                        if (Output.Length == 0)
                        {
                            Output = Me.TeamCompeting.TeamName;
                        }
                        else
                        {
                            Output += $" vs. {Me.TeamCompeting.TeamName}";
                        }
                    }
                    else
                    {
                        Output = "Matchup not determined";
                        break;
                    }
                }

                return Output;
            } 
        }
    }
}
