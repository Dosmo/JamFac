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
        private void AddNewMeasurement_Click(object sender, RoutedEventArgs e)
        {
            _activityController.Activities.Last().Measurements.Add(new Model.Activity(Name.Text, ExpectedResult.Text));
            Name.Text = "";
            ExpectedResult.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Start start = new Start();
            start.Show();
            this.Close();
        }
    }
}
