using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Crescenti_Ivan_A03
{
    public class Altres
    {
        public static void notficiacio(string missatge, string titol = "Error", MessageBoxButton boto = MessageBoxButton.OK, MessageBoxImage img = MessageBoxImage.Error)
        {
            MessageBox.Show(missatge, titol, boto, img);
        }
    }
}
