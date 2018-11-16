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
using MySql.Data.MySqlClient;

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
            var preference = "";

            if (ftBtn.IsChecked == true)
            {
                preference = "Full time";
            }

            if (ptBtn.IsChecked == true)
            {
                preference = "Part time";
            }

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


            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=studentform;";
            string query = "INSERT INTO students(`id`, `firstName`, `lastName`,`gender`,`mode`, `address`,`phone`) VALUES (NULL, '" + firstName + "', '" + lastName + "', '" + gender + "', '" + preference + "', '" + address + "', '" + phone + "')";
            // Which could be translated manually to :
            // INSERT INTO user(`id`, `firstName`, `lastName`, `address`) VALUES (NULL, 'John', 'Doe', 'John Doe Villa')

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("User succesfully registered");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
  
        }
    }
}
