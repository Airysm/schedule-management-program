
namespace TeamProjectUI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Mail1 = new MetroFramework.Controls.MetroTextBox();
            this.txt_Mail2 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txt_Mail1
            // 
            // 
            // 
            // 
            this.txt_Mail1.CustomButton.Image = null;
            this.txt_Mail1.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txt_Mail1.CustomButton.Name = "";
            this.txt_Mail1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_Mail1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_Mail1.CustomButton.TabIndex = 1;
            this.txt_Mail1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_Mail1.CustomButton.UseSelectable = true;
            this.txt_Mail1.CustomButton.Visible = false;
            this.txt_Mail1.Lines = new string[0];
            this.txt_Mail1.Location = new System.Drawing.Point(12, 12);
            this.txt_Mail1.MaxLength = 32767;
            this.txt_Mail1.Name = "txt_Mail1";
            this.txt_Mail1.PasswordChar = '\0';
            this.txt_Mail1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Mail1.SelectedText = "";
            this.txt_Mail1.SelectionLength = 0;
            this.txt_Mail1.SelectionStart = 0;
            this.txt_Mail1.ShortcutsEnabled = true;
            this.txt_Mail1.Size = new System.Drawing.Size(75, 23);
            this.txt_Mail1.TabIndex = 0;
            this.txt_Mail1.UseSelectable = true;
            this.txt_Mail1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_Mail1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txt_Mail2
            // 
            // 
            // 
            // 
            this.txt_Mail2.CustomButton.Image = null;
            this.txt_Mail2.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txt_Mail2.CustomButton.Name = "";
            this.txt_Mail2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_Mail2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_Mail2.CustomButton.TabIndex = 1;
            this.txt_Mail2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_Mail2.CustomButton.UseSelectable = true;
            this.txt_Mail2.CustomButton.Visible = false;
            this.txt_Mail2.Lines = new string[0];
            this.txt_Mail2.Location = new System.Drawing.Point(111, 12);
            this.txt_Mail2.MaxLength = 32767;
            this.txt_Mail2.Name = "txt_Mail2";
            this.txt_Mail2.PasswordChar = '\0';
            this.txt_Mail2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Mail2.SelectedText = "";
            this.txt_Mail2.SelectionLength = 0;
            this.txt_Mail2.SelectionStart = 0;
            this.txt_Mail2.ShortcutsEnabled = true;
            this.txt_Mail2.Size = new System.Drawing.Size(75, 23);
            this.txt_Mail2.TabIndex = 1;
            this.txt_Mail2.UseSelectable = true;
            this.txt_Mail2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_Mail2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(88, 14);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(22, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "@";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(12, 41);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(174, 23);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "이메일 입력";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.btn_mail_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 71);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txt_Mail2);
            this.Controls.Add(this.txt_Mail1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txt_Mail1;
        private MetroFramework.Controls.MetroTextBox txt_Mail2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}