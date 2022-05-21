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
    /// pay.xaml 的交互逻辑
    /// </summary>
    public partial class pay : Window
    {
        public pay()
        {
            InitializeComponent();
            load_gameli();
        }
        public static int day;
        public static double sum1;
        public static double sum2;
        private void load_gameli()
        {
            //在COMBOBOX里显示
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            string str = "select DISTINCT name from live";
            string str2 = "select  roomid from live where name='" + CB_name.SelectedItem + "'";
            String connetStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(str, conn);
            MySqlDataAdapter de = new MySqlDataAdapter(str2, conn);
            DataSet ds = new DataSet();
            DataSet db = new DataSet();
            da.Fill(ds);
            de.Fill(db);
            DataTable dt = ds.Tables[0];
            DataTable dd = db.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //dr[0]表示取结果的第一列，dr[1]就是第二列
                list1.Add(dr[0].ToString().Trim());
            }
            foreach (DataRow dp in dd.Rows)
            {
                //dr[0]表示取结果的第一列，dr[1]就是第二列
                list2.Add(dp[0].ToString().Trim());
            }
            CB_name.ItemsSource = list1;
            CB_id.ItemsSource = list2;
            conn.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (CB_id.Text!=""&& CB_name.Text!="") {
                string connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
                //创建 SqlConnection的实例
                MySqlConnection conn = null;
                //定义SqlDataReader类的对象
                MySqlDataReader dr = null;
                
                try
                {
                    conn = new MySqlConnection(connStr);
                    //打开数据库连接
                    conn.Open();
                    string sql = "select arrive_date,leave_date from live where roomid='666'";
                    //填充SQL语句

                    //创建SqlCommand对象
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //执行Sql语句
                    dr = cmd.ExecuteReader();
                    //判断SQL语句是否执行成功
                    if (dr.Read())
                    {

                        //读取指定的日期
                        string msg = "入住酒店日期：" + dr[0] + "  离开酒店日期：" + dr[1];
                        DateTime date1 = Convert.ToDateTime(dr[0]);
                        DateTime date2 = Convert.ToDateTime(dr[1]);
                        TimeSpan span = date2.Subtract(date1);
                        int dayoff = span.Days;
                        day = dayoff;
                        L2.Content = "总计日期:" + dayoff;
                        //将msg的值显示在标签上
                        L1.Content = msg;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询失败！" + ex.Message);
                }
                finally
                {
                    if (dr != null)
                    {
                        //判断dr不为空，关闭SqlDataReader对象
                        dr.Close();
                    }
                    if (conn != null)
                    {
                        //关闭数据库连接
                        conn.Close();
                    }
                }
             
                MySqlDataReader df = null;
                try
                {
                    conn = new MySqlConnection(connStr);
                    //打开数据库连接
                    conn.Open();
                    string sql = "select roomtype,price from room_price where roomtype=(select roomtype from live where name='"+CB_name.Text +"' and roomid='"+CB_id.Text +"')";
                    //创建SqlCommand对象
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //执行Sql语句
                    df = cmd.ExecuteReader();
                    //判断SQL语句是否执行成功
                    if (df.Read())
                    {
                        int date1 = Convert.ToInt32(df[1]);
                        sum1 = Convert.ToDouble( date1 * day);
                        L_p1.Content = date1 * day;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询失败！" + ex.Message);
                }
                finally
                {
                    if (df != null)
                    {
                        //判断dr不为空，关闭SqlDataReader对象
                        df.Close();
                    }
                    if (conn != null)
                    {
                        //关闭数据库连接
                        conn.Close();
                    }
                }
                
                MySqlDataReader dh = null;

                try
                {
                    conn = new MySqlConnection(connStr);
                    //打开数据库连接
                    conn.Open();
                    string sql = "select sum(good_price), sum(good_price) from good_provide where roomid='" + CB_id.SelectedItem + "'";
                    //创建SqlCommand对象
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //执行Sql语句
                    dh = cmd.ExecuteReader();
                    //判断SQL语句是否执行成功
                    if (dh.Read())
                    {

                        double ms = Convert.ToDouble(dh[0]);
                        L_p2.Content =ms;
                        sum2 = ms;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询失败！" + ex.Message);
                }
                finally
                {
                    if (dh != null)
                    {
                        //判断dr不为空，关闭SqlDataReader对象
                        dh.Close();
                    }
                    if (conn != null)
                    {
                        //关闭数据库连接
                        conn.Close();
                    }
                }
                L3.Content =Convert.ToString(sum1+sum2);
            } 
            else
            {
                MessageBox.Show("输入不能为空");
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            L_p1.Content = "*****";
            L_p2.Content = "*****";
            L1.Content = "";
            L3.Content = "*****";
            L2.Content = "";
            CB_name.Text = "";
            CB_id.Text = "";
            load_gameli();
        }

        private void CB_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            load_gameli();
        }
    }
    }
    

