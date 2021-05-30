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
        double lastNumber;
        double result;
        
        public MainWindow()
        {
            InitializeComponent();

            signButton.Click += SignButton_Click;
            percentButton.Click += PercentButton_Click;
            nineButton.Click += NineButton_Click;
            eightButton.Click += EightButton_Click;
            sixButton.Click += SixButton_Click;
            fiveButton.Click += FiveButton_Click;
            fourButton.Click += FourButton_Click;
            threeButton.Click += ThreeButton_Click;
            twoButton.Click += TwoButton_Click;
            oneButton.Click += OneButton_Click;
            zeroButton.Click += ZeroButton_Click;
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

        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() != "0")
            {
                resultLabel.Content = $"{resultLabel.Content}0";
            }
        }

        private void OneButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "1";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}1";
            }
        }

        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "2";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}2";
            }
        }

        private void ThreeButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "3";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}3";
            }
        }

        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "4";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}4";
            }
        }

        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "5";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}5";
            }
        }

        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "6";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}6";
            }
        }

        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "7";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}7";
            }
        }

        private void EightButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "8";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}8";
            }
        }

        private void NineButton_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "9";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}9";
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }
    }
}
