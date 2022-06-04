using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TeamProjectUI
{
    public class category
    {
        public int id;
        public string name;

        public category(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }

    public static class DB_fuction_category
    {
        private static string Conn = "Server=airysm.mysql.database.azure.com;Database=db_scheduler;Uid=Airysm@airysm;Pwd=shwon8040!";

        public static List<category> DB_load_All_cat()
        {
            List<category> tempList = new List<category>();

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand schedule = new MySqlCommand("SELECT id, name FROM category", conn);
                MySqlDataReader sdr = schedule.ExecuteReader();

                while (sdr.Read())
                {
                    category cat = new category((int)sdr[0], sdr[1].ToString());
                    tempList.Add(cat);
                }
                sdr.Close();
            }

            return tempList;
        }

        public static void DB_save_All_cat(List<category> allList)
        {
            List<category> tempList = new List<category>();
            int flag = -1;

            tempList = DB_load_All_cat();

            for (int i = 0; i < allList.Count; i++)
            {
                for (int j = 0; j < tempList.Count; j++)
                {
                    if (tempList[j].id == allList[i].id && tempList[j].name == allList[i].name)
                    {
                        flag = i;
                        break;
                    }
                }
                if (flag == -1)
                    DB_save_cat(allList[i]);
                flag = -1;
            }

            for (int i = 0; i < tempList.Count; i++)
            {
                for (int j = 0; j < allList.Count; j++)
                {
                    if (tempList[i].id == allList[j].id && tempList[i].name == allList[j].name)
                    {
                        flag = i;
                        break;
                    }
                }
                if (flag == -1)
                    DB_delete_cat(tempList[i]);
                flag = -1;
            }
        }

        public static void DB_save_cat(category cat)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand sdc = new MySqlCommand("INSERT INTO category(id, name) values(" + cat.id + ", '" + cat.name + "')", conn);
                sdc.ExecuteNonQuery();
            }
        }
        public static void DB_delete_cat(category cat)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand sdc = new MySqlCommand("DELETE FROM category WHERE id = " + cat.id + " AND name = '" + cat.name + "'", conn);
                sdc.ExecuteNonQuery();
            }
        }
    }
}