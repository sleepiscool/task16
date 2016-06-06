using System;
using System.Windows.Forms;
using Model;

/// <summary>
///  Форма для изменения пользователя
/// </summary>

namespace Aapplication_model
{
    public partial class ChangePerson : Form
    {
        public Person _person;

        public ChangePerson(Person person)
        {
            _person = person;

            InitializeComponent();
            textBox_new_SurName.Text = _person.SurName;
            textBox_new_Name.Text = _person.Name;
            textBox_new_Patronymic.Text = _person.Patronymic;
            textBox_new_Organization.Text = _person.Organization;
            textBox_new_Position.Text = _person.Position;
            textBox_new_Email.Text = _person.Email;
            textBox_new_NumberPhone.Text = _person.NumberPhone;
        }

        /// <summary>
        ///  Кнопка изменения пользователя
        /// </summary>
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
        /// <summary>
        /// Событие чтобы запускать форму в другом окне
        /// </summary>
        public void Run()
        {
            ShowDialog();
        }
    }
}