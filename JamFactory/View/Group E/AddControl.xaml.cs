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
    /// yo hoes
    public partial class AddActivity : Window
    {
        Controller.ActivityController _activityController;
        List<string> PersonSearchList;
        AddMeasurement addactivity;
        //int ProductID;
        //int EmployeeID;
        public AddActivity()
        {
            _activityController = new Controller.ActivityController();
            PersonSearchList = new List<string>();
            InitializeComponent();
            //AllEmployees();
        }
        // Move to Acitvitycontroller 
        private void AddNewActivity_Click(object sender, RoutedEventArgs e)
        {
            //_activityController.AddControl(new Model.Control(AddName.Text, AddDescription.Text, AddTimeCheck.Text, int.Parse(AddEmployeeID.Text), int.Parse(AddProductID.Text));
            //AddMeasurement addactivity = new AddMeasurement(AddName.Text, AddDescription.Text, AddTimeCheck.Text, int.Parse(AddProductID.Text), int.Parse(AddEmployeeID.Text)); 
            //addMeasurement.SetController(_activityController);
            
            
            try {
                /*
                foreach (string s in _activityController.GetAllEmployees(1)) {
                    if (person_ListBox.SelectedItem == s) {
                        EmployeeID = _activityController.GetPersonId(_activityController.GetAllEmployees(1).IndexOf(person_ListBox.SelectedItem.ToString()));
                    }
                }
                 */
                addactivity = new AddMeasurement(AddName.Text, AddDescription.Text, AddTimeCheck.Text, /*int.Parse(AddProductID.Text"")*/_activityController.GetProductId(Product_DropDown.SelectedIndex), /*int.Parse(AddEmployeeID.Text"")EmployeeID*/_activityController.GetPersonId(Employee_DropDown.SelectedIndex));
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
            foreach (string s in _activityController.GetAllEmployees(1)) {
                //person_ListBox.Items.Add(s);
                Employee_DropDown.Items.Add(s);
            }            
        }

        private void SearchEmployee() {
            person_ListBox.Items.Clear();
            foreach (string s in PersonSearchList) {
                person_ListBox.Items.Add(s);
            }
        }
        //Gør det sådan at når man søger på navn, så skal det bare hoppe hen til det index hvor navnet står!
        private void searchperson_TextBox_TextChanged(object sender, TextChangedEventArgs e) {
            foreach (string s in _activityController.GetAllEmployees(1)) {
                if (s.IndexOf(searchperson_TextBox.Text.ToString()) != -1) {
                    PersonSearchList.Add(s);
                }
                SearchEmployee();
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
