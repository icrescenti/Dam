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

namespace M07UF1EX2IvanCrescentiHernandez
{
    /// <summary>
    /// Lógica de interacción para UsrTextEdit.xaml
    /// </summary>
    public partial class UsrTextEdit : UserControl
    {

        public UsrTextEdit()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public static DependencyProperty SetLabelText = DependencyProperty.Register("labelText", typeof(string), typeof(UsrTextEdit));
        public static DependencyProperty SetUserText = DependencyProperty.Register("campText", typeof(string), typeof(UsrTextEdit));

        public string labelText
        {
            get { return (string)GetValue(SetLabelText); }
            set { SetValue(SetLabelText, value); }
        }
        public string campText
        {
            get { return (string)GetValue(SetUserText); }
            set { SetValue(SetUserText, value); }
        }

        private void tbxCamp_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.campText = tbxCamp.Text;
        }
    }
}
