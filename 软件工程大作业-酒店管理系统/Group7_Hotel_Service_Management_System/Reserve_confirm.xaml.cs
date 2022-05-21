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
    /// Reserve_confirm.xaml 的交互逻辑
    /// </summary>
    public partial class Reserve_confirm : Window
    {
        public Reserve_confirm()
        {
            InitializeComponent();
            DataGameListForm();
            load_gameli();
            DataGameListForm2();
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
                string sql = "select name as 姓名 ,tel as 电话  ,roomtype as 房间类型, roomid as 房间号,arrive_date as 到达日期,leave_date as 离开日期 from reserve";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                //创建DataSet类的对象
                DataTable ds = new DataTable();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                DG_reserve_confirm.ItemsSource = ds.DefaultView;
                DG_reserve_confirm.IsReadOnly = true;

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
        private void DataGameListForm2()
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库
                conn.Open();
                string sql = "select name as 姓名 ,tel as 电话  ,roomtype as 房间类型, roomid as 房间号,arrive_date as 到达日期,leave_date as 离开日期 from live";
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
        private void B_reserve_confirm_Click(object sender, RoutedEventArgs e)

        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库连接
                conn.Open();          
                string sql = "INSERT into history(name,tel,roomtype,roomid,arrive_date,leave_date) SELECT * from reserve where roomid='"+CB_id.SelectedItem+"' ";
                string sql1 = " UPDATE history set person_id='"+persion_id.Text+"' where roomid='"+CB_id.SelectedItem+"'";
                string sql4 = " UPDATE room_statue set statue='有人' where roomid='" + CB_id.SelectedItem + "'";
                string sql2 = "delete from reserve where name='" + CB_name.SelectedItem + "' and roomid='" + CB_id.SelectedItem + "'";
                string sql3 = "INSERT into live select * from reserve where name='"+CB_name.SelectedItem+"' and roomid='"+CB_id.SelectedItem+"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
               
                //判断SQL语句是否执行成功
                if (this.CB_name.Text.IndexOf(" ") == 0 || CB_name.Text == "")
                {
                    MessageBox.Show("请输入姓名");
                }
                else if(this.CB_id.Text.IndexOf(" ") == 0 || CB_id.Text == "")
                {
                    MessageBox.Show("请输入房间号");
                }
                else if (this.persion_id.Text.IndexOf(" ") == 0 || persion_id.Text == "")
                {
                    MessageBox.Show("请输入身份证号");
                }
                else 
                {
                    int returnvalue4 = Convert.ToInt32(cmd4.ExecuteNonQuery());
                    int returnvalue3 = Convert.ToInt32(cmd3.ExecuteNonQuery());
                    int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                    int returnvalue1 = Convert.ToInt32(cmd1.ExecuteNonQuery());
                    int returnvalue2 = Convert.ToInt32(cmd2.ExecuteNonQuery());
                    if (returnvalue != -1 && returnvalue1 != -1 && returnvalue2 != -1 && returnvalue3 != -1)
                    {
                        MessageBox.Show("确认成功！");
                        DataGameListForm();
                        DataGameListForm2();
                        load_gameli();
                    }
                    else
                    {
                        MessageBox.Show("确认失败！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("确认失败！" + ex.Message);
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
        private void load_gameli()
        {
            //在COMBOBOX里显示
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            string str = "select DISTINCT name from reserve";
            string str2 = "select  roomid from reserve where name='"+CB_name.SelectedItem+"'";
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

        private void CB_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            load_gameli();
        }
    }
}
