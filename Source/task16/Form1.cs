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

        private void LoadToGrid()
        {
            var testcontext = new databasetask16Entities();
            var load = from g in testcontext.human select g;
            if (load != null)
            {
                dataGridView1.DataSource = load.ToList();
            }
        }
    }
}