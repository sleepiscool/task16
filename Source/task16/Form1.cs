using System;
using System.Linq;
using System.Windows.Forms;

namespace task16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databasetask16DataSet.human' table. You can move, or remove it, as needed.
            humanTableAdapter.Fill(databasetask16DataSet.human);
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        //Функция которая  будет вставлять данные в таблицу MySQL.
        private void Add_but_Click(object sender, EventArgs e)
        {
            var testcontext = new databasetask16Entities();
            try
            {
                var emp = new human

                {
                    Id = int.Parse(textId.Text),
                    Name = textName.Text,
                    Email = textEmail.Text,
                    NumberPhone = textNumberPhone.Text,
                    Organization = textOrganization.Text,
                    Patronymic = textPatronymic.Text,
                    SurName = textSurName.Text,
                    Position = textPosition.Text
                };
                testcontext.human.Add(emp);
                testcontext.SaveChanges();
                LoadToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }
        //Функция которая  будет загружать данные из таблицы и привязывать их к форме
        private void LoadToGrid()
        {
            var testcontext = new databasetask16Entities();
            var load = from g in testcontext.human select g;
            if (load != null)
            {
                dataGridView1.DataSource = load.ToList();
            }
        }
        //Функция которая  будет обновлять данные в таблице MySQL
        private void UpDate_but_Click(object sender, EventArgs e)
        {
            int empId;
            int.TryParse(textId.Text, out empId);
            var testcontext = new databasetask16Entities();
            try
            {
                var emp = testcontext.human.First(i => i.Id == empId);
                {
                    emp.Name = textName.Text;
                    emp.Email = textEmail.Text;
                    emp.NumberPhone = textNumberPhone.Text;
                    emp.Organization = textOrganization.Text;
                    emp.SurName = textSurName.Text;
                    emp.Position = textPosition.Text;
                    emp.Patronymic = textPatronymic.Text;
                    testcontext.SaveChanges();
                    LoadToGrid();
                };
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        //Функция которая будет удалять данные в MySQL таблицы
        private void Delete_but_Click(object sender, EventArgs e)
        {
            int empId;
            int.TryParse(textId.Text, out empId);
            var testcontext = new databasetask16Entities();
            try
            {
                var emp = testcontext.human.First(i => i.Id == empId);
                testcontext.human.Remove(emp);
                testcontext.SaveChanges();
                LoadToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }
    }
}