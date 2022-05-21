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
    /// room_manage.xaml 的交互逻辑
    /// </summary>
    public partial class room_manage : Window
    {
        public room_manage()
        {
            InitializeComponent();
            DataRoompriceForm();
            load_gameli();
        }
        private void load_gameli()
        {
            //在COMBOBOX里显示
            ArrayList list1 = new ArrayList();
            string str = "select DISTINCT roomtype from room_price";
            String connetStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //dr[0]表示取结果的第一列，dr[1]就是第二列
                list1.Add(dr[0].ToString().Trim());
            }
            CB_roomtype.ItemsSource = list1;
            
            conn.Close();
        }
        private void DataRoompriceForm()
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库
                conn.Open();
                string sql = "select roomtype as 房型 ,price as 价格 from room_price";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                //创建DataSet类的对象
                DataTable ds = new DataTable();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                DG_roomprice.ItemsSource = ds.DefaultView;
                DG_roomprice.IsReadOnly = true;

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
            DataRoompriceForm();
            if (TB_price.Text == "")
            { MessageBox.Show("请输入值"); }
            else {
                int price=Convert.ToInt32(TB_price.Text);
                String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=db_hsms;";
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql4 = " UPDATE room_price set price='"+price+"' where roomtype='" + CB_roomtype.SelectedItem + "'";
                    MySqlCommand cmd = new MySqlCommand(sql4, conn);
                    int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                    if (returnvalue != -1 )
                    {
                        MessageBox.Show("修改价格成功！");
                        DataRoompriceForm();
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
    }

}
