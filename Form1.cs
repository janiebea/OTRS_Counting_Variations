using System.Text.Json;

namespace OTRS_Counting_Variations
{
    public partial class Form1 : Form
    {
        string orderJsonData;
        // List<int> combinationCounts = new List<int>();

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
            List<Order> combinations = new List<Order>();
            List<int> combinationCounts = new List<int>();
            string temp;
            int first;
            int second;
            int third;
            if (orders != null)
            {
               foreach (var order in orders)
                {
                    // 1, 0 , -1: first, equal, second alphabetically
                    first = String.Compare(order.FlavorOne, order.FlavorTwo);
                    second = String.Compare(order.FlavorTwo, order.FlavorThree);
                    third = String.Compare(order.FlavorOne, order.FlavorThree);

                    if ((first >= 0 && second == 1) || (first == 1 && second >= 0)) break; // already alphabetical
                    if (third >= 0 && second  < 0)
                    {
                        temp = order.FlavorTwo;
                        order.FlavorTwo = order.FlavorThree;
                        order.FlavorThree = temp;
                        break;
                    }
                    if (first >= 0 && third == -1)
                    {
                        temp = order.FlavorOne;
                        order.FlavorOne = order.FlavorThree;
                        order.FlavorThree = order.FlavorTwo;
                        order.FlavorTwo = temp;
                        break;
                    }
                    if (first == -1 && second == 1 && third >= 0)
                    {
                        temp = order.FlavorOne;
                        order.FlavorOne = order.FlavorTwo;
                        order.FlavorTwo = temp;
                        break;
                    }
                    if (second >= 0 && third == -1)
                    {
                        temp = order.FlavorOne;
                        order.FlavorOne = order.FlavorTwo;
                        order.FlavorTwo = order.FlavorThree;
                        order.FlavorThree = temp;
                        break;
                    }

                }

               foreach (var order in orders)
                {
                    if (combinations.Count == 0)
                    {
                        combinations.Add(order);
                        combinationCounts.Add(1);
                    }
                    else
                    {
                        for (int i = 0; i < combinations.Count; i++)
                        {
                            if (order == combinations[i])
                            {
                                combinationCounts[i]++;
                                break;
                            } else if (i == (combinationCounts.Count - 1) && order != combinations[i])
                            {
                                combinations.Add(order);
                                combinationCounts.Add(1);
                            }
                        }
                    }
                }
            }
            

        }

    }

   /* public class Combination
    {
        private string FlavorOne;
        private string FlavorTwo;
        private string FlavorThree;
        private int count;
    }
   */

    public class Order
    {
        public string FlavorOne { get; set; }
        public string FlavorTwo { get; set; }
        public string FlavorThree { get; set; }
    }
}