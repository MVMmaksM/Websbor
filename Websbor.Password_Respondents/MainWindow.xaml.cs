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
using Websbor.PasswordRespondents.DataBaseServices;
using Websbor.PasswordRespondents.Properties;
using Websbor.PasswordRespondents.ViewModel;

namespace Websbor.PasswordRespondents
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelPasswordRespondents viewModelPasswordRespondents = new ViewModelPasswordRespondents();
            dgPasswordRespondents.ItemsSource = viewModelPasswordRespondents.DTPasswordRespondents.DefaultView;

            Websbor.PasswordRespondents.Setting.Settings settings = new Websbor.PasswordRespondents.Setting.Settings();
            settings.ConnectionString = "Initial Catalog=WebSbor_Password_Respondents;Data Source=DESKTOP-ABQGH3T;Integrated Security=True";
            
            SqlDataAdapterPasswordRespondents sqlDataAdapterPasswordRespondents = new SqlDataAdapterPasswordRespondents();
            
            DataBaseWork dataBaseWork = new DataBaseWork(settings);
            dataBaseWork.ExecDataAdapterFillToDataTable(viewModelPasswordRespondents.DTPasswordRespondents, sqlDataAdapterPasswordRespondents.sqlDataAdapter);


        }
    }
}
