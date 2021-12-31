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
    public partial class viewYourProfile : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = DEPRESSION69\MSSQLSERVER2;Integrated Security = True");
        int loginAs_id;
        int useridOfCoach = -1;
        int gender_int = 0;
        public viewYourProfile(int login_id, SqlConnection connection)
        {
            //}
            loginAs_id = login_id;
            string fName = "";
            string sName = "";
            InitializeComponent();
            SqlConnection connection1 = connection;
           // connection.Open();
            SqlCommand idquery = new SqlCommand("select * from UserData where id=" +login_id  , connection);
            using (SqlDataReader sdr = idquery.ExecuteReader())
            {
                sdr.Read();
                fName = sdr["firstName"].ToString();
                sName = sdr["secName"].ToString();




            }
            welcome_label.Text = "Welcome! " +fName+" "+sName ;
            connection.Close();
            connection.Open();
            SqlCommand coachQ = new SqlCommand("select coach.id,username,firstName,secName from UserData inner join coach on coach.id=UserData.id", connection);
            
            using (SqlDataReader coachRead = coachQ.ExecuteReader())
            {
                while (coachRead.Read())
                {
                    string tempVal = coachRead["username"].ToString() ;
                    coach.Items.Add(tempVal);
                    
                }
                
                 




            }
            connection.Close();
            
        }

        

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void viewYourProfile_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source = DEPRESSION69\MSSQLSERVER2;Integrated Security = True");
            connection.Open();
            string fname = fname_p.Text;
            string sname = sname_p.Text;
            string user = user_p.Text;
            string pass = pass_p.Text;
            int mainID=0;
            if (useridOfCoach==-1)
            {
                MessageBox.Show("Please select Coach");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into UserData (firstName,secName,username,password) values ('" + fname + "','" + sname + "','" + user + "','" + pass + "')", connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(SqlException)
                {
                    MessageBox.Show("Username must be uniqui");
                }
                connection.Close();
                connection.Open();
                //
                MessageBox.Show(user_p.Text);
                SqlCommand findMain = new SqlCommand("select Id from UserData where username='"+user+"'", connection);


                mainID = (int)findMain.ExecuteScalar();
                    
                
                    //
                    connection.Close();
                connection.Open();
                
                cmd.CommandText = "INSERT INTO player(id,coach_id,team_id,p_gender,p_cnic,contact,p_address,p_age) VALUES(@param1,@param2,@teammm,@param3,@param4,@param5,@param6,@param7)";

                cmd.Parameters.AddWithValue("@param1", mainID);
                cmd.Parameters.AddWithValue("@param2", useridOfCoach);
                cmd.Parameters.AddWithValue("@teammm", 1);
                cmd.Parameters.AddWithValue("@param3", gender_int);
                cmd.Parameters.AddWithValue("@param4", Convert.ToInt32(cnic_new.Text));
                cmd.Parameters.AddWithValue("@param5", Convert.ToInt32(contact_text.Text));
                cmd.Parameters.AddWithValue("@param6", address_te.Text);
                cmd.Parameters.AddWithValue("@param7", Convert.ToInt32(age_te.Text));



                    cmd.ExecuteNonQuery();
                
                
                connection.Close();
                connection.Open();
                cmd.CommandText = "INSERT INTO playerRecord(id) VALUES(@parammm1)";
                cmd.Parameters.AddWithValue("@parammm1", mainID);
                cmd.ExecuteNonQuery();
                connection.Close();


            }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id_enter.Text == "")
            {
                MessageBox.Show("Please Enter Some ID");
            }
            else
            {
                int search_id;
                search_id= Convert.ToInt32(id_enter.Text);
                connection.Open();
                SqlCommand idquery = new SqlCommand("SELECT * from UserData where id=" + search_id, connection);
                using (SqlDataReader sdr = idquery.ExecuteReader())
                {
                    sdr.Read();
                    if (sdr.HasRows)
                    {
                        MessageBox.Show("Valid User ID");
                        editPage viewAndEdit = new editPage(search_id);
                        viewAndEdit.Show();
                        //this.Close();
                        ////
                    }
                    
                    else
                    {
                        MessageBox.Show("Invalid User ID");

                    }



                }
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (current_p.Text == "")
            {
                MessageBox.Show("Current Password can not be Empty");
            }
            else if (new_one.Text=="")
            {
                MessageBox.Show("New Password can not be Empty");
            }
            else if (new_two.Text == "")
            {
                MessageBox.Show("New Password can not be Empty");
            }
            else if (new_one.Text!=new_two.Text)
            {
                MessageBox.Show("New Password must be Same");
            }
            else
            {
                string currentPassword;
                connection.Open();
                SqlCommand idquery = new SqlCommand("select * from UserData where id=" + loginAs_id, connection);
                using (SqlDataReader sdr = idquery.ExecuteReader())
                {
                    sdr.Read();
                    currentPassword = sdr["password"].ToString();

                }
                if (currentPassword != current_p.Text)
                {
                    MessageBox.Show("Incorrect Current Password");
                }
                else if (current_p.Text==new_one.Text)
                {
                    MessageBox.Show("New Password can not same as Current Password");
                }
                else
                {
                    SqlCommand updatePass= new SqlCommand("update UserData set password='"+new_one.Text+"' where id=" + loginAs_id, connection);
                    updatePass.ExecuteNonQuery();

                    MessageBox.Show("Password Updated");

                }
                connection.Close();
            }
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(Id_remove.Text=="")
            {
                MessageBox.Show("ID can not be empty");

            }
            else
            {

                connection.Open();
                int removee_id = Convert.ToInt32(Id_remove.Text);
                SqlCommand idquery = new SqlCommand("SELECT * from UserData where id=" + removee_id, connection);
                using (SqlDataReader sdr = idquery.ExecuteReader())
                {
                    sdr.Read();
                    if (sdr.HasRows)
                    {
                        MessageBox.Show("Valid User ID");
                        connection.Close();
                        connection.Open();
                        SqlCommand deleteProfile = new SqlCommand("delete from UserData where id=" + removee_id, connection);
                        deleteProfile.ExecuteNonQuery();

                    }

                    else
                    {
                        MessageBox.Show("Invalid User ID");

                    }



                }
                connection.Close();


            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void coach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = coach.SelectedItem.ToString();
            connection.Open();
            SqlCommand coachQ = new SqlCommand("select * from UserData where username='"+selected+"'", connection);
            coachQ.ExecuteNonQuery();
            using (SqlDataReader sdr = coachQ.ExecuteReader())
            {
                sdr.Read();
                 useridOfCoach = Convert.ToInt32(sdr["id"].ToString());

            }

        }

        private void gender_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gender_selection = gender_combo.SelectedIndex.ToString();
            if(gender_selection=="male")
            {
                gender_int = 1;
            }
            else if (gender_selection=="female")
            {
                gender_int = 2;
            }
            
        }

        private void Add_c_Click(object sender, EventArgs e)
        {
            if(name_c.Text=="")
            {
                MessageBox.Show("First name can not be empty");
            }
            else if (sname_c.Text == "")
            {
                MessageBox.Show("second name can not be empty");
            }
            else if (user_c.Text == "")
            {
                MessageBox.Show("username can not be empty");
            }
            else if (pass_C.Text == "")
            {
                MessageBox.Show("password can not be empty");
            }
            else if (address_c.Text == "")
            {
                MessageBox.Show("Address can no be empty");
            }
            else
            {
                connection.Open();
                SqlCommand insertuserC = new SqlCommand("insert into UserData (firstName,secName,username,password) values ('" + name_c.Text + "','" + sname_c.Text + "','" + user_c.Text + "','" + pass_C.Text + "')", connection);

                try
                {

                    insertuserC.ExecuteNonQuery();
                    MessageBox.Show("User Data Updated");


                }
                catch(SqlException)
                {
                    MessageBox.Show("Use Unique Username");
                }
                connection.Close();
                connection.Open();
                SqlCommand findUser = new SqlCommand("select * from UserData where username='"+user_c.Text+"'", connection);
                try
                {

                    findUser.ExecuteNonQuery();
                    using (SqlDataReader sdr = findUser.ExecuteReader())
                    {
                        sdr.Read();
                        int idd = Convert.ToInt32(sdr["id"].ToString());
                        connection.Close();
                        connection.Open();

                        SqlCommand inserIntoCoach = new SqlCommand("insert into coach (Id,address) values (" + idd + ",'" + address_c.Text + "')", connection);
                        try
                        {
                            inserIntoCoach.ExecuteNonQuery();
                        }
                        catch(SqlException)
                        {

                            MessageBox.Show("Something Went Wrong in inserting coach");

                        }
                        connection.Close();
                    }

                }
                catch (SqlException)
                {
                    MessageBox.Show("Something Went Wrong");
                    connection.Close();
                }
                

            }

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
