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
        Controller.ActivityController _activityController;

        public AddMeasurement()
        {
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
            _activityController.AddMeasurement(_activityController.Activities.Last());
        }
        // Move to Acitvitycontroller
        private void AddNewActivity_Click(object sender, RoutedEventArgs e)
        {
            _activityController = new Controller.ActivityController();
            DateTime Startdate = Convert.ToDateTime(StartDate.SelectedDate);
            TimeSpan staDate = new TimeSpan(Convert.ToInt32(staHours.Text), Convert.ToInt32(staMinuts.Text), 0);
            Startdate = Startdate + staDate;
            ActivityLine.Items.Add(Name.Text + ", " + Description.Text + ", " + Details.Text + ", " + Startdate + ", " + ExpectedResult.Text + ", " + ActualResult.Text);

            _activityController.AddActivity(Name.Text, Description.Text, Details.Text, Startdate, ExpectedResult.Text, ActualResult.Text);

            /*
            _activityController.Activities.Last().Measurements.Add(new Model.Activity(Name.Text, ExpectedResult.Text));
            Name.Text = "";
            ExpectedResult.Text = "";
             */
        }

        private void Back_Click(object sender, RoutedEventArgs e) {
            Start start = new Start();
            start.Show();
            this.Close();
        }
    }
}
