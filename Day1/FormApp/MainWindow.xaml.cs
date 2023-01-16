using System.Windows;

namespace FormApp
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

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"You Entered :\nFirst Name : {txt_firstName.Text}\nLast Name : {txt_lastName.Text}\nGender : {txt_gender.Text}\n" +
                $"Job Title : {txt_jobTitle.Text}\nEmail : {txt_email.Text}\nPhone : {txt_phone.Text}\nMobile : {txt_mobile.Text}", "Personal Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.txt_firstName.Text = string.Empty;
            this.txt_lastName.Text = string.Empty;
            this.txt_gender.Text = string.Empty;
            this.txt_jobTitle.Text = string.Empty;
            this.txt_mobile.Text = string.Empty;
            this.txt_phone.Text = string.Empty;
            this.txt_address.Text = string.Empty;
            this.txt_email.Text = string.Empty;
        }
    }
}
