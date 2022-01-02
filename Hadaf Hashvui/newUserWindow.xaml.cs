using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClassLibrary;

namespace Hadaf_Hashvui
{
    /// <summary>
    /// Interaction logic for newUserWindow.xaml
    /// </summary>
    public partial class newUserWindow : Window
    {
        public newUserWindow()
        {
            InitializeComponent();
        }

        private void newUserButton_Click(object sender, RoutedEventArgs e)
        {
            Employee e1 = new Employee(name.Text, id.Text, username.Text, password.Text);
            e1.setNewDocument();
        }
    }
}
