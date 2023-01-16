using System;
using System.Windows;
using System.Windows.Controls;

namespace Bouns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            left.IsChecked = true;
            editable.IsChecked = true;
        }
        private Boolean IsEditable()
        {
            return mainTxt.IsEnabled;
        }
        private void SetText_Click(object sender, RoutedEventArgs e)
        {
            if (IsEditable())
            {
                mainTxt.Text = "Welcome To Main Text Box";
            }
        }
        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (IsEditable())
            {
                mainTxt.SelectAll();
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (IsEditable())
            {
                mainTxt.Clear();
            }
        }
        private void Prepend_Click(object sender, RoutedEventArgs e)
        {
            if (IsEditable())
            {
                string temp = mainTxt.Text;
                mainTxt.Clear();
                mainTxt.Text = $"***Prepended text * ** {temp}";
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (IsEditable())
            {
                string temp = mainTxt.Text;
                mainTxt.Clear();
                mainTxt.Text = $"***inserted  text * ** {temp}";
            }
        }
        private void Append_Click(object sender, RoutedEventArgs e)
        {
            if (IsEditable())
            {
                mainTxt.AppendText(" *** appended text ***");
            }
        }
        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            if (IsEditable())
            {
                if (mainTxt.SelectedText.Length > 0)
                {
                    Clipboard.SetText(mainTxt.Text);
                    mainTxt.Cut();
                    MessageBox.Show($"Cut : {Clipboard.GetText()}", "Cut");
                }
                else
                {
                    MessageBox.Show("Please Selecte Text First", "Alert");
                }
            }
        }
        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            if (IsEditable())
            {
                mainTxt.Paste();
            }
        }
        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (IsEditable())
            {
                mainTxt.Undo();
            }
        }
        private void ChangeAccess(object sender, RoutedEventArgs e)
        {
            RadioButton? radioButton = sender as RadioButton;
            switch (radioButton?.Content.ToString())
            {
                case "Editable":
                    mainTxt.IsEnabled = true;
                    break;
                case "Read Only":
                    mainTxt.IsEnabled = false;
                    break;
            }
        }
        private void TextDirection(object sender, RoutedEventArgs e)
        {
            RadioButton? radioButton = sender as RadioButton;
            TextAlignment tempStr;
            if (Enum.TryParse<TextAlignment>(radioButton?.Content.ToString(), out tempStr))
            {
                mainTxt.TextAlignment = tempStr;
            }
        }
    }
}
