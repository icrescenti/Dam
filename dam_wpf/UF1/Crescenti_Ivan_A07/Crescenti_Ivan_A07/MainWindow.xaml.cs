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
using System.Xml.Serialization;

namespace Crescenti_Ivan_A07
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> llistaEmpleats = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();

            string fitxer = Environment.CurrentDirectory + "/XMLEmployees.xml";

            if (!File.Exists(fitxer))
            {
                Employee emp = new Employee("Joe");
                llistaEmpleats.Add(emp);

                Guardar(llistaEmpleats, fitxer);
            }

            llistaEmpleats = Llegir(fitxer);
            llistaEmployees.ItemsSource = llistaEmpleats;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(llistaEmployees.ItemsSource);
        }

        #region Guardar
        static void Guardar(List<Employee> array_employees, string ruta)
        {
            //Definim el objecte que ens permet serialitzar amb xml
            //Inicialitzat el serialitzador amb el tipus de el objecte Concessionari
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Employee>));

            #region generacio i escriptura
            //Obrim un fitxer en mode de escriptura
            FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.Write);

            //Serialitzaem el objecte a el filestrem
            serialitzador.Serialize(fs, array_employees);

            #endregion

            #region metodes per tencar, netejar i deixar de utilitzar el fitxer
            fs.Flush();
            fs.Close();
            fs.Dispose();
            #endregion

        }

        #endregion

        #region Llegir
        static List<Employee> Llegir(string rutafitxer)
        {
            List<Employee> array_employees = null;
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Employee>));
            FileStream lector;

            #region validacio i obrim lectura de el fitxer
            if (File.Exists(rutafitxer))
                lector = new FileStream(rutafitxer, FileMode.Open, FileAccess.Read);
            else return null;
            #endregion

            //DESERIALITZACIO
            array_employees = (List<Employee>)serialitzador.Deserialize(lector);

            #region tencament de el fitxer properament
            lector.Close();
            lector.Dispose();
            #endregion

            return array_employees;
        }

        #endregion

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditarEmployee edemployees = new EditarEmployee();
            edemployees.Show();
        }


        private void finsetra0_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            foreach (Employee employee in llistaEmpleats)
            {
                ListBoxItem listitem = (ListBoxItem)(llistaEmployees.ItemContainerGenerator.ContainerFromIndex(i));
                
                if (employee.Country == "US")
                {
                    listitem.Foreground = new SolidColorBrush(Color.FromRgb(50, 74, 168));
                }
                else
                {
                    listitem.Foreground = new SolidColorBrush(Color.FromRgb(50, 168, 82));
                }
                i++;
            }
        }
    }
}
