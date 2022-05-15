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
            일정Group group = new 일정Group();
            GroupBox groupBox = new GroupBox();
            TextBox textBox = new TextBox();
            MetroButton editBtn = new MetroButton();
            MetroButton deleteBtn = new MetroButton();

            group.GroupBox_일정 = groupBox;
            group.TextBox_일정 = textBox;
            group.EditBtn_일정 = editBtn;
            group.DeleteBtn_일정 = deleteBtn;

            groupBox.Controls.Add(textBox);
            groupBox.Controls.Add(editBtn);
            groupBox.Controls.Add(deleteBtn);

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

            // textBox 속성 설정
            textBox.ReadOnly = true;
            textBox.Multiline = true;
            textBox.Size = new Size(328, 47);
            textBox.Location = new Point(6, 20);

            textBox.Text = groupList.Count.ToString(); //*

            textBoxAlignment();
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

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            MetroButton btn = sender as MetroButton;
            int deleteIndex = -1;
            for (int i = 0; i < groupList.Count; i++)
            {
                if(groupList[i].DeleteBtn_일정.Name == btn.Name)
                {
                    deleteIndex = i;
                    break;
                }
            }

            groupList.RemoveAt(deleteIndex);

            textBoxAlignment();
        }
    }

    public class 일정Group // 버튼을 누르면 생성되는 Control들 모음
    {
        private GroupBox groupBox_일정;
        private TextBox textBox_일정;
        private MetroButton editBtn_일정;
        private MetroButton deleteBtn_일정;


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
    }
}
