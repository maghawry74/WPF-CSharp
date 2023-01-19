using Desktop_Contacts_APP.Classes;
using SQLite;
using System.Windows;

namespace Desktop_Contacts_APP
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        Contact contact;
        public Edit(Contact _contact)
        {
            InitializeComponent();
            contact = _contact;
            txt_email.Text = _contact?.Email;
            txt_phone.Text = _contact?.Phone;
            txt_name.Text = _contact?.Name;
        }

        private void deleteBtn(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new(App.DBPath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }
            Close();
        }
        private void updateBtn(object sender, RoutedEventArgs e)
        {
            contact.Email = txt_email.Text;
            contact.Phone = txt_phone.Text;
            contact.Name = txt_name.Text;
            using (SQLiteConnection connection = new(App.DBPath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }
            Close();
        }
    }
}
