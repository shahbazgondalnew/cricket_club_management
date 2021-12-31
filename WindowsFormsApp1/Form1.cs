using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = DEPRESSION69\MSSQLSERVER2;Integrated Security = True");
        SqlCommand cmd;
        
        SqlDataAdapter adapt;
        int userID = 0;

        public Form1()
        {
            InitializeComponent();
            DisplayData();

        }
        private void DisplayData()
        {
            
           connection.Open();
            DataTable dt = new DataTable();
           
           // adapt.Fill(dt);
           ////
            connection.Close();
        }

        
        
        private void ClearData() {
         
            userNameText.Text = "";
            passtext.Text = "";


        }

private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nametext_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateBut_Click(object sender, EventArgs e)
        {
            ////
            ///
            if (userNameText.Text != "" && passtext.Text != "")
            {


                string usernameVal = userNameText.Text;
                string passwordVal = passtext.Text;

                SqlCommand cmd = new SqlCommand("select * from UserData where username='" + usernameVal + "'and password='" + passwordVal + "'", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                   // if (userlogin > 0)
                    //{//MessageBox.Show("Login sucess Welcome to Homepage");
                        connection.Open();
                        SqlCommand idquery = new SqlCommand("select * from UserData where username='" + usernameVal + "'and password='" + passwordVal + "'", connection);
                        using (SqlDataReader sdr = idquery.ExecuteReader())
                        {
                        sdr.Read();
                        string loginAs = sdr["id"].ToString();
                        int rule = Convert.ToInt32(sdr["rule"].ToString());
                        if(rule==0)
                        {
                            player_page player =new player_page();
                            userID = Convert.ToInt32(loginAs);
                            sdr.Close();
                            player.Show();
                           
                        }
                        else if(rule==1)
                        {
                            userID = Convert.ToInt32(loginAs);
                            MessageBox.Show("Login as " + loginAs + " and UserID =" + userID);
                            sdr.Close();
                            viewYourProfile yourProfile = new viewYourProfile(userID, connection);
                            yourProfile.Show();
                        }
                        else if(rule==2)
                        {
                            userID = Convert.ToInt32(loginAs);
                            coach_profile coachh = new coach_profile(userID);
                           
                            sdr.Close();
                            coachh.Show();
                            
                        }
                        
                        
                    }
                    //}
                    





                }
                else
                {
                    MessageBox.Show("Invalid Login please check username and password");
                }
                connection.Close();

            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void deleteBut_Click(object sender, EventArgs e)
        {
           
           
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            addNewUser addUserScreen = new addNewUser();
            addUserScreen.Show();
        }

        private void passtext_TextChanged(object sender, EventArgs e)
        {
            passtext.UseSystemPasswordChar = true;
        }
    }
}
