using System;
using System.Linq;
using System.Text.RegularExpressions;
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
            if ((Name.Text.Length == 0) || (Surname.Text.Length == 0) || (Patronymic.Text.Length == 0))
            {
                MessageBox.Show("Обязательные поля ввода: Name, Surname, Patronymic");
                return;
            }
            var myRegFIO = new Regex(@"[A-Z]{1}[a-z]*");
            if (!myRegFIO.IsMatch(Name.Text) || !myRegFIO.IsMatch(Surname.Text) || !myRegFIO.IsMatch(Patronymic.Text))
            {
                MessageBox.Show("Name, SurName, Patronymic должны начинаться с заглавной буквы! Символов быть не должно!\nПопробуйте еще раз!");
                return;
            }
            var myRegEmail = new Regex(@"[A-Za-z0-9_-]+@[A-Za-z]+\.[A-Za-z]+");
            if (!myRegEmail.IsMatch(Email.Text) & (Email.Text.Length != 0))
            {
                MessageBox.Show("Указанная вами электронная почта введена неверно.\nПример ввода: denisqwe@mail.ru");
                return;
            }
            
            var myRegNumberPhone = new Regex(@"8[0-9]{10}$");
            if (!myRegNumberPhone.IsMatch(NumberPhone.Text) & (NumberPhone.Text.Length != 0))
            {
                MessageBox.Show("Указанный вами телефон был введен неверно.\nФормат телефона: 8XXXXXXXXXX(11 цифр)");
                return;
            }
            var repository = new DbPersonRepository();
            var people = repository.GetPeopleList();

            if (people.Any(person => person.Name.ToLower().Equals(Name.Text.ToLower())
                & person.SurName.ToLower().Equals(Surname.Text.ToLower())
                & person.Patronymic.ToLower().Equals(Patronymic.Text.ToLower())))
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