using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICalculator _Calculator;
        //1 * 2 / 3 0 0 0 0 00 0 0 0 0 00 0 0
        List<String> List = Enumerable.Repeat(string.Empty, 100).ToList();
        int index = 0;

        ArrayList Array = new ArrayList();
        public MainWindow()
        {
          
            _Calculator = new MyCalculator();
            InitializeComponent();
        }

        private void ButtonEquals(object sender, RoutedEventArgs e)
        {
            var calculation_result = _Calculator.CalculateExpresion(List);
            
            txtDisplay.Text = calculation_result.ToString();
            index = 0;
            List = Enumerable.Repeat(string.Empty, 100).ToList();
            List[index] = calculation_result.ToString();
        }

        private void ButtonNumbersClick(object sender, RoutedEventArgs e)
        {
            Button numberButton = sender as Button;
            
           if(txtDisplay.Text == "0")
            {
                txtDisplay.Text = numberButton.Content.ToString();
            }
            else
            {
                txtDisplay.Text += numberButton.Content.ToString();
                
            }
            List[index] += numberButton.Content.ToString();
        }

        private void ClearButton(object sender, RoutedEventArgs e)
        {

            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
            }
            if(List[index] == "" && index > 0)
            {
                index--;
            }
            if(List[index] != "")
            {
                List[index] = List[index].Remove(List[index].Length - 1, 1);
            }
        }

        private void SeperatorButton(object sender, RoutedEventArgs e)
        {
            Button seperatorButton = sender as Button;
            txtDisplay.Text += seperatorButton.Content.ToString();
            index++;
            List[index] += seperatorButton.Content.ToString();
            index++;
        }

        private void ResetButton(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            index = 0;
            List = Enumerable.Repeat(string.Empty, 100).ToList();
        }
    }
}
