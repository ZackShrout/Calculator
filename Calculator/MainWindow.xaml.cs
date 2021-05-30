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
        double operand1, operand2, result;
        bool hasDoneEquals;
        Operator selectedOperator;


        public MainWindow()
        {
            InitializeComponent();
            hasDoneEquals = false;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!hasDoneEquals)
            {
                SingleOperation();
            }
            else
            {
                RepeatedOperation();
            }

            resultLabel.Content = result.ToString();
        }

        private void SingleOperation()
        {
            if (double.TryParse(resultLabel.Content.ToString(), out operand2))
            {
                switch (selectedOperator)
                {
                    case Operator.Addition:
                        result = Math.Add(operand1, operand2);
                        break;
                    case Operator.Subtraction:
                        result = Math.Subtract(operand1, operand2);
                        break;
                    case Operator.Multiplication:
                        result = Math.Multiply(operand1, operand2);
                        break;
                    case Operator.Division:
                        result = Math.Divide(operand1, operand2);
                        break;
                }

                hasDoneEquals = true;
            }
        }

        private void RepeatedOperation()
        {
            switch (selectedOperator)
            {
                case Operator.Addition:
                    result = Math.Add(result, operand2);
                    break;
                case Operator.Subtraction:
                    result = Math.Subtract(result, operand2);
                    break;
                case Operator.Multiplication:
                    result = Math.Multiply(result, operand2);
                    break;
                case Operator.Division:
                    result = Math.Divide(result, operand2);
                    break;
            }
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double tempNumber))
            {
                tempNumber /= 100;

                if (operand1 != 0)
                {
                    tempNumber *= operand1;
                }

                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double lastNumber))
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
            hasDoneEquals = false;
            operand1 = 0;
            operand2 = 0;
            result = 0;
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out operand1))
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

            if (resultLabel.Content.ToString() == "0" || hasDoneEquals)
            {
                resultLabel.Content = $"{selectedValue}";
                hasDoneEquals = false;
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
