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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        Operator selectedOperator;


        public MainWindow()
        {
            InitializeComponent();

            signButton.Click += SignButton_Click;
            percentButton.Click += PercentButton_Click;
            nineButton.Click += NumberButton_Click;
            eightButton.Click += NumberButton_Click;
            sixButton.Click += NumberButton_Click;
            fiveButton.Click += NumberButton_Click;
            fourButton.Click += NumberButton_Click;
            threeButton.Click += NumberButton_Click;
            twoButton.Click += NumberButton_Click;
            oneButton.Click += NumberButton_Click;
            zeroButton.Click += NumberButton_Click;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case Operator.Addition:
                        result = Math.Add(lastNumber, newNumber);
                        break;
                    case Operator.Subtraction:
                        result = Math.Subtract(lastNumber, newNumber);
                        break;
                    case Operator.Multiplication:
                        result = Math.Multiply(lastNumber, newNumber);
                        break;
                    case Operator.Division:
                        result = Math.Divide(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber /= 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber *= -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == plusButton)
            {
                selectedOperator = Operator.Addition;
            }
            if (sender == minusButton)
            {
                selectedOperator = Operator.Subtraction;
            }
            if (sender == multiplyButton)
            {
                selectedOperator = Operator.Multiplication;
            }
            if (sender == divideButton)
            {
                selectedOperator = Operator.Division;
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }

    public enum Operator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class Math
    {
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }

        public static double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }

        public static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }

        public static double Divide(double number1, double number2)
        {
            if (number2 != 0)
            {
                return number1 / number2;
            }
            else
            {
                MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            
        }
    }
}
