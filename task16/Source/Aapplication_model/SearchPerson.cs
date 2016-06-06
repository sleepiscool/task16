using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

/// <summary>
///  Форма для поиска пользователя
/// </summary>
namespace Aapplication_model
{
    public partial class SearchPerson : Form
    {
        public SearchPerson()
        {
            InitializeComponent();
            button_delete.Enabled = false;
            button_change.Enabled = false;
        }

        /// <summary>
        ///  Поиск пользователя
        /// </summary>
        private void Search_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var repository = new DbPersonRepository();

            var temp = repository.SearchPerson(textBox_SurName.Text, textBox_Name.Text, textBox_Patronymic.Text,
                textBox_Organization.Text,
                textBox_Position.Text, textBox_Email.Text, textBox_NumberPhone.Text);
            int j = 0;
            foreach (var person in temp)
            {
                dataGridView1.Rows.Add();
            }
            foreach (var person in temp)
            {
                dataGridView1.Rows[j].Cells["Id"].Value = person.Id;
                dataGridView1.Rows[j].Cells["SurName"].Value = person.SurName ?? "";
                dataGridView1.Rows[j].Cells["Name"].Value = person.Name ?? "";
                dataGridView1.Rows[j].Cells["Patronymic"].Value = person.Patronymic ?? "";
                dataGridView1.Rows[j].Cells["Organization"].Value = person.Organization ?? "";
                dataGridView1.Rows[j].Cells["Position"].Value = person.Position ?? "";
                dataGridView1.Rows[j].Cells["Email"].Value = person.Email ?? "";
                dataGridView1.Rows[j++].Cells["NumberPhone"].Value = person.NumberPhone ?? "";
            }
        }
        /// <summary>
        /// Событие чтобы запускать форму в другом окне
        /// </summary>
        public void Run()
        {
            ShowDialog();
        }

        /// <summary>
        ///  Удаление пользователя
        /// </summary>
        private void button_delete_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentCell.RowIndex;
            var person = new Person(dataGridView1.Rows[row].Cells["SurName"].Value.ToString(),
                dataGridView1.Rows[row].Cells["Name"].Value.ToString(),
                dataGridView1.Rows[row].Cells["Patronymic"].Value.ToString(),
                dataGridView1.Rows[row].Cells["Organization"].Value.ToString(),
                dataGridView1.Rows[row].Cells["Position"].Value.ToString(),
                dataGridView1.Rows[row].Cells["Email"].Value.ToString(),
                dataGridView1.Rows[row].Cells["NumberPhone"].Value.ToString())
            {
                Id = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value.ToString())
            };
            var repository = new DbPersonRepository();
            repository.DeletePerson(person);
            Search_Click(new object(), new EventArgs());
        }

        /// <summary>
        ///  Изменение пользователя
        /// </summary>
        private void button_change_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentCell.RowIndex;
            var person = new Person(dataGridView1.Rows[row].Cells["SurName"].Value.ToString(),
                dataGridView1.Rows[row].Cells["Name"].Value.ToString(),
                dataGridView1.Rows[row].Cells["Patronymic"].Value.ToString(),
                dataGridView1.Rows[row].Cells["Organization"].Value.ToString(),
                dataGridView1.Rows[row].Cells["Position"].Value.ToString(),
                dataGridView1.Rows[row].Cells["Email"].Value.ToString(),
                dataGridView1.Rows[row].Cells["NumberPhone"].Value.ToString())
            {
                Id = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value.ToString())
            };
            new ChangePerson(person).Run();
            Search_Click(new object(), new EventArgs());
        }
        /// <summary>
        /// Событие при выделения строки в таблице
        /// </summary>
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button_delete.Enabled = true;
            button_change.Enabled = true;
        }
        /// <summary>
        /// Событие при отмене выделения строки
        /// </summary>
        private void dataGridView1_RowLeave(object sender, EventArgs e)
        {
            button_delete.Enabled = false;
            button_change.Enabled = false;
        }

    }
}
