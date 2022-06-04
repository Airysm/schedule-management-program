
namespace TeamProject
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.newCtgrTxtBox = new System.Windows.Forms.TextBox();
            this.btn_deleteCategory = new MetroFramework.Controls.MetroButton();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.metroButton_Add = new MetroFramework.Controls.MetroButton();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.flowLayoutPanel_일정 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.btn_addChecklist = new MetroFramework.Controls.MetroButton();
            this.comboBox_Category = new System.Windows.Forms.ComboBox();
            this.btn_mail = new MetroFramework.Controls.MetroButton();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel_일정.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(6, 20);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(125, 23);
            this.metroButton1.TabIndex = 6;
            this.metroButton1.Text = "+ 새 목록";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.newCtgrTxtBox);
            this.groupBox2.Controls.Add(this.btn_deleteCategory);
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Controls.Add(this.metroButton1);
            this.groupBox2.Location = new System.Drawing.Point(23, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 291);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // newCtgrTxtBox
            // 
            this.newCtgrTxtBox.Location = new System.Drawing.Point(6, 49);
            this.newCtgrTxtBox.Name = "newCtgrTxtBox";
            this.newCtgrTxtBox.Size = new System.Drawing.Size(129, 21);
            this.newCtgrTxtBox.TabIndex = 10;
            // 
            // btn_deleteCategory
            // 
            this.btn_deleteCategory.Location = new System.Drawing.Point(56, 256);
            this.btn_deleteCategory.Name = "btn_deleteCategory";
            this.btn_deleteCategory.Size = new System.Drawing.Size(70, 23);
            this.btn_deleteCategory.TabIndex = 9;
            this.btn_deleteCategory.Text = "목록 삭제";
            this.btn_deleteCategory.UseSelectable = true;
            this.btn_deleteCategory.Click += new System.EventHandler(this.btn_deleteCategory_Click_1);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "학업",
            "운동",
            "생활"});
            this.checkedListBox1.Location = new System.Drawing.Point(7, 76);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(128, 212);
            this.checkedListBox1.TabIndex = 7;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(175, 69);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_Category);
            this.groupBox3.Controls.Add(this.metroButton_Add);
            this.groupBox3.Controls.Add(this.metroTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(3, 251);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // metroButton_Add
            // 
            this.metroButton_Add.Location = new System.Drawing.Point(259, 71);
            this.metroButton_Add.Name = "metroButton_Add";
            this.metroButton_Add.Size = new System.Drawing.Size(75, 23);
            this.metroButton_Add.TabIndex = 1;
            this.metroButton_Add.Text = "Add";
            this.metroButton_Add.UseSelectable = true;
            this.metroButton_Add.Click += new System.EventHandler(this.metroButton_Add_Click);
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(282, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(45, 45);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(6, 20);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Multiline = true;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.PromptText = "일정 입력";
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(328, 47);
            this.metroTextBox1.TabIndex = 0;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMark = "일정 입력";
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // flowLayoutPanel_일정
            // 
            this.flowLayoutPanel_일정.AutoScroll = true;
            this.flowLayoutPanel_일정.Controls.Add(this.groupBox3);
            this.flowLayoutPanel_일정.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel_일정.Location = new System.Drawing.Point(407, 69);
            this.flowLayoutPanel_일정.Margin = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel_일정.Name = "flowLayoutPanel_일정";
            this.flowLayoutPanel_일정.Size = new System.Drawing.Size(370, 354);
            this.flowLayoutPanel_일정.TabIndex = 2;
            this.flowLayoutPanel_일정.WrapContents = false;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(175, 243);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(219, 180);
            this.checkedListBox2.TabIndex = 2;
            // 
            // btn_addChecklist
            // 
            this.btn_addChecklist.Location = new System.Drawing.Point(308, 390);
            this.btn_addChecklist.Name = "btn_addChecklist";
            this.btn_addChecklist.Size = new System.Drawing.Size(75, 23);
            this.btn_addChecklist.TabIndex = 9;
            this.btn_addChecklist.Text = "설정";
            this.btn_addChecklist.UseSelectable = true;
            this.btn_addChecklist.Click += new System.EventHandler(this.btn_addChecklist_Click);
            // 
            // comboBox_Category
            // 
            this.comboBox_Category.FormattingEnabled = true;
            this.comboBox_Category.Location = new System.Drawing.Point(6, 75);
            this.comboBox_Category.Name = "comboBox_Category";
            this.comboBox_Category.Size = new System.Drawing.Size(75, 20);
            this.comboBox_Category.TabIndex = 2;
            this.comboBox_Category.Text = "목록";
            // 
            // btn_mail
            // 
            this.btn_mail.Location = new System.Drawing.Point(29, 69);
            this.btn_mail.Name = "btn_mail";
            this.btn_mail.Size = new System.Drawing.Size(125, 23);
            this.btn_mail.TabIndex = 10;
            this.btn_mail.Text = "이메일 주소 갱신";
            this.btn_mail.UseSelectable = true;
            this.btn_mail.Click += new System.EventHandler(this.btn_mail_Click);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(30, 98);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(122, 15);
            this.metroCheckBox1.TabIndex = 11;
            this.metroCheckBox1.Text = "이메일로 알림받기";
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.metroButton_Add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.btn_mail);
            this.Controls.Add(this.btn_addChecklist);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.flowLayoutPanel_일정);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "일정관리앱";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel_일정.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroButton metroButton_Add;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_일정;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private MetroFramework.Controls.MetroButton btn_deleteCategory;
        private MetroFramework.Controls.MetroButton btn_addChecklist;
        private System.Windows.Forms.TextBox newCtgrTxtBox;
        private System.Windows.Forms.ComboBox comboBox_Category;
        private MetroFramework.Controls.MetroButton btn_mail;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
    }
}

