using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using course;
namespace sqlitetest1
{
    public partial class FormClassChoice : Form
    {
        private const int CHECKBOX_X = 20;
        private const int CHECKBOX_Y = 20;
        private const int CHECKBOX_INTERVAL_Y = 20;
        private const int CHECKBOX_INTERVAL_X = 40;
        private List<CheckBox> checkBoxList;
        public enum Mode { ADD, EDIT };
        private Mode mAddOrEdit = Mode.ADD;
        private ClassChoice mClassChoice;
        public FormClassChoice(ClassChoice cc)
        {
            mClassChoice = cc;
            mAddOrEdit = Mode.EDIT;
            InitializeComponent();
        }
        public FormClassChoice(int courseId)
        {
            mClassChoice = new ClassChoice();
            mClassChoice.CourseId = courseId;
            mAddOrEdit = Mode.ADD;
            InitializeComponent();
        }
        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClassChoice_Load(object sender, EventArgs e)
        {
            switch (mAddOrEdit)
            {
                case Mode.ADD:
                    break;
                case Mode.EDIT:
                    classChoiceToForm();
                    break;
            }
            checkBoxList = new List<CheckBox>();
            for (int i = 0; i < 60; i++)
            {
                CheckBox cb = new CheckBox();
                checkBoxList.Add(cb);
                cb.Size = new System.Drawing.Size(20, 20);
                cb.Location = new Point(CHECKBOX_X + i / 12 * CHECKBOX_INTERVAL_X,
                    CHECKBOX_Y + i % 12 * CHECKBOX_INTERVAL_Y
                    + (i % 12 >= 5 ? 15 : 0) + (i % 12 >= 9 ? 15 : 0));
                cb.Checked = (mAddOrEdit == Mode.EDIT ? mClassChoice.GetScheduleBoolArray()[i] : false);
                this.groupBox_schedule.Controls.Add(cb);
            }
        }
        public void classChoiceToForm()
        {
            if (mClassChoice == null)
                return;
            tb_location.Text = mClassChoice.Location;
            tb_ps.Text = mClassChoice.Ps;
            tb_teacher.Text = mClassChoice.Teacher;
        }
        public void formToClassChoice()
        {
            mClassChoice.Location = tb_location.Text;
            mClassChoice.Ps = tb_ps.Text;
            mClassChoice.Teacher = tb_teacher.Text;
            bool[] boolArray = new bool[60];
            for (int i = 0; i < 60; i++)
            {
                boolArray[i] = checkBoxList[i].Checked;
            }
            mClassChoice.SetScheduleByBoolArray(boolArray);
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            formToClassChoice();
            switch (mAddOrEdit)
            {
                case Mode.ADD:
                    CourseDbService.InsertClassChoice(mClassChoice.CourseId, mClassChoice);
                    break;
                case Mode.EDIT:
                    CourseDbService.UpdateClassChoice(mClassChoice);
                    break;
            }
            this.Close();
        }
    }
}
