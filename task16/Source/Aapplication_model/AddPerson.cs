using System;
using System.Windows.Forms;
using Model;

namespace Aapplication_model
{
    public partial class AddPerson : Form
    {
        public AddPerson()
        {
            InitializeComponent();
        }

        public void Run()
        {
            ShowDialog();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var repository = new DbPersonRepository();
            repository.AddPerson(new Person(Name.Text, Surname.Text, Patronymic.Text, Position.Text, Organization.Text, Email.Text, NumberPhone.Text ));
            this.Close();
        }
    }
}