using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerLibrary.TournamentLogic;

namespace TrackerUI;

public partial class TournamentForm : Form
{
    private TournamentModel Tournament;

    BindingList<int> Rounds = new BindingList<int>();

    BindingList<MatchupModel> SelectedMatchups = new BindingList<MatchupModel>();
    public TournamentForm(TournamentModel TournamentModel)
    {
        InitializeComponent();

        Tournament = TournamentModel;
        WireUpLists();

        LoadFormData();

        LoadRounds();
    }
    private void LoadFormData()
    {
        TournamentName.Text = Tournament.TournamentName;

    }
    private void WireUpLists()
    {
        RoundDropdown.DataSource = Rounds;
        MatchupListBox.DataSource = SelectedMatchups;
        MatchupListBox.DisplayMember = "DisplayName";
    }
    private void LoadRounds()
    {
        Rounds.Clear();

        Rounds.Add(1);

        int CurrentRound = 1;
        foreach (List<MatchupModel> Matchups in Tournament.Rounds)
        {
            if (Matchups.First().MatchupRound > CurrentRound)
            {
                CurrentRound = Matchups.First().MatchupRound;
                Rounds.Add(CurrentRound);
            }
        }
        LoadMatchups(1);
    }
    private void TournamentForm_Load(object sende r, EventArgs e)
    {

    }
    private void RoundDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RoundDropdown.SelectedItem == null)
        {
            return;
        }
        LoadMatchups((int)RoundDropdown.SelectedItem);
    }
    private void LoadMatchups(int Round)
    {
        foreach (List<MatchupModel> Matchups in Tournament.Rounds)
        {
            if (Matchups.First().MatchupRound == Round)
            {
                SelectedMatchups.Clear();
                foreach (var Matchup in Matchups)
                {
                    if (Matchup.Winner == null || !UnplayedOnlyCheckBox.Checked)
                    {
                        SelectedMatchups.Add(Matchup);
                    }
                }
            }
        }
        if (SelectedMatchups.Count > 0)
        {
            LoadMatchup(SelectedMatchups.First());
        }

        DisplayMatchupInfo();

    }
    private void DisplayMatchupInfo()
    {
        bool isVisible = (SelectedMatchups.Count > 0);

        if (isVisible)
        {
            TeamOneName.Visible = isVisible;
            TeamOneScore.Visible = isVisible;
            TeamOneScoreValue.Visible = isVisible;

            TeamTwoName.Visible = isVisible;
            TeamTwoScoreValue.Visible = isVisible;
            TeamTwoScore.Visible = isVisible;

            VersusLabel.Visible = isVisible;
            ScoreButton.Visible = isVisible;
        }
    }
    private void LoadMatchup(MatchupModel M)
    {
        for (int i = 0; i < M.Entries.Count; i++)
        {
            if (i == 0)
            {
                if (M.Entries[0].TeamCompeting != null)
                {
                    TeamOneName.Text = M.Entries[0].TeamCompeting.TeamName;
                    TeamOneScoreValue.Text = M.Entries[0].Score.ToString();

                    TeamTwoName.Text = "<bye>";
                    TeamTwoScoreValue.Text = "0";
                }
                else
                {
                    TeamOneName.Text = "Not yet set";
                    TeamOneScoreValue.Text = "";
                }
            }
            if (i == 1)
            {
                if (M.Entries[1].TeamCompeting != null)
                {
                    TeamTwoName.Text = M.Entries[1].TeamCompeting.TeamName;
                    TeamTwoScoreValue.Text = M.Entries[1].Score.ToString();
                }
                else
                {
                    TeamTwoName.Text = "Not yet set";
                    TeamTwoScoreValue.Text = "";
                }
            }
        }
    }
    private void MatchupListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (MatchupListBox.SelectedItem == null)
        {
            return;
        }
        LoadMatchup((MatchupModel)MatchupListBox.SelectedItem);
    }
    private void UnplayedOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (RoundDropdown.SelectedItem == null)
        {
            return;
        }
        LoadMatchups((int)RoundDropdown.SelectedItem);
    }
    private void ScoreButton_Click(object sender, EventArgs e)
    {
        string ErrorMessage = ValidateData();
        if (ErrorMessage.Length > 0)
        {
            MessageBox.Show($"The application had the following error: {ErrorMessage}");
            return;
        }
        if (MatchupListBox.SelectedItem == null)
        {
            return;
        }

        MatchupModel M = (MatchupModel)MatchupListBox.SelectedItem;
        
        double TeamOneScore = 0, TeamTwoScore = 0;

        for (int i = 0; i < M.Entries.Count; i++)
        {
            if (i == 0)
            {
                if (M.Entries[0].TeamCompeting != null)
                {
                    
                    bool ScoreValid = double.TryParse(TeamOneScoreValue.Text, out TeamOneScore);
                    if (ScoreValid)
                    {
                        M.Entries[0].Score = TeamOneScore;
                    }
                    else
                    {
                        MessageBox.Show("Enter a valid score for team 1.");
                        return;
                    }
                }
            }

            if (i == 1)
            {
                if (M.Entries[1].TeamCompeting != null)
                {
                    bool ScoreValid = double.TryParse(TeamTwoScoreValue.Text, out TeamTwoScore);
                    if (ScoreValid)
                    {
                        M.Entries[1].Score = TeamTwoScore;
                    }
                    else
                    {
                        MessageBox.Show("Enter a valid score for team 2.");
                        return;
                    }
                }
            }

        }
        try
        {
            TournamentLogic.UpdateTournamentResults(Tournament);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"The application had the following error: {ex.Message}");
            throw;
        }
        if (RoundDropdown.SelectedItem == null)
        {
            MessageBox.Show($"The application had the following error: There was no selected item on RoundDropdown");
            return;
        }
        LoadMatchups((int)RoundDropdown.SelectedItem);
    }

    private string ValidateData()
    {
        string Output = "";
        double TeamOneScore = 0, TeamTwoScore = 0;

        bool ScoreOneValid = double.TryParse(TeamOneScoreValue.Text, out TeamOneScore);
        bool ScoreTwoValid = double.TryParse(TeamTwoScoreValue.Text, out TeamTwoScore);
        
        if (!ScoreOneValid)
        {
            Output = "The Score One value is not a valid number";
        }
        else if (!ScoreTwoValid)
        {
            Output = "The Score Two value is not a valid number";
        }
        else if (TeamOneScore == 0 && TeamTwoScore == 0)
        {
            Output = "You did not enter a score for either team";
        }
        else if (TeamOneScore == TeamTwoScore)
        {
            Output = "Ties are not allowed in this application.";

        }
        return Output;
    }
}
