using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using MySql.Data.MySqlClient;

namespace send_mail
{
    class Program
    {
        public static string[] DB_load(string txt_date) // struct *형식으로 구조체 리스트가 있으면 그걸로 반환하게 만들자
        {
            string Conn = "Server=airysm.mysql.database.azure.com;Database=db_scheduler;Uid=Airysm@airysm;Pwd=shwon8040!";

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

        public static void send_email(string email_address)
        {
            string detail_all = "";
            string[] detail = DB_load(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));

            if (detail.Length == 0)
                return;

            foreach (string str in detail)
            {
                detail_all += str;
                detail_all += "\n";
            }

            var credentials = new NetworkCredential("shwon123456789@gmail.com", "sh80408040!");
            var mail = new MailMessage()
            {
                From = new MailAddress("shwon123456789@gmail.com"),
                Subject = "내일 일정",
                Body = detail_all
            };

            mail.To.Add(new MailAddress(email_address));

            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials
            };

            client.Send(mail);
        }
        static void Main(string[] args)
        {
            try
            {
                send_email("shwon775@naver.com"); // db에 있는 이메일 주소 불러오기 꼭 수정
                Console.WriteLine("보내기 성공");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
