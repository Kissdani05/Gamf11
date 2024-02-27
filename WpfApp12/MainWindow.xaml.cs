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
        private void btnAnagrammaSzamolas_Click(object sender, RoutedEventArgs e)
        {
            anagrammaSzamolas();
        }

        private void btnLeggyakoribbKetjegyuSzam_Click(object sender, RoutedEventArgs e)
        {
            leggyakoribbKetjegyuSzam();
        }
        private void anagrammaSzamolas()
        {
            string mintaSzam = "2354211341";
            string rendezettMinta = String.Concat(mintaSzam.OrderBy(c => c));
            string[] szamok = File.ReadAllLines("szamok.txt");
            HashSet<string> egyediAnagrammak = new HashSet<string>();

            foreach (string szam in szamok)
            {
                if (String.Concat(szam.OrderBy(c => c)) == rendezettMinta && szam != mintaSzam)
                {
                    egyediAnagrammak.Add(szam);
                }
            }
            anagrammaTextBox.Text = $"Egyedi anagrammák száma: {egyediAnagrammak.Count}";
        }
        private void leggyakoribbKetjegyuSzam()
        {
            string[] szamok = File.ReadAllLines("szamok.txt");
            Dictionary<string, int> szamParok = new Dictionary<string, int>();

            foreach (string szam in szamok)
            {
                for (int i = 0; i < szam.Length - 1; i++)
                {
                    string par = szam.Substring(i, 2);
                    if (szamParok.ContainsKey(par))
                    {
                        szamParok[par]++;
                    }
                    else
                    {
                        szamParok.Add(par, 1);
                    }
                }
            }

            var leggyakoribb = szamParok.OrderByDescending(x => x.Value).First();
            leggyakoribbTextBox.Text = $"Leggyakoribb kétjegyű szám: {leggyakoribb.Key}, előfordulása: {leggyakoribb.Value}";
        }

    }
}
