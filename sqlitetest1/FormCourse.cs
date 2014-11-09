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
    public partial class FormCourse : Form
    {

        public enum Mode { ADD, EDIT };
        private Mode mAddOrEdit = Mode.ADD;
        private Course mCourse = null;
        public FormCourse(Course c, Mode addOrEdit)
        {
            mCourse = c;
            mAddOrEdit = addOrEdit;
            InitializeComponent();
        }

        private void FormCourse_Load(object sender, EventArgs e)
        {
            switch (mAddOrEdit)
            {
                case Mode.ADD:
                    break;
                case Mode.EDIT:
                    courseToForm();
                    break;
            }

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                formToCourse();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Maybe your input has problem");
                return;
            }
            switch (mAddOrEdit)
            {
                case Mode.ADD:
                    CourseDbService.InsertCourse(mCourse);
                    break;
                case Mode.EDIT:
                    CourseDbService.UpdateCourse(mCourse.Id, mCourse);
                    //add this line
                    break;
            }
            this.Close();
        }
        private void formToCourse()//gather informatin
        {
            int id = ((mCourse == null || mAddOrEdit == Mode.ADD) ? 0 : mCourse.Id);
            mCourse = new Course(id, tb_code.Text, tb_name.Text, tb_ps.Text,
                 Convert.ToInt32(tb_term.Text), Convert.ToDouble(tb_credit.Text));
        }
        private void courseToForm()//adapte information to form to display
        {
            if (mCourse == null)
                return;
            tb_code.Text = mCourse.Code;
            tb_credit.Text = mCourse.Credit.ToString();
            tb_name.Text = mCourse.Name;
            tb_ps.Text = mCourse.Ps;
            tb_term.Text = mCourse.Term.ToString();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
