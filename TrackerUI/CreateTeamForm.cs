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
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> AvailableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> SelectedTeamMembers = new List<PersonModel>();

        public CreateTeamForm()
        {
            InitializeComponent();

            //CreateSampleData();

            WireUpList();
        }
        private void CreateSampleData()
        {
            AvailableTeamMembers.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            AvailableTeamMembers.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });

            SelectedTeamMembers.Add(new PersonModel { FirstName = "Jane", LastName = "Smith" });
            SelectedTeamMembers.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });

        }
        private void WireUpList()
        {
            SelectTeamMemberDropdown.DataSource = null;

            SelectTeamMemberDropdown.DataSource = AvailableTeamMembers;
            SelectTeamMemberDropdown.DisplayMember = "FullName";

            TeamMembersListBox.DataSource = null;

            TeamMembersListBox.DataSource = SelectedTeamMembers;
            TeamMembersListBox.DisplayMember = "FullName";
        }
        private void CreateMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel Person = new PersonModel();
                Person.FirstName = FirstNameValue.Text;
                Person.LastName = LastNameValue.Text;
                Person.EmailAdress = EmailValue.Text;
                Person.CellphoneNumber = CellphoneValue.Text;

                Person = GlobalConfig.Connection.CreatePerson(Person);

                SelectedTeamMembers.Add(Person);
                WireUpList();

                FirstNameValue.Text = "";
                LastNameValue.Text = "";
                EmailValue.Text = "";
                CellphoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("All fields need to be filled correctly");
            }
        }
        private bool ValidateForm()
        {
            if (FirstNameValue.Text.Length == 0)
            {
                return false;
            }
            if (LastNameValue.Text.Length == 0)
            {
                return false;
            }
            if (EmailValue.Text.Length == 0)
            {
                return false;
            }
            if (CellphoneValue.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            if (SelectTeamMemberDropdown.SelectedItem != null)
            {
                PersonModel Person = (PersonModel)SelectTeamMemberDropdown.SelectedItem;
                AvailableTeamMembers.Remove(Person);
                SelectedTeamMembers.Add(Person);
            }
            else
            {
                MessageBox.Show("Select a person to add to the team!");
            }


        }

        private void RemoveSelectedButton_Click(object sender, EventArgs e)
        {
            if (TeamMembersListBox.SelectedItem != null)
            {
                PersonModel Person = (PersonModel)TeamMembersListBox.SelectedItem;
                SelectedTeamMembers.Remove(Person);
                AvailableTeamMembers.Add(Person);
                WireUpList();
            }
            else
            {
                MessageBox.Show("Select a person to remove from the team!");
            }

        }

        private void CreateTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel Team = new TeamModel();
            Team.TeamName = TeamNameValue.Text;
            Team.TeamMembers = SelectedTeamMembers;

            Team = GlobalConfig.Connection.CreateTeam(Team);

        }
    }
}
