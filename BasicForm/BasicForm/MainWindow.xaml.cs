using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasicForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter infoWriter = new StreamWriter("Submission.txt"))
            {
                infoWriter.WriteLine("First Name: "+FirstName.Text);
                infoWriter.WriteLine("Last Name: "+LastName.Text);
                infoWriter.WriteLine("Email Address: "+EmailAddress.Text);
                infoWriter.WriteLine("Age: "+Age.Text);
                infoWriter.WriteLine("Are you over 21 years old? "+TwentyOneAndUp.IsChecked);
                infoWriter.WriteLine("Are you in school? "+InSchool.IsChecked);
                infoWriter.WriteLine("Do you have a Bachelor's Degree? "+BachelorsDegree.IsChecked);
                infoWriter.WriteLine("Do you have a Graduate Degree? "+GraduateDegree.IsChecked);
            }
            FirstName.Text = string.Empty;
            LastName.Text = string.Empty;
            EmailAddress.Text = string.Empty;
            Age.Text = string.Empty;
            TwentyOneAndUp.IsChecked = false;
            InSchool.IsChecked = false;
            BachelorsDegree.IsChecked = false;
            GraduateDegree.IsChecked = false;
            MessageBox.Show("Submission Accepted!");
        }
    }
}
