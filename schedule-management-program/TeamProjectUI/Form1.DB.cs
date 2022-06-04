using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TeamProject
{
    partial class Form1
    {
        public class schedule
        {
            public string txt_date;
            public string txt_detail;
            public int category;

            public schedule(string txt_date, string txt_detail, int category)
            {
                this.txt_date = txt_date;
                this.txt_detail = txt_detail;
                this.category = category;
            }
        }

        public static class DB_fuction
        {
            private static string Conn = "Server=airysm.mysql.database.azure.com;Database=db_scheduler;Uid=Airysm@airysm;Pwd=shwon8040!";

            public static void DB_save(schedule scd)
            {
                // datetimepicker.Text와 일정 내용 textbox.Text, enum checklist를 넣어주면
                // db에 저장되는 함수
                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand sdc = new MySqlCommand("INSERT INTO schedule(date, detail, checklist) values('" + scd.txt_date + "', '" + scd.txt_detail + "', " + scd.category + ")", conn);
                    sdc.ExecuteNonQuery();
                }
            }

            // 수정, 삭제, 불러오기

            public static void DB_load(string txt_date) // struct *형식으로 구조체 리스트가 있으면 그걸로 반환하게 만들자
            {
                // datetimepicker.Text를 넣어주면
                // 해당 날짜에 맞는 일정 list를 return하는 함수

                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand schedule = new MySqlCommand("SELECT date, detail, checklist FROM schedule", conn);
                    MySqlDataReader sdr = schedule.ExecuteReader();

                    while (sdr.Read())
                    {
                        if ((string)sdr[0] == txt_date)
                        {
                            Console.WriteLine(sdr[0] + ": " + sdr[1]);
                        }
                    }
                    sdr.Close();
                }
            }

            public static void DB_update(schedule scd_update, schedule scd)
            {
                // scd_update에 수정된 스케줄, scd는 수정할 스케줄
                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand sdc = new MySqlCommand("UPDATE schedule SET date = '" + scd_update.txt_date + "', detail = '" + scd_update.txt_detail + "', checklist = '"
                        + scd_update.category + "' WHERE date = '" + scd.txt_date + "' AND detail = '" + scd.txt_detail + "' AND checklist = " + scd.category + "", conn);
                    sdc.ExecuteNonQuery();
                }
            }

            public static void DB_delete(schedule scd)
            {
                // scd 스케줄이 삭제되는 함수
                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand sdc = new MySqlCommand("DELETE FROM schedule WHERE date = '" + scd.txt_date + "' AND detail = '" + scd.txt_detail + "' AND checklist = " + scd.category + "", conn);
                    sdc.ExecuteNonQuery();
                }
            }


            public static string[] DB_load2(string txt_date) // struct *형식으로 구조체 리스트가 있으면 그걸로 반환하게 만들자
            {
                // datetimepicker.Text를 넣어주면
                // 해당 날짜에 맞는 일정 list를 return하는 함수

                List<string> tempList = new List<string>();

                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand schedule = new MySqlCommand("SELECT date, detail, checklist FROM schedule", conn);
                    MySqlDataReader sdr = schedule.ExecuteReader();

                    while (sdr.Read())
                    {
                        if ((string)sdr[0] == txt_date)
                        {
                            Console.WriteLine(sdr[0] + ": " + sdr[1]);
                            tempList.Add((string)sdr[1]);
                        }
                    }
                    sdr.Close();
                }

                return tempList.ToArray();
            }

            public static List<schedule> DB_load_All()
            {
                List<schedule> tempList = new List<schedule>();

                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand schedule = new MySqlCommand("SELECT date, detail, checklist FROM schedule", conn);
                    MySqlDataReader sdr = schedule.ExecuteReader();

                    while (sdr.Read())
                    {
                        schedule scd = new schedule(sdr[0].ToString(), sdr[1].ToString(), (int)sdr[2]);
                        tempList.Add(scd);
                    }
                    sdr.Close();
                }

                return tempList;
            }

            public static void DB_save_All(List<schedule> allList)
            {
                List<schedule> tempList = new List<schedule>();
                int flag = -1;

                tempList = DB_load_All();

                for (int i = 0; i < allList.Count; i++)
                {
                    for (int j = 0; j < tempList.Count; j++)
                    {
                        if (tempList[j].txt_date == allList[i].txt_date && tempList[j].txt_detail == allList[i].txt_detail
                            && tempList[j].category == allList[i].category)
                        {
                            flag = i;
                            break;
                        }
                    }
                    if (flag == -1)
                        DB_save(allList[i]);
                    flag = -1;
                }

                for (int i = 0; i < tempList.Count; i++)
                {
                    for (int j = 0; j < allList.Count; j++)
                    {
                        if (tempList[i].txt_date == allList[j].txt_date && tempList[i].txt_detail == allList[j].txt_detail
                            && tempList[i].category == allList[j].category)
                        {
                            flag = i;
                            break;
                        }
                    }
                    if (flag == -1)
                        DB_delete(tempList[i]);
                    flag = -1;
                }
            }
        }
    }
}
