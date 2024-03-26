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
        public CreateTeamForm()
        {
            InitializeComponent();
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

                GlobalConfig.Connection.CreatePerson(Person);

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
    }
}
