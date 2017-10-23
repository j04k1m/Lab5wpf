using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab5
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

        public class User
        {
            public string Name { get; set; }
            public string Email { get; set; }

            public User(string u, string e)
            {
                Name = u;
                Email = e; 
            }
        }

       
        //Buttons
        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            ListBoxUsers.Items.Add(new User(UsernameTextbox.Text, EmailTextbox.Text));      
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            
            ListBoxUsers.Items.Insert(ListBoxUsers.SelectedIndex, new User(UsernameTextbox.Text, EmailTextbox.Text));
            ListBoxUsers.Items.RemoveAt(ListBoxUsers.SelectedIndex);
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxUsers.SelectedIndex != -1)
            {
                ListBoxUsers.Items.RemoveAt(ListBoxUsers.SelectedIndex);
            }
            else if (ListboxAdmins.SelectedIndex != -1)
            {
                ListboxAdmins.Items.RemoveAt(ListboxAdmins.SelectedIndex);
            }
        }

        private void ButtonAdmin_Click(object sender, RoutedEventArgs e)
        {
            ListboxAdmins.Items.Add(ListBoxUsers.SelectedItem);
            ListBoxUsers.Items.RemoveAt(ListBoxUsers.SelectedIndex);
        }

        private void ButtonUser_Click(object sender, RoutedEventArgs e)
        {
            ListBoxUsers.Items.Add(ListboxAdmins.SelectedItem);
            ListboxAdmins.Items.RemoveAt(ListboxAdmins.SelectedIndex);
        }

        //ListBoxes
        private void ListBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxUsers.SelectedIndex == -1)
            {
                ChangeButton.IsEnabled = false;
                ButtonRemove.IsEnabled = false;
                ButtonAdmin.IsEnabled = false;
            }
            else if(ListBoxUsers.SelectedIndex != -1)
            {
                ChangeButton.IsEnabled = true;
                ButtonRemove.IsEnabled = true;
                ButtonAdmin.IsEnabled = true;
                LabelInfo.Content = "Username: " + ((User)ListBoxUsers.SelectedItem).Name + "\n" + "Email: " + ((User)ListBoxUsers.SelectedItem).Email;
            }

        }

        private void ListboxAdmins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListboxAdmins.SelectedIndex == -1)
            {
                ButtonUser.IsEnabled = false;
                ButtonRemove.IsEnabled = false;
            }
            else if(ListboxAdmins.SelectedIndex != -1)
            {
                ButtonUser.IsEnabled = true;
                ButtonRemove.IsEnabled = true;
                LabelInfo.Content = "Username: " + ((User)ListboxAdmins.SelectedItem).Name + "\n" + "Email: " + ((User)ListboxAdmins.SelectedItem).Email;
            }
        }


        
    }

}
