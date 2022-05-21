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
    /// hotellife.xaml 的交互逻辑
    /// </summary>
    public partial class hotellife : Window
    {
        public hotellife()
        {
            InitializeComponent();
            DataGoodForm();
            load_gameli();
        }
        private void load_gameli()
        {
            //在COMBOBOX里显示
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            string str = "select DISTINCT good from good_storage";
            string str2 = "select  roomid from room_statue where statue='有人'";
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
            CB_roomtype.ItemsSource = list1;
            CB_roomtype_Copy.ItemsSource = list1;
            CB_roomtype_Copy1.ItemsSource = list1;
            CB_roomid.ItemsSource = list2;
            conn.Close();
        }
        private void load_gameli1()
        {
            //在COMBOBOX里显示
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            string str = "select DISTINCT roomtype from room_statue where statue='空' ";
            string str2 = "select  roomid from room_statue where statue='空' and roomtype='" + CB_roomtype.SelectedItem + "'";
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
            CB_roomtype.ItemsSource = list1;
            CB_roomid.ItemsSource = list2;
            conn.Close();
        }
        private void DataGoodForm()
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库
                conn.Open();
                string sql = "select good as 商品 ,number as 库存,good_price as 价格 from good_storage";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                //创建DataSet类的对象
                DataTable ds = new DataTable();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                DG_good.ItemsSource = ds.DefaultView;
                DG_good.IsReadOnly = true;

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

        private void B_change_Click(object sender, RoutedEventArgs e)
        {
            load_gameli();
            DataGoodForm();
            if (TB_price.Text == "")
            { MessageBox.Show("请输入值"); }
            else
            {
                double price = Convert.ToDouble(TB_price.Text);
                String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql4 = " UPDATE good_storage set good_price='" + price + "' where good='" + CB_roomtype.SelectedItem + "'";
                    MySqlCommand cmd = new MySqlCommand(sql4, conn);
                    int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                    if (returnvalue != -1)
                    {
                        MessageBox.Show("修改价格成功！");
                        DataGoodForm();
                        load_gameli();

                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
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
        }

        private void B_ruku_Click(object sender, RoutedEventArgs e)
        {
            load_gameli();
            DataGoodForm();
            if (TB_in_number.Text == "")
            { MessageBox.Show("请输入值"); }
            else
            {
                int num = Convert.ToInt32(TB_in_number.Text);
                String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql4 = " UPDATE good_storage set number=number +" + num + " where good='" + CB_roomtype_Copy.SelectedItem + "'";
                    MySqlCommand cmd = new MySqlCommand(sql4, conn);
                    int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                    if (returnvalue != -1)
                    {
                        MessageBox.Show("入库成功！");
                        DataGoodForm();
                        load_gameli();

                    }
                    else
                    {
                        MessageBox.Show("修改库存失败！");
                    }
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
        }

        private void B_chuku_Click(object sender, RoutedEventArgs e)
        {
            //double price = Convert.ToDouble(TB_price.Text);
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
            MySqlConnection conn = null;
            try
            {
                int jss = 1;
                conn = new MySqlConnection(connStr);
                conn.Open();
                string sql4 = "UPDATE good_storage set number=number-" + jss + " where good='" + CB_roomtype_Copy1.SelectedItem + "'";
                string sql = "INSERT into good_provide(roomid,good,good_price) value('"+CB_roomid.Text+ "','" + CB_roomtype_Copy1.SelectedItem + "',3.33)";
                string sql2 = "Update good_provide set good_price=(SELECT good_price from good_storage where good='" + CB_roomtype_Copy1.SelectedItem + "'and roomid='" + CB_roomid.Text + "' )where good_price=3.33";
                MySqlCommand cmd = new MySqlCommand(sql4, conn);
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery()); int returnvalue1 = Convert.ToInt32(cmd1.ExecuteNonQuery()); int returnvalue2 = Convert.ToInt32(cmd2.ExecuteNonQuery());
                if (returnvalue != -1&& returnvalue1 != -1 && returnvalue2 != -1)
                {
                    MessageBox.Show("出库成功！");
                    DataGoodForm();
                    load_gameli();

                }
                else
                {
                    MessageBox.Show("失败！");
                }
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
    }
}
