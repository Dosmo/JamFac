using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JamFactory.View.Group_E
{
    /// <summary>
    /// Interaction logic for AddActivity.xaml
    /// </summary>
    public partial class AddActivity : Window
    {
        Controller.ActivityController _activityController;
        List<string> PersonSearchList;
        AddMeasurement addactivity;
        public AddActivity()
        {
            _activityController = new Controller.ActivityController();
            PersonSearchList = new List<string>();
            InitializeComponent();
        }
        // Move to Acitvitycontroller 
        private void AddNewActivity_Click(object sender, RoutedEventArgs e)
        {
            try {
                addactivity = new AddMeasurement(AddName.Text, AddDescription.Text, AddTimeCheck.Text,_activityController.GetProductId(Product_DropDown.SelectedIndex),_activityController.GetPersonId(Employee_DropDown.SelectedIndex));
                addactivity.Show();
                this.Close();
            }
            catch (Exception) {

                MessageBox.Show("Alle felterne skal udfyldes");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e) {
            Start start = new Start();
            start.Show();
            this.Close();
        }

        private void AllEmployees() {
            foreach (string s in _activityController.GetAllEmployees()) {
                Employee_DropDown.Items.Add(s);
            }            
        }

        private void AllProducts() {
            foreach (string s in _activityController.GetAllProducts()) {
                Product_DropDown.Items.Add(s);
            }
        }

        private void Product_DropDown_DropDownOpened(object sender, EventArgs e) {
            AllProducts();
        }

        private void Employee_DropDown_DropDownOpened(object sender, EventArgs e) {
            AllEmployees();
        }
    }
}
