using System.Windows;
using System.Windows.Controls;

namespace CalculatorAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, newNumber, result;
        string mathoperator;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void numberBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button numberButton = (Button)sender;
                resultLabel.Content = (resultLabel.Content.ToString() == "0") ? $"{numberButton.Content}" : $"{resultLabel.Content}{numberButton.Content}";
            }
            else
            {
                resultLabel.Content += "Invalid Number";
            }
        }

        private void acBtn_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void percentBtn_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = tempNumber / 100;
            }
            if (lastNumber != 0)
            {
                tempNumber *= lastNumber;
            }
            resultLabel.Content = tempNumber.ToString();
        }

        private void positiveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = (-lastNumber).ToString();
            }
        }

        private void dotBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void equalBtn_Click(object? sender, RoutedEventArgs? e)
        {
            newNumber = double.Parse(resultLabel.Content.ToString());
            switch (mathoperator)
            {
                case "+":
                    result = lastNumber + newNumber;
                    break;
                case "*":
                    result = lastNumber * newNumber;
                    break;
                case "/":
                    result = lastNumber / newNumber;
                    break;
                case "-":
                    result = lastNumber - newNumber;
                    break;
            }
            resultLabel.Content = result.ToString();
            mathoperator = null;
        }

        private void operationBtn_Click(object? sender, RoutedEventArgs e)
        {
            Button? operationButton = (Button)sender;
            if (mathoperator != null)
            {
                equalBtn_Click(null, null);

            }
            mathoperator = operationButton.Content.ToString();
            lastNumber = double.Parse(resultLabel.Content.ToString());
            resultLabel.Content = "0";
        }
    }
}
