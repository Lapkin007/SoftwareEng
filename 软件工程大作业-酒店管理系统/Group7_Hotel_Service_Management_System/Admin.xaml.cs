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
using System.Collections;
using System.Data.SqlClient;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;

namespace Group7_Hotel_Service_Management_System
{
    /// <summary>
    /// Admin.xaml 的交互逻辑
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            DataLivetForm();
            DataReservetForm();
            

        }
       
        private void DataLivetForm()
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库
                conn.Open();
                string sql = "select name as 姓名 ,tel as 电话  ,roomtype as 房间类型, roomid as 房间号,arrive_date as 预约到达日期,leave_date as 预约离开日期 from live";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                //创建DataSet类的对象
                DataTable ds = new DataTable();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                DG_live.ItemsSource = ds.DefaultView;
                DG_live.IsReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }
        private void DataReservetForm()
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库
                conn.Open();
                string sql = "select name as 姓名 ,tel as 电话  ,roomtype as 房间类型, roomid as 房间号,arrive_date as 到达日期,leave_date as 离开日期 from reserve";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                //创建DataSet类的对象
                DataTable ds = new DataTable();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                DG_reserve.ItemsSource = ds.DefaultView;
                DG_reserve.IsReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }
        private void B_reserve_Click(object sender, RoutedEventArgs e)
        {
            //预约页面显示
            Reserve Reserve1 = new Reserve();
            Reserve1.Show();
            DataLivetForm();
            DataReservetForm();

        }

        private void B_reserve_confirm_Click(object sender, RoutedEventArgs e)
        {
            //预约确认页面显示
            Reserve_confirm reserve_Confirm1 = new Reserve_confirm();
            reserve_Confirm1.Show();
            DataLivetForm();
            DataReservetForm();
        }

        private void B_confirm_in_Click(object sender, RoutedEventArgs e)
        {
            //现场入住页面显示
            DirectIn directIn1 = new DirectIn();
            directIn1.Show(); DataLivetForm();
            DataReservetForm();
        }

        private void B_checkromm_Click(object sender, RoutedEventArgs e)
        {
            //查看房间页面显示
            checkroom checkroom1 = new checkroom();
            checkroom1.Show(); DataLivetForm();
            DataReservetForm();
        }



        private void B_quitromm_Copy_Click(object sender, RoutedEventArgs e)
        {
            //查看缴费界面
            pay pay1=new pay();
            pay1.Show(); DataLivetForm();
            DataReservetForm();
        }

  

        private void B_quitromm_Click(object sender, RoutedEventArgs e)
        {
            //查看退房界面
            quitroom quitroom1 = new quitroom();
            quitroom1.Show(); DataLivetForm();
            DataReservetForm();
        }

        private void B_hotellife_Click(object sender, RoutedEventArgs e)
        {
            //查看酒店生活界面
            hotellife hotellife1 =new hotellife();
            hotellife1.Show(); DataLivetForm();
            DataReservetForm();
        }


        private void B_room_reflash_click(object sender, RoutedEventArgs e)
        {
            DataLivetForm();
            DataReservetForm();
        }
    }
}
