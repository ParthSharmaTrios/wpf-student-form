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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication5
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

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            fNameTXT.Text = "";
            lNameTXT.Text = "";
            phoneTXT.Text = "";
            adddressTXT.Text = "";
            maleBtn.IsChecked = false;
            femaleBtn.IsChecked = false;

           


        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            var firstName = fNameTXT.Text;
            var lastName = lNameTXT.Text;
            var phone = phoneTXT.Text;
            var address = adddressTXT.Text;

            var gender = "";

            if (maleBtn.IsChecked == true) {
                gender = "male";
            }

            if (femaleBtn.IsChecked == true) {
                gender = "female";
            }

            if (firstName == "" || lastName == "" || phone == "" || address == "")
                MessageBox.Show("Please enter all data " + gender);
            else
                MessageBox.Show("Thank you for submitting the data");

        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
  
        }
    }
}
