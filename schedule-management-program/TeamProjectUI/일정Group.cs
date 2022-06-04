using System.Windows.Forms;
using MetroFramework.Controls;

namespace TeamProject
{
    public class 일정Group // 버튼을 누르면 생성되는 Control들 모음
    {
        private GroupBox groupBox_일정;
        private TextBox textBox_일정;
        private MetroButton editBtn_일정;
        private MetroButton deleteBtn_일정;
        private MetroButton saveBtn_일정;
        private MetroLabel numLbl_일정;
        private ComboBox combo_일정;

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

        public ComboBox Combo_일정
        {
            get;
            set;
        }
    }
}
