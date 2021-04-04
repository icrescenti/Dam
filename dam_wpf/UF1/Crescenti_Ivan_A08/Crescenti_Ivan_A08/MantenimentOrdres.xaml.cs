using System;
using System.Collections.Generic;
using System.Data;
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

namespace Crescenti_Ivan_A08
{
    /// <summary>
    /// Lógica de interacción para MantenimentOrdres.xaml
    /// </summary>
    public partial class MantenimentOrdres : Window
    {
        public NorthwindDataSet dset = new NorthwindDataSet();
        public NorthwindDataSetTableAdapters.OrdersTableAdapter adaptadorOrders = new NorthwindDataSetTableAdapters.OrdersTableAdapter();
        public NorthwindDataSetTableAdapters.Order_DetailsTableAdapter adaptadorOrderDetalls = new NorthwindDataSetTableAdapters.Order_DetailsTableAdapter();

        public MantenimentOrdres(int ordreId)
        {
            InitializeComponent();

            adaptadorOrders.Fill(dset.Orders);
            adaptadorOrderDetalls.Fill(dset.Order_Details);
            gridOrdreDetalls.DataContext = dset;

            IEnumerable<Crescenti_Ivan_A08.NorthwindDataSet.OrdersRow> itemOrder = (IEnumerable<Crescenti_Ivan_A08.NorthwindDataSet.OrdersRow>)dset.Orders.Where(b => b.OrderID == ordreId);
            gridOrdreDetalls.ItemsSource = dset.Order_Details.Where(b => b.OrderID == ordreId);

            System.Data.DataRow rowOrdre = (System.Data.DataRow)itemOrder.ToArray().First();

            tbx_orderID.Text = rowOrdre["OrderID"].ToString();
            tbx_employeeID.Text = rowOrdre["EmployeeID"].ToString();
            dta_shippedDate.Text = rowOrdre["ShippedDate"].ToString();
            tbx_shippedName.Text = rowOrdre["ShipName"].ToString();
            tbx_customerID.Text = rowOrdre["CustomerID"].ToString();
            dta_orderDate.Text = rowOrdre["OrderDate"].ToString();
            tbx_shopVia.Text = rowOrdre["ShipVia"].ToString();
            tbx_shopAddress.Text = rowOrdre["ShipAddress"].ToString();
            tbx_shopPostalCode.Text = rowOrdre["ShipPostalCode"].ToString();
            dta_requiredDate.Text = rowOrdre["RequiredDate"].ToString();
            tbx_freight.Text = rowOrdre["Freight"].ToString();
            tbx_shipCity.Text = rowOrdre["ShipCity"].ToString();
            tbx_shipCountry.Text = rowOrdre["ShipCountry"].ToString();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
