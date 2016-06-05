using System;
using System.Windows.Forms;
using Model;

namespace Aapplication_model
{
    public partial class ChangePerson : Form
    {
        public Person _person;
        public ChangePerson(Person person)
        {
            _person = person;

            InitializeComponent();
        }

        private void Change_Click(object sender, EventArgs e)
        {
            var repository = new DbPersonRepository();

            _person.SurName = textBox_new_SurName.Text;
            _person.Name = textBox_new_Name.Text;
            _person.Patronymic = textBox_new_Patronymic.Text;
            _person.Organization = textBox_new_Organization.Text;
            _person.Position = textBox_new_Position.Text;
            _person.Email = textBox_new_Email.Text;
            _person.NumberPhone = textBox_new_NumberPhone.Text;

            repository.ChangePerson(_person);

            Close();
        }

        public void Run()
        {
            ShowDialog();
        }
    }
}