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

namespace Crescenti_Ivan_A08
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NorthwindDataSet dset = new NorthwindDataSet();
        public NorthwindDataSetTableAdapters.EmployeesTableAdapter adaptadorEmployees = new NorthwindDataSetTableAdapters.EmployeesTableAdapter();
        public NorthwindDataSetTableAdapters.OrdersTableAdapter adaptadorOrders = new NorthwindDataSetTableAdapters.OrdersTableAdapter();

        private NorthwindDataSet.EmployeesRow[] employees;

        public MainWindow()
        {
            InitializeComponent();

            adaptadorEmployees.Fill(dset.Employees);
            adaptadorOrders.Fill(dset.Orders);

            MainGrid.DataContext = dset;

            employees = dset.Employees.ToArray();

            foreach (NorthwindDataSet.EmployeesRow employee in employees)
                employeesCognoms.Items.Add(employee.LastName);
        }

        private void opcioSortir_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void employeesCognoms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                gridResultats.ItemsSource = dset.Orders.Where(b => b.EmployeeID == employees[employeesCognoms.SelectedIndex].EmployeeID);
            }
            catch { }
        }

        private void opcioOrdres_Click(object sender, RoutedEventArgs e)
        {
            MantenimentOrdres manteniment = new MantenimentOrdres();
            manteniment.ShowDialog();
        }

        private void btnPrimer_Click(object sender, RoutedEventArgs e)
        {
            gridResultats.SelectedIndex = 0;
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            if (gridResultats.SelectedIndex > 0)
                gridResultats.SelectedIndex--;
        }

        private void btnSeguent_Click(object sender, RoutedEventArgs e)
        {
            if (gridResultats.SelectedIndex < gridResultats.Items.Count)
                gridResultats.SelectedIndex++;
        }

        private void btnUltim_Click(object sender, RoutedEventArgs e)
        {
            gridResultats.SelectedIndex = gridResultats.Items.Count-1;
        }
    }
}
