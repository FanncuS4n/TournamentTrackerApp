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

namespace TrackerUI
{
    public partial class TournamentDashboardForm : Form
    {
        List<TournamentModel> Tournaments = GlobalConfig.Connection.GetTournament_All();
        public TournamentDashboardForm()
        {
            InitializeComponent();
            WireUpLists();
        }
        private void WireUpLists()
        {
            LoadExistingTournamentDropdown.DataSource = Tournaments;
            LoadExistingTournamentDropdown.DisplayMember = "TournamentName";
        }

        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {
            CreateTournamentForm Form = new CreateTournamentForm();
            Form.Show();
        }

        private void LoadTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel Tm = (TournamentModel)LoadExistingTournamentDropdown.SelectedItem;
            TournamentForm Form = new TournamentForm(Tm);
        }
    }
}
