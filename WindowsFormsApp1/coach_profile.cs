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
    public partial class coach_profile : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = DEPRESSION69\MSSQLSERVER2;Integrated Security = True");
        int mainID;
        int loginAs;
        public coach_profile(int loginn)
        {

            InitializeComponent();
            loginAs = loginn;
            connection.Open();
            string fName;
            string sName;
            SqlCommand idquery = new SqlCommand("select * from UserData where id=" + loginAs, connection);
            using (SqlDataReader sdr = idquery.ExecuteReader())
            {
                sdr.Read();
                fName = sdr["firstName"].ToString();
                sName = sdr["secName"].ToString();

               


            }
            label5.Text=fName+" "+sName;
            connection.Close();

            connection.Open();
            SqlCommand coachQ = new SqlCommand("select coach.id,username,firstName,secName from UserData inner join coach on coach.id=UserData.id", connection);

            using (SqlDataReader coachRead = coachQ.ExecuteReader())
            {
                while (coachRead.Read())
                {
                    string tempVal = coachRead["username"].ToString();
                    showCo.Items.Add(tempVal);

                }






            }
            connection.Close();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int coachID;
            connection.Open();
            SqlCommand insertuserC = new SqlCommand("insert into team (name,captain_id,coach_id) values ('" + teamName_t.Text + "','" + 0 + "','" + mainID +    "')", connection);

            try
            {

                insertuserC.ExecuteNonQuery();
                MessageBox.Show("User Data Updated");


            }
            catch (SqlException)
            {
                MessageBox.Show("Use Unique Username");
            }
            connection.Close();
            connection.Open();
        }

        private void showCo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = showCo.SelectedItem.ToString();
            connection.Open();
            MessageBox.Show(showCo.SelectedItem.ToString());
            SqlCommand idquery = new SqlCommand("select Id from UserData where username='" +selectedItem+"'" , connection);
            mainID = (int)idquery.ExecuteScalar();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(player_e.Text=="")
            {
                MessageBox.Show("Player ID can not be  empty");
            }
            else
            {
                int search_id;
                search_id = Convert.ToInt32(player_e.Text);
                connection.Open();
                SqlCommand idquery = new SqlCommand("SELECT * from player where player_id=" + search_id, connection);
                using (SqlDataReader sdr = idquery.ExecuteReader())
                {
                    sdr.Read();
                    if (sdr.HasRows)
                    {
                        MessageBox.Show("Valid User ID");
                        connection.Close();
                        addRecord viewAndEdit = new addRecord(search_id);
                        viewAndEdit.Show();
                        
                    }

                    else
                    {
                        MessageBox.Show("Invalid User ID");

                    }



                }
                connection.Close();
            }
        }
    }
}
