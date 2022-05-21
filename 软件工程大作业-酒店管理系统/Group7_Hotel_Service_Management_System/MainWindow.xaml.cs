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
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Odbc;
using MySql.Data.MySqlClient;

namespace Group7_Hotel_Service_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        public static string zh;//账号
        public static string mm;//密码
        public static bool lianjie;//查看数据库是否连接成功
         //连接数据库需要的项.设置公共属性静态变量，方便直接访问
       public static String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
       public MySqlConnection conn = new MySqlConnection(connStr);
       
        private void B_test_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                conn.Open();//打开通道，建立连接
                MessageBox.Show("云数据库连接成功", "Success");
                lianjie = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("连接数据库失败", "erro");  //有异常，打印错误信息到控制台
            }
            finally
            {
                conn.Close();
            }
        }

        private void B_clear_Click(object sender, RoutedEventArgs e)
        {
            TB_account.Text= null;
            TB_password.Password = null;
        }

        private void B_login_Click(object sender, RoutedEventArgs e)
        {
            if (lianjie == true)
            {
                
                
                    conn.Open();
                    string sql = "Select count(*) from admin_account_list where admin_account='{0}' and admin_password='{1}' and admin_type='{2}'";
                    //填充SQL语句
                    sql = string.Format(sql, TB_account.Text, TB_password.Password,CB_type.Text);
                    //创建SqlCommand对象
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //执行SQL语句
                    int returnvalue = Convert.ToInt32(cmd.ExecuteScalar());
                    //判断SQL语句是否执行成功
                    if (returnvalue != 0)
                    { 
                        conn.Close();
                        MessageBox.Show("登录成功！");
                    if (CB_type.Text == "前台") {
                        zh = TB_account.Text; mm = TB_password.Password;
                        Admin admin1 = new Admin();
                        App.Current.MainWindow = admin1;
                        this.Close();
                        admin1.Show();
                    }
                    else if(CB_type.Text == "管理员")
                    {
                        qiantai a = new qiantai();
                        App.Current.MainWindow = a;
                        a.Show();
                        this.Hide();
                    }
                    }
                    else
                    {
                        MessageBox.Show("登录失败！");
                        conn.Close();
                }
            }
            else { MessageBox.Show("请先测试数据库连接", "error"); }
        }
    }
}
