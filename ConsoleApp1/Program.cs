using System;
using MySql.Data.MySqlClient;
using DB;

namespace DB
{
    public struct schedule
    {
        public string txt_date;
        public string txt_detail;
        public int checklist;
    }

    public class DB_fuction
    {

        private string Conn = "Server=localhost;Database=db_scheduler;Uid=root;Pwd=shwon8040";
        public void DB_save(schedule scd)
        {
            // datetimepicker.Text와 일정 내용 textbox.Text, enum checklist를 넣어주면
            // db에 저장되는 함수
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand sdc = new MySqlCommand("INSERT INTO schedule(date, detail, checklist) values('" + scd.txt_date + "', '" + scd.txt_detail + "', " + scd.checklist + ")", conn);
                sdc.ExecuteNonQuery();
            }
        }

        // 수정, 삭제, 불러오기

        public void DB_load(string txt_date) // struct *형식으로 구조체 리스트가 있으면 그걸로 반환하게 만들자
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

        public void DB_update(schedule scd_update, schedule scd)
        {
            // scd_update에 수정된 스케줄, scd는 수정할 스케줄
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand sdc = new MySqlCommand("UPDATE schedule SET date = '" + scd_update.txt_date + "', detail = '" + scd_update.txt_detail + "', checklist = '"
                    + scd_update.checklist + "' WHERE date = '" + scd.txt_date + "' AND detail = '" + scd.txt_detail + "' AND checklist = " + scd.checklist + "", conn);
                sdc.ExecuteNonQuery();
            }
        }

        public void DB_delete(schedule scd)
        {
            // scd 스케줄이 삭제되는 함수
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand sdc = new MySqlCommand("DELETE FROM schedule WHERE date = '" + scd.txt_date + "' AND detail = '" + scd.txt_detail + "' AND checklist = " + scd.checklist + "", conn);
                sdc.ExecuteNonQuery();
            }
        }
    }
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DB_fuction db = new DB_fuction();
            schedule scd_update;
            schedule scd;

            scd.txt_date = "2022-05-03";
            scd.txt_detail = "얘야 국이 짜다.";
            scd.checklist = 1;

            scd_update.txt_date = "2022-05-03";
            scd_update.txt_detail = "얘야 국이 시원하다.";
            scd_update.checklist = 1;

            db.DB_update(scd_update, scd);
            db.DB_delete(scd_update);
            db.DB_load("2022-05-03");
        }
    }
}
