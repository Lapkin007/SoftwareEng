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
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Odbc;
using MySql.Data.MySqlClient;

namespace Group7_Hotel_Service_Management_System
{
    /// <summary>
    /// account_manage.xaml 的交互逻辑
    /// </summary>
    public partial class account_manage : Window
    {
        public account_manage()
        {
            InitializeComponent();
            DataGameListForm();
        }

        private void B_register_Click(object sender, RoutedEventArgs e)
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                //判断用户名是否重复
                string checkNameSql = "select count(*) from admin_account_list where admin_account='{0}'";
                checkNameSql = string.Format(checkNameSql, TB_account.Text);
                //创建SqlCommand对象
                MySqlCommand cmdCheckName = new MySqlCommand(checkNameSql, conn);
                //执行SQL语句
                int isRepeatName = Convert.ToInt32(cmdCheckName.ExecuteScalar());
                if (isRepeatName != 0)
                {
                    //用户名重复，则不执行注册操作
                    MessageBox.Show("用户名已存在！");
                    DataGameListForm();
                    return;

                }
                string sql = "insert into admin_account_list(admin_account,admin_password,admin_type) values('{0}','{1}','前台')";
                //填充SQL语句
                sql = string.Format(sql, TB_account.Text, TB_password.Text);
                //创建SqlCommand对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("注册成功！");
                    DataGameListForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册失败！" + ex.Message);
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
        private void DataGameListForm()
        {
              String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
              MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库
                conn.Open();
                string sql = "select admin_account as 姓名 , admin_password as 密码,admin_type as 账号类型 from admin_account_list  ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                //创建DataSet类的对象
                DataTable ds = new DataTable();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                DG_account.ItemsSource = ds.DefaultView;
                DG_account.IsReadOnly = true;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭连接
                    conn.Close();
                }
            }
        }
        private void B_delete_Click(object sender, RoutedEventArgs e)
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                string checkNameSql = "select count(*) from admin_account_list where admin_account='{0}'";
                checkNameSql = string.Format(checkNameSql, TB_account1.Text);
                //创建SqlCommand对象
                MySqlCommand cmdCheckName = new MySqlCommand(checkNameSql, conn);
                //执行SQL语句
                int isRepeatName = Convert.ToInt32(cmdCheckName.ExecuteScalar());
                if (isRepeatName == 0)
                {
                    //用户名不存在，则不执行注册操作
                    MessageBox.Show("用户名不存在！");
                    DataGameListForm();
                    return;
                }
                string sql = "delete from admin_account_list where admin_account='{0}' and admin_password='{1}'";
                //填充SQL语句
                sql = string.Format(sql, TB_account1.Text, TB_password1.Text);
                //创建SqlCommand对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("删除成功！");
                    DataGameListForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！" + ex.Message);
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
    }
}
