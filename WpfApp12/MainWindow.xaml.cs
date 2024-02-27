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
        private void szamolGomb_Click(object sender, RoutedEventArgs e)
        {
            int szamol = 0;
            long peldaSzam = 1310438493;
            string[] szamok = File.ReadAllLines("szamok.txt");

            foreach (string szam in szamok)
            {
                if (legnagyobbKozosTobbszor(peldaSzam, long.Parse(szam)) == 1)
                {
                    szamol++;
                }
            }

            eredmenyTextBox.Text = $"Relatív prím számok száma: {szamol}";
        }

        private long legnagyobbKozosTobbszor(long a, long b)
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
