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
        public AddActivity()
        {
            _activityController = new Controller.ActivityController();
            PersonSearchList = new List<string>();
            InitializeComponent();
            AllEmployee();
        }
        // Move to Acitvitycontroller 
        private void AddNewActivity_Click(object sender, RoutedEventArgs e)
        {
            //_activityController.AddControl(new Model.Control(AddName.Text, AddDescription.Text, AddTimeCheck.Text, int.Parse(AddEmployeeID.Text), int.Parse(AddProductID.Text));
            //AddMeasurement addactivity = new AddMeasurement(AddName.Text, AddDescription.Text, AddTimeCheck.Text, int.Parse(AddProductID.Text), int.Parse(AddEmployeeID.Text)); 
            //addMeasurement.SetController(_activityController);

            try {
                addactivity = new AddMeasurement(AddName.Text, AddDescription.Text, AddTimeCheck.Text, int.Parse(/*AddProductID.Text*/""), int.Parse(/*AddEmployeeID.Text*/""));
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

        private void AllEmployee() {
            foreach (string s in _activityController.GetAllEmployee(1)) {
                person_ListBox.Items.Add(s);
            }            
        }

        private void SearchEmployee() {
            foreach (string s in PersonSearchList) {
                search_ListBox.Items.Clear();
                search_ListBox.Items.Add(s);
            }
        }
        //Gør det sådan at når man søger på navn, så skal det bare hoppe hen til det index hvor navnet står!
        private void searchperson_TextBox_TextChanged(object sender, TextChangedEventArgs e) {
            foreach (string s in _activityController.GetAllEmployee(2)) {
                var match = s.IndexOfAny(searchperson_TextBox.Text.ToCharArray()) != -1;
                PersonSearchList.Add(match.ToString());
            }
        }
    }
}
