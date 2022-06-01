using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MetroFramework.Controls;

namespace TeamProject
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public List<일정Group> groupList = new List<일정Group>();
        public Form1()
        {
            InitializeComponent();
        }

        private void metroButton_Add_Click(object sender, EventArgs e) // 일정 추가 add 버튼 클릭
        {
            if (!String.IsNullOrWhiteSpace(metroTextBox1.Text)) //tasks 간단하게 유지하기 위해 빈 작업을 수락하지 않음
            {

                일정Group group = new 일정Group();
                GroupBox groupBox = new GroupBox();
                TextBox textBox = new TextBox();
                MetroButton editBtn = new MetroButton();
                MetroButton deleteBtn = new MetroButton();
                MetroLabel numLbl = new MetroLabel();

                group.GroupBox_일정 = groupBox;
                group.TextBox_일정 = textBox;
                group.EditBtn_일정 = editBtn;
                group.DeleteBtn_일정 = deleteBtn;
                group.NumLbl_일정 = numLbl;

                groupBox.Controls.Add(textBox);
                groupBox.Controls.Add(editBtn);
                groupBox.Controls.Add(deleteBtn);
                groupBox.Controls.Add(numLbl);

                groupList.Add(group);


                // groupBox 속성 설정
                groupBox.Size = new Size(340, 100);

                // button 속성 설정
                editBtn.Size = new Size(75, 23);
                editBtn.Location = new Point(179, 71);
                editBtn.Text = "Edit";
                editBtn.Click += editBtn_Click;

                deleteBtn.Size = new Size(75, 23);
                deleteBtn.Location = new Point(259, 71);
                deleteBtn.Text = "Delete";
                deleteBtn.Click += deleteBtn_Click;

                //label
                numLbl.Size = new Size(15,15);
                numLbl.Anchor=AnchorStyles.Left;
                numLbl.Text = groupList.Count.ToString();
                numLbl.Enabled = true;


                // textBox 속성 설정
                textBox.ReadOnly = true;
                textBox.Multiline = true;
                textBox.Size = new Size(328, 47);               
                textBox.Location = new Point(6, 20);
                textBox.Text = metroTextBox1.Text;       

                metroTextBox1.Text = ""; //사용자의 편의를 위해 텍스트를 빈 문자열로 설정
                textBoxAlignment();

                // DB에 저장
                string strDate = monthCalendar1.SelectionStart.Year.ToString() + "-" + monthCalendar1.SelectionStart.Month.ToString() + "-" + monthCalendar1.SelectionStart.Day.ToString();
                schedule scd = new schedule(strDate, textBox.Text,-1);

                DB_fuction.DB_save(scd);
            }
        }

        private void textBoxAlignment() // 텍스트 박스 정렬
        {
            while(flowLayoutPanel_일정.Controls.Count > 1) // 기존의 텍스트 박스를 전부 지움
            {
                flowLayoutPanel_일정.Controls.RemoveAt(1);
            }

            for (int i = groupList.Count - 1; i >= 0; i--) // textBoxList의 textBox들을 다시 전부 넣어줌
            {
                flowLayoutPanel_일정.Controls.Add(groupList[i].GroupBox_일정);
                groupList[i].GroupBox_일정.Name = "group" + i.ToString();
                groupList[i].DeleteBtn_일정.Name = "btn" + i.ToString();
            }

            for (int i = 0; i < flowLayoutPanel_일정.Controls.Count; i++)
            {
                Console.WriteLine(flowLayoutPanel_일정.Controls[i].Name);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            //MetroButton btn = sender as MetroButton;
           
            //for (int i = 0; i < groupList.Count; i++)
            //{
            //    if (groupList[i].EditBtn_일정.Name == btn.Name && !metroTextBox1.Text.Equals(""))
            //    {
            //        groupList[i].TextBox_일정.Text = metroTextBox1.Text;
            //        break;
            //    }
            //    else return;
            //}
           
            
            //click edit - permissions are changed
            //user makes edits
            //message box "save" "cancel"
            //saves or cancels and changes perms to readonly again
                    /*messageBox*/

                    /* string message = "Do you want to save the changes?";
                     string title = "Save Edits";
                     MessageBoxButtons buttons = MessageBoxButtons.OKCancel;

                     for (int i = 0; i < groupList.Count; i++)
                     {
                         if (groupList[i].GroupBox_일정.Focus())
                         { 
                             string tempStr = groupList[i].TextBox_일정.Text;
                             groupList[i].TextBox_일정.ReadOnly = false;

                             if (!groupList[i].GroupBox_일정.Focus())//add enter key event
                             {
                                 DialogResult result = MessageBox.Show(message, title, buttons);
                                 if (result == DialogResult.OK)
                                 {
                                     this.Close();
                                 }
                                 else
                                 {
                                     groupList[i].TextBox_일정.Text = tempStr;
                                     this.Close();
                                 }
                             }

                             groupList[i].TextBox_일정.ReadOnly = true;
                             break;
                         }
                     }*/


        }

        private void deleteBtn_Click(object sender, EventArgs e) 
        {
            MetroButton btn = sender as MetroButton;
            int deleteIndex = -1;
            for (int i = 0; i < groupList.Count; i++)
            {
                if (groupList[i].DeleteBtn_일정.Name == btn.Name)
                {
                    deleteIndex = i;
                    break;
                }
            }

            string strDate = monthCalendar1.SelectionStart.Year.ToString() + "-" + monthCalendar1.SelectionStart.Month.ToString() + "-" + monthCalendar1.SelectionStart.Day.ToString();
            schedule scd = new schedule(strDate, groupList[deleteIndex].TextBox_일정.Text, -1);

            groupList.RemoveAt(deleteIndex);
            textBoxAlignment();

            //update the number of the task
            for (int i = 0; i < groupList.Count; i++)
            {
                groupList[i].NumLbl_일정.Text = (i+1).ToString();
            }


            DB_fuction.DB_delete(scd);
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e) // 달력 날짜 선택
        {
            string strDate = monthCalendar1.SelectionStart.Year.ToString() + "-" + monthCalendar1.SelectionStart.Month.ToString() + "-" + monthCalendar1.SelectionStart.Day.ToString();

            string[] strArray = DB_fuction.DB_load2(strDate);

            // 그룹박스들 지우기
            for (int i = 0; i < groupList.Count; i++)
            {
                groupList.RemoveAt(0);
            }

            textBoxAlignment();

            // 해당 날짜의 그룹 박스 추가
            for(int i = 0; i < strArray.Length; i++)
            {
                createGroupBox(strDate, strArray[i],  -1); // Category 제작시 수정 필요
            }
        }

        private void createGroupBox(string date, string detail, int category) // 그룹박스 생성 함수 재사용
        {
            일정Group group = new 일정Group();
            GroupBox groupBox = new GroupBox();
            TextBox textBox = new TextBox();
            MetroButton editBtn = new MetroButton();
            MetroButton deleteBtn = new MetroButton();
            MetroLabel numLbl = new MetroLabel();

            group.GroupBox_일정 = groupBox;
            group.TextBox_일정 = textBox;
            group.EditBtn_일정 = editBtn;
            group.DeleteBtn_일정 = deleteBtn;
            group.NumLbl_일정 = numLbl;

            groupBox.Controls.Add(textBox);
            groupBox.Controls.Add(editBtn);
            groupBox.Controls.Add(deleteBtn);
            groupBox.Controls.Add(numLbl);

            groupList.Add(group);


            // groupBox 속성 설정
            groupBox.Size = new Size(340, 100);

            // button 속성 설정
            editBtn.Size = new Size(75, 23);
            editBtn.Location = new Point(179, 71);
            editBtn.Text = "Edit";
            editBtn.Click += editBtn_Click;

            deleteBtn.Size = new Size(75, 23);
            deleteBtn.Location = new Point(259, 71);
            deleteBtn.Text = "Delete";
            deleteBtn.Click += deleteBtn_Click;

            //label
            numLbl.Size = new Size(15, 15);
            numLbl.Anchor = AnchorStyles.Left;
            numLbl.Text = groupList.Count.ToString();
            numLbl.Enabled = true;


            // textBox 속성 설정
            textBox.ReadOnly = true;
            textBox.Multiline = true;
            textBox.Size = new Size(328, 47);
            textBox.Location = new Point(6, 20);
            textBox.Text = detail;

            metroTextBox1.Text = ""; //사용자의 편의를 위해 텍스트를 빈 문자열로 설정
            textBoxAlignment();
        }
    }

    public class 일정Group // 버튼을 누르면 생성되는 Control들 모음
    {
        private GroupBox groupBox_일정;
        private TextBox textBox_일정;
        private MetroButton editBtn_일정;
        private MetroButton deleteBtn_일정;
        private MetroButton saveBtn_일정;
        private MetroLabel numLbl_일정;

        // properties
        public GroupBox GroupBox_일정
        {
            get;
            set;
        }

        public TextBox TextBox_일정
        {
            get;
            set;
        }

       
        public MetroButton EditBtn_일정
        {
            get;
            set;
        }

        public MetroButton DeleteBtn_일정
        {
            get;
            set;
        }

        public MetroLabel NumLbl_일정
        {
            get;
            set;
        }
    }
}
