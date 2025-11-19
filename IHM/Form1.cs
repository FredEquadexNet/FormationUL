using Newtonsoft.Json;
using Services;

namespace IHM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                dataGridView1.DataSource = Factory.Instance?.GetAll();
            }
            else
            {
                dataGridView1.DataSource = Factory.Instance?.GetByTitle(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var recipes = Factory.Instance?.GetAll();
            var json = JsonConvert.SerializeObject(recipes);
            File.WriteAllText("recipes.json", json);
        }
    }
}

