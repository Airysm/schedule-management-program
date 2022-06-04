using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamProject;

namespace TeamProjectUI
{
    public partial class Form_ChecklistAdd : Form
    {
        public delegate void ChildFormSnedDataHandler(string[] message);
        public event ChildFormSnedDataHandler ChildFormEvent;

        public Form_ChecklistAdd()
        {
            InitializeComponent();
        }

        public Form_ChecklistAdd(string[] str)
        {
            InitializeComponent();

            for(int i = 0; i < str.Length; i++)
            {
                metroListView1.Items.Add(str[i]);
            }
        }

        private void 확인btn_Click(object sender, EventArgs e)
        {
            sendToParent();
            //

            this.Close();
        }

        public void sendToParent()
        {
            string[] strArr = new string[metroListView1.Items.Count];

            for (int i = 0; i < metroListView1.Items.Count; i++)
            {
                strArr[i] = metroListView1.Items[i].Text;
            }

            this.ChildFormEvent(strArr);
        }

        private void 추가btn_Click(object sender, EventArgs e)
        {
            metroListView1.Items.Add(metroTextBox1.Text);
            metroTextBox1.Text = "";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if(metroListView1.SelectedItems.Count > 0)
            {
                int index = metroListView1.FocusedItem.Index;
                metroListView1.Items.RemoveAt(index);
            }
            else
            {

            }
            
        }
    }
}
