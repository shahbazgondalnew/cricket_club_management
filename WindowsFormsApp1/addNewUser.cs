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
    public partial class addNewUser : Form
    {
        public addNewUser()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source = DEPRESSION69\MSSQLSERVER2;Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void register_button_Click(object sender, EventArgs e)
        {
            if ((userText.Text == "") || (fnameText.Text == "") || (userText.Text == "") || (passText.Text == ""))
            {
                MessageBox.Show("Field can not be Empty");
            }
            else
            {

                connection.Open();
                
                string fnameval= fnameText.Text;
                string snameval = snameText.Text;
                string userval= userText.Text;
                string passval= passText.Text;
                string queryToInsert = "insert into UserData (firstName,secName,username,password) values ('" + fnameval + "','" + snameval + "','" + userval + "','" + passval + "');";
                SqlCommand cmd = new SqlCommand("insert into UserData (firstName,secName,username,password) values ('" + fnameval + "','" + snameval + "','" + userval + "','" + passval + "');", connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("insert into UserData (firstName,secName,username,password) values (" + fnameval + "," + snameval + "," + userval + "," + passval + ");");
                
            }
        }
    }
}
