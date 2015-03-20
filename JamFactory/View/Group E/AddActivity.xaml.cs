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
        Controller.ActivityController _activityController = new Controller.ActivityController();
        public AddActivity()
        {
            InitializeComponent();
        }
        // Move to Acitvitycontroller 
        private void AddNewMeasurement_Click(object sender, RoutedEventArgs e)
        {
            _activityController.AddActivity(new Model.Activity(AddName.Text, AddDescription.Text, AddTimeCheck.Text), int.Parse(AddEmployeeID.Text), int.Parse(AddProductID.Text));
            AddMeasurement addMeasurement = new AddMeasurement(); 
            addMeasurement.SetController(_activityController);
            addMeasurement.Show();
            this.Close();
        }
    }
}
