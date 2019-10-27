using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Friends
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Friend> _friends;
        private Friend _selectedFriend;

        public ObservableCollection<Friend> Friends
        {
            get { return _friends; }
            set { _friends = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            Friends = new ObservableCollection<Friend>();
            DataContext = Friends;

        }

        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set { _selectedFriend = value; NotifyPropertyChanged("SelectedFriend"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var ctx = new FriendsModelContainer())
            {
                Friends = new ObservableCollection<Friend>(ctx.Friends.ToList());
            }

            UsersListBox.ItemsSource = Friends;
        }

        private void UsersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ;
        }


        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            if (addUserWindow.ShowDialog() == true)
            {
                Friends.Add(addUserWindow.NewFriend);
                using (var ctx = new FriendsModelContainer())
                {
                    ctx.Friends.Add(addUserWindow.NewFriend);
                    ctx.SaveChanges();
                }
            }
            else
            {

            }
        }

        private void DeleteSelectedUserButton_Click(object sender, RoutedEventArgs e)
        {


            using (var ctx = new FriendsModelContainer())
            {
                var userToDelete = ctx.Friends.Find(SelectedFriend.FriendId);
                if (userToDelete != null)
                {
                    ctx.Friends.Remove(userToDelete);
                    Friends.Remove(SelectedFriend);
                    UsersListBox.SelectedIndex = 0;
                    ctx.SaveChanges();
                }
            }
        }
    }
}
