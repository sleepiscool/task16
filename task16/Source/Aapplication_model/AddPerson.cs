using System;
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
            repository.AddPerson(new Person(Name.Text, Surname.Text, Patronymic.Text, Position.Text, Organization.Text, Email.Text, NumberPhone.Text ));
            this.Close();
        }
    }
}