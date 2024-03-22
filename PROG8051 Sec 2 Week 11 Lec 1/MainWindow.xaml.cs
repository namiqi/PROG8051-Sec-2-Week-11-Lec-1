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

namespace PROG8051_Sec_2_Week_11_Lec_1
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

            string errors = "";
            if(fname.Text.Length == 0)
            {
                errors += "Please enter value for First Name \n";
            }

            if (Convert.ToInt32(age.Text) < 18)
            {
                errors += "Age should be over 18 \n";
                age.Text = "";
            }

            if (!psw1.Text.Equals(psw2.Text))
            {
                errors += "Passwords are not matching \n";
                psw1.Text = "";
                psw2.Text = "";
            }

            MessageBox.Show(errors);

        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            string gender = "";
            if ((bool)male.IsChecked)
            {
                gender = "male";
            }
            else if ((bool)female.IsChecked)
            {
                gender = "female";
            }
            else if ((bool)pnts.IsChecked)
            {
                gender = "Prefer not to say";
            }

           

            string courses = "";
            if ((bool)_1.IsChecked)
            {
                courses += _1.Content + ",";
            }
            if ((bool)_2.IsChecked)
            {
                courses += _2.Content + ",";
            }
            if ((bool)_3.IsChecked)
            {
                courses += _3.Content + ",";
            }

           string result = $"Name: {fname.Text} \n Last Name: {lname.Text} \n " +
                $"Age: {age.Text} \n Gender: {gender} \n Courses Enrolled: {courses}";

            MessageBox.Show(result);


            string path = @"C:\Users\namiq\Desktop\test\sec2.txt";

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(result);
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(result);
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
