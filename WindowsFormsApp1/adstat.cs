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
    public partial class adstat : Form
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
        public adstat(int current_log)
        {
            player_id=current_log;
            InitializeComponent();
            connection.Open();
            SqlCommand idquery = new SqlCommand("select id from player where player_id=" + current_log, connection);
            mainID= (int)idquery.ExecuteScalar();
            connection.Close();
            
            updateRecord();
        }

        private void adstat_Load(object sender, EventArgs e)
        {

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
                average.Text = average_s.ToString();
                
                matchh= Convert.ToInt32(sdr["matchs"].ToString());
                match.Text = matchh.ToString();
                fifty = Convert.ToInt32(sdr["fif"].ToString());
                fifty = Convert.ToInt32(sdr["hundards"].ToString());
                fif.Text = fifty.ToString();
                bestballing=Convert.ToInt32(sdr["bestswicket"].ToString());
                bestscoring = Convert.ToInt32(sdr["bestswicket"].ToString());

                bestball.Text = sdr["bestswicket"].ToString() + "-" + sdr["bestscore"].ToString();
                
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (over.Text == "")
            {
                MessageBox.Show("Over can not be empty");
            }
            else if (score_make.Text == "")
            {
                MessageBox.Show("Over can not be empty");
            }
        }

        

        private void score_Click(object sender, EventArgs e)
        {
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // adstat
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "adstat";
            this.Load += new System.EventHandler(this.adstat_Load_1);
            this.ResumeLayout(false);

        }

        private void adstat_Load_1(object sender, EventArgs e)
        {

        }
    }
}
