using System.Text.Json;

namespace OTRS_Counting_Variations
{
    public partial class Form1 : Form
    {
        string orderJsonData;
        public Form1()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "JSON |*.json";
            
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fileDialog.FileName;
                orderJsonData = File.ReadAllText(fileDialog.FileName);
                calculateButton.Visible = true;
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            var orders = JsonSerializer.Deserialize<List<Order>>(orderJsonData);
            if (orders != null)
            {
                MessageBox.Show($"FlavorOne: {orders[3].FlavorOne}");
               /* foreach (var order in orders)
                {
                    
                } */
            }
            

        }

    }

    public class Order
    {
        public string FlavorOne { get; set; }
        public string FlavorTwo { get; set; }
        public string FlavorThree { get; set; }
    }
}