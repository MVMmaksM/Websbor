﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Websbor.Password_Respondents.Services;
using Websbor.PasswordRespondents.DataBaseServices;
using Websbor.PasswordRespondents.Properties;
using Websbor.PasswordRespondents.ViewModel;

namespace Websbor.PasswordRespondents
{
    public partial class MainWindow : Window
    {
        private DataBaseWork _dataBaseWork;
        private ViewModelPasswordRespondents _viewModelPasswordRespondents;
        private SqlDataAdapterPasswordRespondents _sqlDataAdapterPasswordRespondents;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = InfoAssembly.GetInfoAssmbly();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModelPasswordRespondents = new ViewModelPasswordRespondents();
            dgPasswordRespondents.ItemsSource = _viewModelPasswordRespondents.DTPasswordRespondents.DefaultView;

            Websbor.PasswordRespondents.Setting.Settings settings = new Websbor.PasswordRespondents.Setting.Settings();
            settings.ConnectionString = "Initial Catalog=WebSbor_Password_Respondents;Data Source=DESKTOP-ABQGH3T;Integrated Security=True";

            _sqlDataAdapterPasswordRespondents = new SqlDataAdapterPasswordRespondents();

            _dataBaseWork = new DataBaseWork(settings);
            _dataBaseWork.ExecDataAdapterFillToDataTable(_viewModelPasswordRespondents.DTPasswordRespondents, _sqlDataAdapterPasswordRespondents.sqlDataAdapter);
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

            _dataBaseWork.ExecDataAdapterUpdateToDataTable(_viewModelPasswordRespondents.DTPasswordRespondents, _sqlDataAdapterPasswordRespondents.sqlDataAdapter);
        }
        private void MenuOpenReadme_Click(object sender, RoutedEventArgs e)
        {
            Process.Start($"{Environment.CurrentDirectory}\\Readme.txt");
        }

        private void MenuOpenFolderLog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuOpenCurrentLog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuOpenSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuSaveCurrentRowsInExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuSaveAllRowsInExcel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
