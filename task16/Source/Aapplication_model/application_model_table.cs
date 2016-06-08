using System;
using System.Text;
using System.Windows.Forms;
using Model;


/// <summary>
/// Главная форма программы 
/// </summary>

namespace Aapplication_model
{
    public partial class ApplicationModelTable : Form
    {

        public ApplicationModelTable()
        {
            InitializeComponent();
            
            Update();
            button_delete.Enabled = false;
            button_change.Enabled = false;
        }
        
        /// <summary>
        ///  Обновить таблицу
        /// </summary>
        public void Update()
        {
            dataGridView1.Rows.Clear();
            var repository = new DbPersonRepository();
            var peopleList = repository.GetPeopleList();
            foreach (var person in peopleList)
            {
                dataGridView1.Rows.Add();
            }
            var j = 0;
            
            foreach (var person in peopleList)
            {
                dataGridView1.Rows[j].Cells["Id"].Value = person.Id;
                dataGridView1.Rows[j].Cells["SurName"].Value = person.SurName ?? "" ;
                dataGridView1.Rows[j].Cells["Name"].Value = person.Name ?? "";
                dataGridView1.Rows[j].Cells["Patronymic"].Value = person.Patronymic ?? "";
                dataGridView1.Rows[j].Cells["Organization"].Value = person.Organization ?? "";
                dataGridView1.Rows[j].Cells["Position"].Value = person.Position ?? "";
                dataGridView1.Rows[j].Cells["Email"].Value = person.Email ?? "";
                dataGridView1.Rows[j++].Cells["NumberPhone"].Value = person.NumberPhone ?? "";
            }
        }
        public static string Convertall(string value, Encoding src, Encoding trg)
        {
            Decoder dec = src.GetDecoder();
            byte[] ba = trg.GetBytes(value);
            int len = dec.GetCharCount(ba, 0, ba.Length);
            char[] ca = new char[len];
            dec.GetChars(ba, 0, ba.Length, ca, 0);
            return new string(ca);
        }
        /// <summary>
        /// Функция чтобы можно было запускать сразу несколько форм
        /// </summary>
        public void RunTable()
        {
            ShowDialog();
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
        ///  Кнопка поиска позьзователя 
        /// </summary>
        private void button_search_Click(object sender, EventArgs e)
        {
            new SearchPerson().Run();
            Update();
        }

        /// <summary>
        ///  Кнопка добавление  позьзователя 
        /// </summary>
        private void button_add_Click(object sender, EventArgs e)
        {
            new AddPerson().Run();
            Update();
        }
        /// <summary>
        ///  Кнопка изменения  позьзователя 
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
            Update();
        }
        /// <summary>
        ///  Кнопка удаления  позьзователя 
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
            Update();
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