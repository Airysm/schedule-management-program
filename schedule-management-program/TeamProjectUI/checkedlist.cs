using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TeamProjectUI
{
    public class checkedlist
    {
        public string txt_detail;
        public bool check;

        public checkedlist(string txt_detail, bool check)
        {
            this.txt_detail = txt_detail;
            this.check = check;
        }
    }
    public static class DB_fuction_checked
    {
        private static string Conn = "Server=airysm.mysql.database.azure.com;Database=db_scheduler;Uid=Airysm@airysm;Pwd=shwon8040!";

        public static List<checkedlist> DB_load_All_checked()
        {
            List<checkedlist> tempList = new List<checkedlist>();

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand schedule = new MySqlCommand("SELECT detail, checked FROM checkedlist", conn);
                MySqlDataReader sdr = schedule.ExecuteReader();

                while (sdr.Read())
                {
                    bool temp;
                    if ((int)sdr[1] == 0)
                    {
                        temp = false;
                    }
                    else
                    {
                        temp = true;
                    }
                    checkedlist chklist = new checkedlist(sdr[0].ToString(), temp);
                    tempList.Add(chklist);
                }
                sdr.Close();
            }

            return tempList;
        }

        public static void DB_save_All_checked(List<checkedlist> allList)
        {
            List<checkedlist> tempList = new List<checkedlist>();
            int flag = -1;

            tempList = DB_load_All_checked();

            for (int i = 0; i < allList.Count; i++)
            {
                for (int j = 0; j < tempList.Count; j++)
                {
                    if (tempList[j].txt_detail == allList[i].txt_detail && tempList[j].check == allList[i].check)
                    {
                        flag = i;
                        break;
                    }
                }
                if (flag == -1)
                    DB_save_checked(allList[i]);
                flag = -1;
            }

            for (int i = 0; i < tempList.Count; i++)
            {
                for (int j = 0; j < allList.Count; j++)
                {
                    if (tempList[i].txt_detail == allList[j].txt_detail && tempList[i].check == allList[j].check)
                    {
                        flag = i;
                        break;
                    }
                }
                if (flag == -1)
                    DB_delete_checked(tempList[i]);
                flag = -1;
            }
        }

        public static void DB_save_checked(checkedlist chklist)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand sdc = new MySqlCommand("INSERT INTO checkedlist(detail, checked) values('" + chklist.txt_detail + "', " + chklist.check + ")", conn);
                sdc.ExecuteNonQuery();
            }
        }

        public static void DB_delete_checked(checkedlist chklist)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand sdc = new MySqlCommand("DELETE FROM checkedlist WHERE detail = '" + chklist.txt_detail + "' AND checked = " + chklist.check + "", conn);
                sdc.ExecuteNonQuery();
            }
        }

        public static bool DB_checked_date() // true이면 오늘 날짜 false이면 날짜를 update
        {
            string db_date = "";

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand schedule = new MySqlCommand("SELECT date FROM date", conn);
                MySqlDataReader sdr = schedule.ExecuteReader();

                while (sdr.Read())
                {
                    db_date = (string)sdr[0];
                    if (db_date == DateTime.Now.ToString("yyyy-MM-dd"))
                        return true;
                }
                sdr.Close();

                if (db_date != "")
                {
                    MySqlCommand sdc1 = new MySqlCommand("DELETE FROM date WHERE date = '" + db_date + "");
                    sdc1.ExecuteNonQuery();
                }
                MySqlCommand sdc2 = new MySqlCommand("INSERT INTO date(date) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "')", conn);
                sdc2.ExecuteNonQuery();
            }
            return false;
        }
    }
}
