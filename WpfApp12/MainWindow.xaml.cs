using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp12
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
        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            long referenceNumber = 1310438493;
            string[] numbers = File.ReadAllLines("szamok.txt");

            foreach (string number in numbers)
            {
                if (GCD(referenceNumber, long.Parse(number)) == 1)
                {
                    count++;
                }
            }

            resultTextBox.Text = $"Relatív prím számok száma: {count}";
        }

        private long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
