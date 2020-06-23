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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calc;
        public MainWindow()
        {
            InitializeComponent();
            calc = new Calculator();
            calc.DidUpdateValue += calc_DidUpdate;
            calc.InputError += calc_Error;
            calc.CalculationError += calc_Error;
        }

        private void calc_Error(object sender, string e)
        {
            MessageBox.Show(e, "Calculator Error",MessageBoxButton.OK,MessageBoxImage.Warning);
        }

        private void calc_DidUpdate(Calculator sender, double value, int precision)
        {
            Result_Text_Block.Text = $"{value}";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = (sender as Button).Content.ToString();
            string name = (sender as Button).Name;
            int digit;
            if (int.TryParse(text, out digit))
            {
                calc.AddDigit(digit);
            }
            else
            {
                switch (name)
                {
                    case "dec":
                        calc.AddDecimalPoint();
                        break;
                    case "evaluate":
                        calc.Compute();
                        break;
                    case "addition":
                        calc.AddOperation(Operation.Add);
                        break;
                    case "substraction":
                        calc.AddOperation(Operation.Sub);
                        break;
                    case "multiplication":
                        calc.AddOperation(Operation.Mul);
                        break;
                    case "division":
                        calc.AddOperation(Operation.Div);
                        break;
                    case "clear":
                        calc.Clear();
                        break;
                    case "reset":
                        calc.Reset();
                        break;
                    case "back":
                        calc.ClearSimbol();
                        break;
                    case "pow":
                        calc.AddOperation(Operation.Pow);
                        break;
                    case "sqrt":
                        calc.AddOperation(Operation.Sqrt);
                        break;
                    case "log":
                        calc.AddOperation(Operation.Log);
                        break;
                    case "tan":
                        calc.AddOperation(Operation.Tan);
                        break;
                    case "Cos":
                        calc.AddOperation(Operation.Cos);
                        break;
                    case "Sin":
                        calc.AddOperation(Operation.Sin);
                        break;
                    case "inter":
                        calc.AddOperation(Operation.Interest);
                        break;
                    case "sign":
                        calc.Sign();
                        break;
                    case "exit":
                        this.Close();
                        break;
                }
            }
        }
    }
}
