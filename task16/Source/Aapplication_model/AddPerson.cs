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
            var myRegFIO = new Regex(@"[A-Z]{1}[a-z]+");
            if (!myRegFIO.IsMatch(Name.Text) || !myRegFIO.IsMatch(Surname.Text) || !myRegFIO.IsMatch(Patronymic.Text))
            {
                MessageBox.Show("Name, SurName, Patronymic должны начинаться с заглавной буквы!\nПопробуйте еще раз!");
                return;
            }
            var myRegEmail = new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]+");
            if (!myRegEmail.IsMatch(Email.Text) & (Email.Text.Length != 0))
            {
                MessageBox.Show("Указанная вами электронная почта введена неверно.\nПример ввода: denisqwe@mail.ru");
                return;
            }
            
            var myRegNumberPhone = new Regex(@"8[0-9]{10}$");
            if (!myRegNumberPhone.IsMatch(NumberPhone.Text) & (NumberPhone.Text.Length != 0))
            {
                MessageBox.Show("Указанный вами телефон был введен неверно.\nФормат телефона: 89652222222");
                return;
            }
            var repository = new DbPersonRepository();
            var people = repository.GetPeopleList();

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