using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfTableAdapter
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NorthwindDataSet dset = new NorthwindDataSet();
        public NorthwindDataSetTableAdapters.CategoriesTableAdapter catAdap = new NorthwindDataSetTableAdapters.CategoriesTableAdapter();
        public NorthwindDataSetTableAdapters.ProductsTableAdapter prodAdap = new NorthwindDataSetTableAdapters.ProductsTableAdapter();
       
        public MainWindow()
        {
            InitializeComponent();
            
            catAdap.Fill(dset.Categories);
           
            MainGrid.DataContext = dset;

            cbCategories.SelectedIndex = 0;
        }

         

        private void cbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int categoryId = 0;
            try
            {
                if (Int32.TryParse(cbCategories.SelectedValue.ToString(), out categoryId))
                {
                    prodAdap.FillByCategoryID(dset.Products, categoryId);                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al carregar les dades", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Vols desar les dades?", "Desar?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    prodAdap.Update(dset.Products);
                    MessageBox.Show("Dades desades correctament.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al desar les dades.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            dgProducts.Items.MoveCurrentToLast();
        }

    }
}
