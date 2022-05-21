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
    /// DirectIn.xaml 的交互逻辑
    /// </summary>
    public partial class DirectIn : Window
    {
        public DirectIn()
        {
            InitializeComponent();
            load_gameli();
            DataGameListForm();
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
                string sql = "select roomtype as 房间类型 ,roomid as 房间号  ,statue as 房间状态 from room_statue";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                //创建DataSet类的对象
                DataTable ds = new DataTable();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                DG_restroom.ItemsSource = ds.DefaultView;
                DG_restroom.IsReadOnly = true;

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
        private void load_gameli()
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

        private void B_direct_check_in_Click(object sender, RoutedEventArgs e)
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                //判断用户名是否重复           
                string sql = "insert into history values('" + TB_name.Text + "','" + TB_tel.Text + "','" + CB_roomtype.SelectedItem + "','" + CB_roomid.SelectedItem + "','" + DP_arrive.Text + "','" + DP_leave.Text + "','"+TB_persionid.Text+"')";
                //填充SQL语句
                string sql2 = "insert into live values('" + TB_name.Text + "','" + TB_tel.Text + "','" + CB_roomtype.SelectedItem + "','" + CB_roomid.SelectedItem + "','" + DP_arrive.Text + "','" + DP_leave.Text + "')";
                //填充SQL语句
                string sql1 = " UPDATE room_statue set statue='有人' where roomid='" + CB_roomid.SelectedItem + "'";
                //创建SqlCommand对象
                MySqlCommand cmd  =  new MySqlCommand(sql, conn);
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);

                //判断SQL语句是否执行成功
                if (TB_name.Text == "" || this.TB_name.Text.IndexOf(" ") == 0)
                {
                    MessageBox.Show("请输入姓名");
                }

                else if (this.TB_tel.Text.IndexOf(" ") == 0 || TB_tel.Text == "")
                {
                    MessageBox.Show("输入不合法");
                }
                else if (this.CB_roomtype.Text.IndexOf(" ") == 0 || CB_roomtype.Text == "")
                {
                    MessageBox.Show("输入不合法");
                }
                else if (this.CB_roomid.Text.IndexOf(" ") == 0 || CB_roomid.Text == "")
                {
                    MessageBox.Show("输入不合法");
                }
                else if (this.DP_arrive.Text.IndexOf(" ") == 0 || DP_arrive.Text == "")
                {
                    MessageBox.Show("输入不合法");
                }
                else if (this.DP_leave.Text.IndexOf(" ") == 0 || DP_leave.Text == "")
                {
                    MessageBox.Show("输入不合法");
                }
                else if (this.TB_persionid.Text.IndexOf(" ") == 0 || TB_persionid.Text == "")
                {
                    MessageBox.Show("输入不合法");
                }
                else
                {
                    int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                    int returnvalue1 = Convert.ToInt32(cmd1.ExecuteNonQuery());
  
                    int returnvalue2 = Convert.ToInt32(cmd2.ExecuteNonQuery());
                    if (returnvalue != -1 && returnvalue1 != -1 && returnvalue2 != -1)
                    {
                        MessageBox.Show("入住成功！");
                        DataGameListForm();
                        load_gameli();
 
                    }
                    else
                    {
                        MessageBox.Show("入住失败！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("入住失败！" + ex.Message);
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

        private void CB_roomtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            load_gameli();
        }
    }
}
