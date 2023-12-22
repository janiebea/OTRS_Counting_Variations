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
            // open file explorer with a .json filter
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "JSON |*.json";
            
            // read data from file
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fileDialog.FileName;
                orderJsonData = File.ReadAllText(fileDialog.FileName);
                calculateButton.Visible = true;
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            combinationListBox.Items.Clear();
            countListBox.Items.Clear();

            // deserialize the data into Order objects
            var orders = JsonSerializer.Deserialize<List<Order>>(orderJsonData);

            List<Order> sortedOrders = new List<Order>();
            List<Order> combinations = new List<Order>();
            List<int> combinationCounts = new List<int>();

            // variables to be used for sorting flavors alphabetically
            int first;
            int second;
            int third;

            // verify orders list is not null
            if (orders != null)
            {
               foreach (var order in orders)
                {
                    /* compare the flavors in each order alphabetically
                         -1, 0 , 1: first, equal, second alphabetically */
                    first = String.Compare(order.FlavorOne, order.FlavorTwo);
                    second = String.Compare(order.FlavorTwo, order.FlavorThree);
                    third = String.Compare(order.FlavorOne, order.FlavorThree);

                    if ((first <= 0 && second == -1) || (first == 1 && second >= 0)) // already alphabetical: 1 2 3
                    {
                        sortedOrders.Add(new Order(order.FlavorOne, order.FlavorTwo, order.FlavorThree));
                    }

                    else if (third <= 0 && second > 0) // 1 3 2
                    {
                        sortedOrders.Add(new Order(order.FlavorOne, order.FlavorThree, order.FlavorTwo));
                    }

                    else if (first <= 0 && third > 0) // 3 1 2
                    {
                        sortedOrders.Add(new Order(order.FlavorThree, order.FlavorOne, order.FlavorTwo));
                    }

                    else if (first >= 0 && second > 0 && third < 0) // 3 2 1
                    {
                        sortedOrders.Add(new Order(order.FlavorThree, order.FlavorTwo, order.FlavorOne));
                    }

                    else if (first > 0 && second == -1 && third <= 0) // 2 1 3
                    {
                        sortedOrders.Add(new Order(order.FlavorTwo, order.FlavorOne, order.FlavorThree));
                    }

                    else if (second <= 0 && third > 0) // 2 3 1
                    {
                        sortedOrders.Add(new Order(order.FlavorTwo, order.FlavorThree, order.FlavorOne));
                    }
                   


                }

               foreach (var order in sortedOrders)
                {
                    if (combinations.Count == 0) // if the list is empty, add the first combination
                    {
                        combinations.Add(order);
                        combinationCounts.Add(1);
                    }
                    else
                    {
                        for (int i = 0; i < combinations.Count; i++)
                        {
                            if ((order.FlavorOne == combinations[i].FlavorOne) && (order.FlavorTwo == combinations[i].FlavorTwo) && (order.FlavorThree == combinations[i].FlavorThree)) // check if the combination already exists
                            {
                                combinationCounts[i]++;
                                break;
                            } else if (i == (combinations.Count - 1) && order != combinations[i]) // if the combination does not exist, add it
                            {
                                combinations.Add(order);
                                combinationCounts.Add(1);
                            }
                        }
                    }
                }
            }

            // populate list boxes
            foreach (var c in combinations) combinationListBox.Items.Add($"{c.FlavorOne}, {c.FlavorTwo}, {c.FlavorThree}");
            foreach (var c in combinationCounts) countListBox.Items.Add(c);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }



    public class Order
    {
        public string FlavorOne { get; set; }
        public string FlavorTwo { get; set; }
        public string FlavorThree { get; set; }

        public Order(string flavorOne, string flavorTwo, string flavorThree)
        {
            FlavorOne = flavorOne;
            FlavorTwo = flavorTwo;
            FlavorThree = flavorThree;
        }
    }
}
