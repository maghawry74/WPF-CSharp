using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CalCulator
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

        private void numbersClicked(object sender, RoutedEventArgs e)
        {

            Button? number = sender as Button;
            if (number?.Content.ToString() == "C")
            {
                display.Clear();
            }
            else
            {
                display.Text += number?.Content.ToString();
            }
        }

        private void operationcliked(object sender, RoutedEventArgs e)
        {
            try
            {
                display.Text = Convert.ToDouble(new DataTable().Compute(display.Text, "")).ToString();
            }
            catch (Exception)
            {
                display.Text = "Invalid Mathematical Operation";
                display.FontSize = 15;
                display.TextAlignment = TextAlignment.Center;
            }
        }


    }
}
