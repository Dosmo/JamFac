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
        AddMeasurement addactivity;
        public AddActivity()
        {
            InitializeComponent();
        }
        // Move to Acitvitycontroller 
        private void AddNewActivity_Click(object sender, RoutedEventArgs e)
        {
            //_activityController.AddControl(new Model.Control(AddName.Text, AddDescription.Text, AddTimeCheck.Text, int.Parse(AddEmployeeID.Text), int.Parse(AddProductID.Text));
            //AddMeasurement addactivity = new AddMeasurement(AddName.Text, AddDescription.Text, AddTimeCheck.Text, int.Parse(AddProductID.Text), int.Parse(AddEmployeeID.Text)); 
            //addMeasurement.SetController(_activityController);

            try {
                addactivity = new AddMeasurement(AddName.Text, AddDescription.Text, AddTimeCheck.Text, int.Parse(AddProductID.Text), int.Parse(AddEmployeeID.Text));
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
    }
}
