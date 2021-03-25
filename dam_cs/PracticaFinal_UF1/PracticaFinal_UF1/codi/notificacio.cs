using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PracticaFinal_UF1
{
    public class notificacio
    {
        public static void mostrar(bool error, string titol, string missatge)
        {
            MessageBoxImage icone;

            if (error) icone = MessageBoxImage.Error;
            else icone = MessageBoxImage.Asterisk;

            MessageBox.Show(missatge, titol, MessageBoxButton.OK, icone);
        }
    }
}
