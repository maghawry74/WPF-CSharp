using Desktop_Contacts_APP.Classes;
using SQLite;
using System.Collections.Generic;
using System.Windows;

namespace Desktop_Contacts_APP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            readDataBase();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow contactWindow = new NewContactWindow();
            this.Hide();
            contactWindow.ShowDialog();
            this.Show();
            readDataBase();
        }
        void readDataBase()
        {

            using (SQLiteConnection connection = new(App.DBPath))
            {

                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList();
            }
            contactsListview.ItemsSource = contacts;
        }

        private void contactsListview_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Contact? selectedContact = contactsListview.SelectedItem as Contact;

            if (selectedContact != null)
            {
                Edit contactDetailsWindow = new Edit(selectedContact);
                Hide();
                contactDetailsWindow.ShowDialog();
                Show();
                readDataBase();
            }
        }
    }
}
