using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;

namespace Group7_Hotel_Service_Management_System
{
    /// <summary>
    /// qiantai.xaml 的交互逻辑
    /// </summary>
    public partial class qiantai : Window
    {
        public qiantai()
        {
            InitializeComponent();
        }


        private void B_checkhistory_Click(object sender, RoutedEventArgs e)
        {
            History history1 = new History();
            history1.Show(); 
        }

        private void B_register_Click(object sender, RoutedEventArgs e)
        {
            account_manage account_manage1 = new account_manage();
            account_manage1.Show();
        }

        private void B_room_manage_Click(object sender, RoutedEventArgs e)
        {
            room_manage room_manage1 = new room_manage();
            room_manage1.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
