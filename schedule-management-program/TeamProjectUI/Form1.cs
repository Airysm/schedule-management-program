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
using TeamProjectUI;
using MySql.Data.MySqlClient;

namespace TeamProject
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public List<일정Group> groupList;
        public List<schedule> scdList;
        List<category> listCategory;
        int max;
        Form2 Child = new Form2();
        public Form1()
        {
            InitializeComponent();

            try
            {
                groupList = new List<일정Group>();
                scdList = new List<schedule>();
                listCategory = new List<category>();

                scdList = DB_fuction.DB_load_All();
                initCheckedlistBox();
                initCheckedlistBox2();
                initComboBox();
                selectDateStart();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }        
        }

        private List<schedule> FindScd(string date, int[] category)
        {
            List<schedule> scdtempList = new List<schedule>();
            if (category.Length == 0)
            {

            }
            else
            {
                for(int i = 0; i < category.Length; i++)
                {
                    List<schedule> tempList = scdList.FindAll(x => x.txt_date == date && x.category == category[i]);
                    for(int k = 0; k < tempList.Count; k++)
                    {
                        scdtempList.Add(tempList[k]);
                    }
                }
            }

            return scdtempList;
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
                ComboBox comboBox = new ComboBox();

                group.GroupBox_일정 = groupBox;
                group.TextBox_일정 = textBox;
                group.EditBtn_일정 = editBtn;
                group.DeleteBtn_일정 = deleteBtn;
                group.NumLbl_일정 = numLbl;
                group.Combo_일정 = comboBox;

                groupBox.Controls.Add(textBox);
                groupBox.Controls.Add(editBtn);
                groupBox.Controls.Add(deleteBtn);
                groupBox.Controls.Add(numLbl);
                groupBox.Controls.Add(comboBox);

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

                // comboBox 속성 설정
                comboBox.Size = new Size(75, 23);
                comboBox.Location = new Point(99, 71);
                comboBox.Text = "목록";
                for(int i = 0; i < listCategory.Count; i++)
                {
                    comboBox.Items.Add(listCategory[i].name);
                }

                metroTextBox1.Text = ""; //사용자의 편의를 위해 텍스트를 빈 문자열로 설정
                textBoxAlignment();

                // 카테고리 찾기
                category cat;
                try
                {
                    cat = listCategory.Find(x => x.name == comboBox_Category.SelectedItem.ToString());
                }
                catch(Exception e2)
                {
                    cat = listCategory[0];
                }
                

                // DB에 저장
                DateTime date = monthCalendar1.SelectionStart;
                string strDate = date.ToString("yyyy-MM-dd");
                schedule scd = new schedule(strDate, textBox.Text,cat.id);

                scdList.Add(scd);
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
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "")
                return;


            int n = -1;
            MetroButton edtBtn = sender as MetroButton;

            for (int i = 0; i < groupList.Count; i++)
            {
                if (groupList[i].EditBtn_일정.Name == edtBtn.Name)
                {
                    //groupList.ElementAt<일정Group>(i).TextBox_일정.Text = metroTextBox1.Text;
                    n = i;
                    break;
                }
            }

            if(n == -1)
            {
                return;
            }
            else
            {
                string tempStr = groupList.ElementAt<일정Group>(n).Combo_일정.Text;
                category tempCat = listCategory.Find(x => x.name == tempStr);
                int idx = scdList.FindIndex(x => x.txt_detail == groupList.ElementAt<일정Group>(n).TextBox_일정.Text && x.category == tempCat.id);

                category tempCat2 = listCategory.Find(x => x.name == comboBox_Category.SelectedItem.ToString());
                scdList[idx].category = tempCat2.id;
                scdList[idx].txt_detail = metroTextBox1.Text;
            }

            selectDateStart();

            metroTextBox1.Text = "";
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

            DateTime date = monthCalendar1.SelectionStart;
            string strDate = date.ToString("yyyy-MM-dd");
            schedule scd = new schedule(strDate, groupList[deleteIndex].TextBox_일정.Text, -1);

            groupList.RemoveAt(deleteIndex);
            textBoxAlignment();

            //update the number of the task
            for (int i = 0; i < groupList.Count; i++)
            {
                groupList[i].NumLbl_일정.Text = (i+1).ToString();
            }

            scdList.Remove(scdList.Find(x => x.txt_detail == scd.txt_detail && x.txt_date == scd.txt_date));          
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e) // 달력 날짜 선택
        {
            DateTime date = monthCalendar1.SelectionStart;
            string strDate = date.ToString("yyyy-MM-dd");

            List<schedule> findList = new List<schedule>();
            findList = scdList.FindAll(x => x.txt_date == strDate);


            
            schedule[] strArray = findList.ToArray();


            // 그룹박스들 지우기
            groupList.Clear();


            // 해당 날짜의 그룹 박스 추가
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] != null)
                {
                    category temp1 = listCategory.Find(x => x.id == strArray[i].category);
                    if (temp1 != null)
                    {
                        for (int j = 0; j < checkedListBox1.CheckedIndices.Count; j++)
                        {
                            int n = checkedListBox1.CheckedIndices[j];
                            if (checkedListBox1.Items[n].ToString() == temp1.name)
                            {
                                createGroupBox(strDate, strArray[i].txt_detail, strArray[i].category);
                            }
                        }
                    }
                }
            }
                // Category 제작시 수정 필요

                textBoxAlignment();
        }

        private void selectDateStart()
        {
            DateTime date = monthCalendar1.SelectionStart;
            string strDate = date.ToString("yyyy-MM-dd");

            List<schedule> findList = new List<schedule>();
            findList = scdList.FindAll(x => x.txt_date == strDate);


            
            schedule[] strArray = findList.ToArray();


            // 그룹박스들 지우기
            groupList.Clear();


            // 해당 날짜의 그룹 박스 추가
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] != null)
                {
                    category temp1 = listCategory.Find(x => x.id == strArray[i].category);
                    if (temp1 != null)
                    {
                        for (int j = 0; j < checkedListBox1.CheckedIndices.Count; j++)
                        {
                            int n = checkedListBox1.CheckedIndices[j];
                            if (checkedListBox1.Items[n].ToString() == temp1.name)
                            {
                                createGroupBox(strDate, strArray[i].txt_detail, strArray[i].category);
                            }
                        }
                    }                         
                }
                // Category 제작시 수정 필요
            }

            textBoxAlignment();
        }

        private void createGroupBox(string date, string detail, int category) // 그룹박스 생성 함수 재사용
        {
            일정Group group = new 일정Group();
            GroupBox groupBox = new GroupBox();
            TextBox textBox = new TextBox();
            MetroButton editBtn = new MetroButton();
            MetroButton deleteBtn = new MetroButton();
            MetroLabel numLbl = new MetroLabel();
            ComboBox comboBox = new ComboBox();

            group.GroupBox_일정 = groupBox;
            group.TextBox_일정 = textBox;
            group.EditBtn_일정 = editBtn;
            group.DeleteBtn_일정 = deleteBtn;
            group.NumLbl_일정 = numLbl;
            group.Combo_일정 = comboBox;

            groupBox.Controls.Add(textBox);
            groupBox.Controls.Add(editBtn);
            groupBox.Controls.Add(deleteBtn);
            groupBox.Controls.Add(numLbl);
            groupBox.Controls.Add(comboBox);

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

            // comboBox 속성 설정
            comboBox.Size = new Size(75, 23);
            comboBox.Location = new Point(99, 71);
            comboBox.Text = "목록";
            for (int i = 0; i < listCategory.Count; i++)
            {
                comboBox.Items.Add(listCategory[i].name);
            }

            try
            {
                category cat = listCategory.Find(x => x.id == category);
                if(cat == null)
                {
                    return;
                }
                else
                {
                    comboBox.SelectedItem = cat.name;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
            

            metroTextBox1.Text = ""; //사용자의 편의를 위해 텍스트를 빈 문자열로 설정
            textBoxAlignment();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB_fuction.DB_save_All(scdList);

            List<checkedlist> list = new List<checkedlist>();
            for(int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedlist chk = new checkedlist(checkedListBox2.Items[i].ToString(), checkedListBox2.GetItemChecked(i));

                list.Add(chk);
            }
            DB_fuction_checked.DB_save_All_checked(list);

            DB_fuction_category.DB_save_All_cat(listCategory);
        }

        private void btn_addChecklist_Click(object sender, EventArgs e)
        {
            string[] str = new string[checkedListBox2.Items.Count];

            for(int i = 0; i < str.Length; i++)
            {
                str[i] = checkedListBox2.Items[i].ToString();
            }

            Form_ChecklistAdd form = new Form_ChecklistAdd(str);

            form.ChildFormEvent += EventMethod;

            form.ShowDialog();
        }
        public void EventMethod(string[] str)
        {
            checkedListBox2.Items.Clear();
            for(int i = 0; i < str.Length; i++)
            {
                checkedListBox2.Items.Add(str[i]);
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            int maxTemp = max;
            for(int i = 0; i < listCategory.Count; i++)
            {
                Console.WriteLine("max:"+max);

                if (listCategory[i].id >= maxTemp)
                {
                    maxTemp = listCategory[i].id + 1;
                    Console.WriteLine(maxTemp);
                }
            }

            category cat = new category(maxTemp, newCtgrTxtBox.Text);
            listCategory.Add(cat);
            if (newCtgrTxtBox.Text != "")
                checkedListBox1.Items.Add(newCtgrTxtBox.Text);
            newCtgrTxtBox.Text = "";

            initComboBox();
            checkedListBox1.SetItemChecked(checkedListBox1.Items.Count-1, true);
        }

        private void btn_deleteCategory_Click_1(object sender, EventArgs e)
        {
            for(int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
            {
                int n = checkedListBox1.CheckedIndices[i];
                listCategory.Remove(listCategory.Find(x => x.name == checkedListBox1.Items[n].ToString()));
            }
            

            while (checkedListBox1.CheckedItems.Count > 0)
            {
                checkedListBox1.Items.RemoveAt(checkedListBox1.CheckedIndices[0]);
            }

            initComboBox();
        }

        private void initCheckedlistBox() // 카테고리
        {
            listCategory = DB_fuction_category.DB_load_All_cat();

            checkedListBox1.Items.Clear();

            for(int i = 0; i < listCategory.Count; i++)
            {
                checkedListBox1.Items.Add(listCategory[i].name);
                if(listCategory[i].id > max)
                {
                    max = listCategory[i].id;
                }
            }

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void initCheckedlistBox2()
        {
            List<checkedlist> list = DB_fuction_checked.DB_load_All_checked();

            for(int i = 0; i < list.Count; i++)
            {
                checkedListBox2.Items.Add(list[i].txt_detail);
            }

            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].check)
                {
                    checkedListBox2.SetItemChecked(i, true);
                }
            }
        }

        public void SetCheckedList(string[] strArr)
        {
            for (int i = strArr.Length - 1; i > -1; i--)
                checkedListBox2.Items.Add(strArr[i]);
        }

        public void initComboBox()
        {
            comboBox_Category.Items.Clear();
            for (int i = 0; i < listCategory.Count; i++)
            {
                comboBox_Category.Items.Add(listCategory[i].name);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectDateStart();

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            string Conn = "Server=airysm.mysql.database.azure.com;Database=db_scheduler;Uid=Airysm@Airysm;Pwd=shwon8040!";

            if (metroCheckBox1.Checked)
            {
                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand sdc = new MySqlCommand("UPDATE email SET email.check = 1", conn);
                    sdc.ExecuteNonQuery();
                }

            }
            else
            {
                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand sdc = new MySqlCommand("UPDATE email SET email.check = 0", conn);
                    sdc.ExecuteNonQuery();
                }
            }
        }

        private void btn_mail_Click(object sender, EventArgs e)
        {
            Child.Show();
        }
    }
}
