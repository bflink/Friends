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

namespace Friends
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public Friend NewFriend { get; set; } = new Friend();

        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using(var ctx = new FriendsModelContainer())
            {
                NewFriend.FirstName = FirstNameTextBox.Text;
                NewFriend.MiddleName = MiddleNameTextBox.Text;
                NewFriend.LastName = LastNameTextBox.Text;

                DialogResult = true;
            }

            Close();
        }
    }
}
