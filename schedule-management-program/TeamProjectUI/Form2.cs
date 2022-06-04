using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TeamProjectUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private static string Conn = "Server=airysm.mysql.database.azure.com;Database=db_scheduler;Uid=Airysm@Airysm;Pwd=shwon8040!";
        private void btn_mail_Click(object sender, EventArgs e)
        {
            string s = txt_Mail1.Text + "@" + txt_Mail2.Text; // 삽입할 이메일주소
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand sdc1 = new MySqlCommand("UPDATE email SET email.idemail = '" + s + "'", conn);
                sdc1.ExecuteNonQuery();
            }
        }
    }
}
