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
    /// Interaction logic for AddMeasurement.xaml
    /// </summary>
    public partial class AddMeasurement : Window
    {       
        private Controller.ActivityController _activityController;
        private AddActivity addactivity;

        private string addName;
        private string addDescription;
        private string addTimeCheck;
        private int addProductID;
        private int addEmployeeID;

        public AddMeasurement(string addname, string adddescription, string addtimecheck, int addproductid, int addemployeeid)
        {
            addName = addname;
            addDescription = adddescription;
            addTimeCheck = addtimecheck;
            addProductID = addproductid;
            addEmployeeID = addemployeeid;
            InitializeComponent();
        }
        /*
        public void SetController(Controller.ActivityController c)
        {
            _activityController = c;
        }
         */
        // Move to Acitvitycontroller
        
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _activityController.AddControl2(addName, addDescription, addTimeCheck, addProductID, addEmployeeID);
            
            addactivity = new AddActivity();
            addactivity.Show();

            this.Close();
            //_activityController.AddMeasurement(_activityController.Activities.Last());
        }
        // Move to Acitvitycontroller
       
        private void AddNewActivity_Click(object sender, RoutedEventArgs e)
        {
            _activityController = new Controller.ActivityController();
            
            DateTime startDate = Convert.ToDateTime(start_DatePicker.SelectedDate);
            TimeSpan startSpan = new TimeSpan(Convert.ToInt32(staHours.Text), Convert.ToInt32(staMinuts.Text), 0);
            
            startDate = startDate + startSpan;

            ActivityLine.Items.Add(name_TextBox.Text + ", " + description_TextBox.Text + ", " + Details.Text + ", " + startDate + ", " + expectedResault_TextBox.Text + ", " + actualResult_TextBox.Text);
            _activityController.AddActivity(name_TextBox.Text, description_TextBox.Text, Details.Text, startDate, expectedResault_TextBox.Text, actualResult_TextBox.Text);

            ClearView();

            /*
            _activityController.Activities.Last().Measurements.Add(new Model.Activity(Name.Text, ExpectedResult.Text));
            Name.Text = "";
            ExpectedResult.Text = "";
             */
        }

        private void ClearView()
        {
            name_TextBox.Clear();
            description_TextBox.Clear();
            Details.Clear();
            staHours.Clear();
            staMinuts.Clear();
            expectedResault_TextBox.Clear();
            actualResult_TextBox.Clear();
        }

        private void Back_Click(object sender, RoutedEventArgs e) {
            Start start = new Start();
            start.Show();
            this.Close();
        }
    }
}
