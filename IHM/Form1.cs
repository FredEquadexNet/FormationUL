using DataContracts;
using Flurl.Http;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace IHM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url  = "http://localhost:5298";
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                dataGridView1.DataSource = await $"{url}/recipes".GetJsonAsync<List<Recipe>>();
            }
            else
            {
                //dataGridView1.DataSource = Factory.Instance?.GetByTitle(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var recipes = Factory.Instance?.GetAll();
            //var json = JsonConvert.SerializeObject(recipes);
            //File.WriteAllText("recipes.json", json);
        }
    }
}

