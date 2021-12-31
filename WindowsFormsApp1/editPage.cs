using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class editPage : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = DEPRESSION69\MSSQLSERVER2;Integrated Security = True");
        int target_id;
        public editPage(int login_as)
        {
            InitializeComponent();
            target_id = login_as;
            connection.Open();
            SqlCommand query = new SqlCommand("select * from UserData where id=" + target_id, connection);
            using (SqlDataReader sdr = query.ExecuteReader())
            {
                sdr.Read();
                fname_e.Text =  sdr["firstName"].ToString();
                sname_e.Text = sdr["secName"].ToString();

            }
            connection.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand updatePass = new SqlCommand("update UserData set password='abc1234' where id=" + target_id, connection);
            updatePass.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Password reset to 'abc1234'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fname_e.Text == "")
            {
                MessageBox.Show("First Name can not be empty");
            }
            else if (sname_e.Text=="")
            {
                MessageBox.Show("Second Name can not be empty");
            }
            else
            {
                connection.Open();
                SqlCommand updatePass = new SqlCommand("update UserData set firstName='"+fname_e.Text+ "',secName='"+sname_e.Text+"' where id=" + target_id, connection);
                updatePass.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Data Updated");

            }
        }
    }
}
