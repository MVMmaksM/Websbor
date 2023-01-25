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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PasswordRespondents.Model;
using PasswordRespondents.DataBase;
using System.Data.SqlClient;
using PasswordRespondents.Services;

namespace PasswordRespondents
{   
    public partial class MainWindow : Window
    {
        private DataTable _tableRespondents;
        private DataBaseWork _dbWork;
        private SqlDataAdapter _dataAdapterRespondent;
        private string _connectionString = "Data Source=p45-DB08;Initial Catalog=WebSbor_Password;Integrated Security=SSPI";
        public MainWindow()
        {
            InitializeComponent();
            _tableRespondents = new Respondent().GetDataTableRespondent();
            _dataAdapterRespondent = new DataAdapterRespondent().GetSqlDataAdapterRespondent();
            _dbWork = new DataBaseWork(_connectionString, _tableRespondents, _dataAdapterRespondent);
            _dbWork.GetShemaTable();
            dgDataPasswords.ItemsSource = _tableRespondents.DefaultView;
        }
       
        private void MainWindow_Closed(object sender, EventArgs e)
        {

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                _dbWork.UpdateDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonShowAllData_Click(object sender, RoutedEventArgs e)
        {
            _dbWork.FillToDataTable();
        }
        private void ButtonDeleteRow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonClearDataGrid_Click(object sender, RoutedEventArgs e)
        {
            _tableRespondents.Clear();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _dbWork.Search(SearchName.Text, SearchOkpo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItemLoad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemLoadWebSbor_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItemSaveAllRows_Click(object sender, RoutedEventArgs e)
        {
           FileServices.SaveFaile("C:\\Users\\p45_VaganovMV\\Desktop\\Список.xls",Excel.CreateExcelRespondent(_dbWork.GetAllRowsForSave()));
        }

        private void MenuItemSaveCurrentRows_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemShemaEcxel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemOpenProtocol_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemOpenDirectoryProtocol_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemOpenLog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemOpenDirectoryLog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemDeleteAllLog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemOpenSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgDataPasswords_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void TxtBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
