using System;
using System.Linq;
using System.Windows.Forms;
using Model;


/// <summary>
///  Форма для добавления пользоватлея
/// </summary>
namespace Aapplication_model
{
    public partial class AddPerson : Form
    {
        public AddPerson()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Событие чтобы запускать форму в другом окне
        /// </summary>
        public void Run()
        {
            ShowDialog();
        }

        /// <summary>
        ///  Кнопка добавления пользователя 
        /// </summary>

        private void Add_Click(object sender, EventArgs e)
        {
            var repository = new DbPersonRepository();
            var people = repository.GetPeopleList();


            if ((Name.Text[0] != Name.Text.ToUpper()[0]) || (Surname.Text[0] != Surname.Text.ToUpper()[0]) & (Patronymic.Text[0] != Patronymic.Text.ToUpper()[0]))
            {
                MessageBox.Show("Name, SurName, Patronymic должны начинаться с заглавной буквы!\nПопробуйте еще раз!");
                return;
            }


            if (people.Any(person => person.Name.Equals(Name.Text) 
                & person.SurName.Equals(Surname.Text) 
                & person.Patronymic.Equals(Patronymic.Text)))
            {
                MessageBox.Show("Данный пользователь уже есть в базе данных!");
                Close();
                return;
            }
            repository.AddPerson(new Person(Surname.Text, Name.Text, Patronymic.Text, Position.Text, Organization.Text, Email.Text, NumberPhone.Text));
            this.Close();
        }
    }
}