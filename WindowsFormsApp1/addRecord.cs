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
    public partial class addRecord : Form
    {
        int score;
        int average_s;
        int matchh;
        int fifty;
        int hundd;
        int bestballing;
        int bestscoring;
        int mainID;
        int player_id;
        int rid;
        SqlConnection connection = new SqlConnection(@"Data Source = DEPRESSION69\MSSQLSERVER2;Integrated Security = True");

        public addRecord(int current_log)
        {
            player_id = current_log;
            InitializeComponent();
            connection.Open();
            SqlCommand idquery = new SqlCommand("select id from player where player_id=" + current_log, connection);
            mainID = (int)idquery.ExecuteScalar();
            connection.Close();

            updateRecord();
        }

        private void enter_Click(object sender, EventArgs e)
        {
            if(score_texx.Text=="")
            {
                MessageBox.Show("Score can not be empty");
            }
            else if(textBox2.Text=="")
            {
                MessageBox.Show("Overs can not be empty");
            }
            else
            {
                int thisscore=Convert.ToInt32(score_texx.Text);
                int overs= Convert.ToInt32(textBox2.Text);
                matchh++;
                score=score+thisscore;
                average_s = score / matchh;
                if(thisscore>=50)
                {
                    fifty++;
                }
                if (thisscore >= 100)
                {
                    hundd++;
                }
                connection.Open();
                SqlCommand updatePass = new SqlCommand("update playerRecord set score='" + score + "',average='" + average_s + "',fif='"+fifty+ "',hundards='"+hundd+ "',matchs='" +matchh+"' where id="+mainID, connection);
                updatePass.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Data Updated");
                updateRecord();


            }
        }
        void updateRecord()
        {
            connection.Open();

            MessageBox.Show(mainID.ToString());
            SqlCommand idquery2 = new SqlCommand("select * from playerRecord where id=" + mainID, connection);
            idquery2.ExecuteNonQuery();
            using (SqlDataReader sdr = idquery2.ExecuteReader())
            {
                sdr.Read();

                score = Convert.ToInt32(sdr["score"].ToString());
                //score_label.Text = score.ToString();
                average_s = Convert.ToInt32(sdr["average"].ToString());
                averageg.Text = average_s.ToString();

                matchh = Convert.ToInt32(sdr["matchs"].ToString());
                matchg.Text = matchh.ToString();
                fifty = Convert.ToInt32(sdr["fif"].ToString());
                fifty = Convert.ToInt32(sdr["hundards"].ToString());
                fiftyg.Text = fifty.ToString();
                bestballing = Convert.ToInt32(sdr["bestswicket"].ToString());
                bestscoring = Convert.ToInt32(sdr["bestswicket"].ToString());
                
                ballG.Text = sdr["bestswicket"].ToString() + "-" + sdr["bestscore"].ToString();

            }
            connection.Close();

        }
    }
}
