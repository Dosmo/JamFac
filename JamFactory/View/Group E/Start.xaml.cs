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

namespace JamFactory.View.Group_E {
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window {
        MainWindow main;
        public Start() {
            InitializeComponent();
        }

        private void NewControl_Click(object sender, RoutedEventArgs e)
        {
            AddActivity activity = new AddActivity();
            activity.Show();
            this.Close();
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {          
            main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
