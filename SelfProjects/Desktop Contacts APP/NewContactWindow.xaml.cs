using Desktop_Contacts_APP.Classes;
using Microsoft.Win32;
using SQLite;
using System.Windows;

namespace Desktop_Contacts_APP
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = txt_name.Text,
                Email = txt_email.Text,
                Phone = txt_phone.Text,
                Image = txt_image.Text,
            };
            using (SQLiteConnection connection = new(App.DBPath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }
            this.Close();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            txt_email.Clear();
            txt_phone.Clear();
            txt_name.Clear();
            txt_image.Clear();
        }
        private void addImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*png|All|*";
            if (ofd.ShowDialog() == true)
            {
                txt_image.Text = ofd.FileName;
            }
        }
    }
}
