using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerLibrary.TournamentLogic;

namespace TrackerUI
{

    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        List<TeamModel> AvailableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> SelectedTeams = new List<TeamModel>();
        List<PrizeModel> SelectedPrizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();
            WireUpLists();
        }
        private void WireUpLists()
        {
            SelectTeamDropdown.DataSource = null;
            SelectTeamDropdown.DataSource = AvailableTeams;
            SelectTeamDropdown.DisplayMember = "TeamName";

            TournamentTeamsListBox.DataSource = null;
            TournamentTeamsListBox.DataSource = SelectedTeams;
            TournamentTeamsListBox.DisplayMember = "TeamName";

            PrizesListBox.DataSource = null;
            PrizesListBox.DataSource = SelectedPrizes;
            PrizesListBox.DisplayMember = "PlaceName";
        }

        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            if (SelectTeamDropdown.SelectedItem != null)
            {
                TeamModel Team = (TeamModel)SelectTeamDropdown.SelectedItem;
                AvailableTeams.Remove(Team);
                SelectedTeams.Add(Team);

                WireUpLists();
            }
        }

        private void CreatePriceButton_Click(object sender, EventArgs e)
        {
            CreatePrizeForm PrizeForm = new CreatePrizeForm(this);
            PrizeForm.Show();
        }

        public void PrizeComplete(PrizeModel Model)
        {
            //Get back a PrizeModel from the form
            SelectedPrizes.Add(Model);
            WireUpLists();
        }

        public void TeamComplete(TeamModel Model)
        {
            SelectedTeams.Add(Model);
            WireUpLists();
        }

        private void CreateNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm TeamForm = new CreateTeamForm(this);
            TeamForm.Show();
        }

        private void RemoveSelectedTeam_Click(object sender, EventArgs e)
        {
            TeamModel? Team = TournamentTeamsListBox.SelectedItem as TeamModel;

            if (Team != null)
            {
                SelectedTeams.Remove(Team);
                AvailableTeams.Add(Team);
                WireUpLists();
            }
        }

        private void RemoveSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel? Prize = PrizesListBox.SelectedItem as PrizeModel;

            if (Prize != null)
            {
                SelectedPrizes.Remove(Prize);

                WireUpLists();
            }
        }

        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {
            //Validate data
            decimal Fee;
            bool FeeAcceptable = decimal.TryParse(EntryFeeValue.Text, out Fee);

            if (!FeeAcceptable)
            {
                MessageBox.Show("You need to enter a valid entry fee.", 
                    "Invalid Fee", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            //Create our Tournament model
            TournamentModel TournamentModel = new TournamentModel();
            TournamentModel.TournamentName = TournamentNameValue.Text;
            TournamentModel.EntryFee = Fee;

            TournamentModel.Prizes = SelectedPrizes;
            TournamentModel.EnteredTeams = SelectedTeams;

            //Wire our matchups
            TournamentLogic.CreateRounds(TournamentModel);


            //Create tournament entry, prizes & team entries
            GlobalConfig.Connection.CreateTournament(TournamentModel);

            TournamentForm Form = new TournamentForm(TournamentModel);
            Form.Show();
            this.Close();
        }
    }
}
