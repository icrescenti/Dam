using System;
using System.IO;
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
using System.Windows.Shapes;

namespace Crescenti_Ivan_A07
{
    /// <summary>
    /// Lógica de interacción para EditarEmployee.xaml
    /// </summary>
    public partial class EditarEmployee : Window
    {
        Employee emp;

        public EditarEmployee()
        {
            InitializeComponent();
            MainWindow finestra0 = (MainWindow)Application.Current.MainWindow;
            DataContext = finestra0.llistaEmployees.SelectedItem;
            emp = (Employee)finestra0.llistaEmployees.SelectedItem;
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            if (validat())
                Close();
        }

        bool validat()
        {
            if (
                !String.IsNullOrEmpty(txtNom.Text) &&
                !String.IsNullOrEmpty(txtCognom.Text)
            )
            {
                if (File.Exists(txtImatge.Text))
                    return true;
                else
                    msg("La imatge no existeix");
            }
            else
                msg("Has de emplenar la informacio del nom i cognom");

            return false;
        }

        private void finestra1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!validat())
                e.Cancel = true;
        }

        void msg(string contingut)
        {
            MessageBox.Show(contingut, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
