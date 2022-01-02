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
using ClassLibrary;
using MongoDB.Bson;

namespace Hadaf_Hashvui
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


        private  async void enter_Click(object sender, RoutedEventArgs e)
        {
            Employee e1 = new Employee(username.Text, password.Text);
            BsonDocument test = await Task.FromResult(e1.getEmployeeDetailsDocByName()).Result;
            if(test == null)
            {
                error.Visibility = Visibility.Visible;
            }
            else
            {
                Window1 w1 = new Window1();
                w1.Show();
            }
        }

        public void username_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= username_GotFocus;
        }

        public void password_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= password_GotFocus;
        }

        private void newUser_Click(object sender, RoutedEventArgs e)
        {
            newUserWindow newUser = new newUserWindow();
            newUser.Show();
        }
    }
}
