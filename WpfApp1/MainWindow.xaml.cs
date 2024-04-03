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
using Library;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        QuadraticEquation qe;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            labelDescr.Content = "Здесь будет размещено уравнение";
            labelDecision.Content = "Здесь будет размещено решение";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            double a;
            if (!double.TryParse(tb.Text, out a))
                tb.Foreground = Brushes.Red;
            else
                tb.Foreground = Brushes.Black;
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                qe = new QuadraticEquation();
                qe.A1 = tb1.Text;
                qe.B1 = tb2.Text;
                qe.C1 = tb3.Text;
                labelDescr.Content = qe.inscription();
                qe.decision();
                labelDecision.Content = qe.GetAnswers();
            }
            catch (ArgumentException)
            {
                labelDecision.Content = "Неправильный ввод данных";
            }
        }
        private void btnExample_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            try
            {
                QuadraticEquation qe = new QuadraticEquation();
                labelDescr.Content = qe.inscription();
                qe.decision();
                labelDecision.Content = qe.GetAnswers();
            }
            catch (ArgumentException)
            {
                labelDecision.Content = "Неправильный ввод данных";
            }
        }
    }
}
