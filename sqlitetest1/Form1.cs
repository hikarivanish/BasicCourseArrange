using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using course;
using System.Threading;
namespace sqlitetest1
{
    public partial class Form1 : Form
    {
        private List<Course> mCourseList;
        private List<ClassChoice> mClassChoiceList;
        private int minCount = 0;//at least minCount ClassChoices
        private double minCredit = 0;
        private Thread processThread = null;
        private System.Threading.Timer timer;//timer to kill the thread
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CourseDbService.InitDb();
            showCourses();
        }
        private void showCourses()
        {
            mCourseList = CourseDbService.GetAllCourses();
            this.dataGridView1.Rows.Clear();
            foreach (Course c in mCourseList)
            {
                this.dataGridView1.Rows.Add(c.Code, c.Name, c.Ps, c.Term, c.Credit);
            }
        }
        private void showClassChoices(int courseId)
        {
            mClassChoiceList = CourseDbService.GetClassChoicesByCourseId(courseId);
            this.dataGridView2.Rows.Clear();
            foreach (ClassChoice cc in mClassChoiceList)
            {
                this.dataGridView2.Rows.Add(cc.Teacher, cc.Location, cc.Ps);
            }
        }
        private void btn_addCourse_Click(object sender, EventArgs e)
        {
            var result = new FormCourse(null, FormCourse.Mode.ADD).ShowDialog();
            showCourses();
        }

        private void btn_editCourse_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            new FormCourse(mCourseList[dataGridView1.CurrentRow.Index], FormCourse.Mode.EDIT).ShowDialog();
            showCourses();
        }

        private void btn_deleteCourse_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            int index = dataGridView1.CurrentRow.Index;
            CourseDbService.DeleteCourseById(mCourseList[index].Id);
            CourseDbService.DeleteClassChoicesByCourseId(mCourseList[index].Id);
            mCourseList.RemoveAt(index);
            dataGridView1.Rows.RemoveAt(index);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.RowCount == 0)
            {
                dataGridView2.Rows.Clear();
                return;
            }
            showClassChoices(mCourseList[dataGridView1.CurrentRow.Index].Id);
        }

        private void btn_addClassChoice_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.RowCount == 0)
                return;
            new FormClassChoice(mCourseList[dataGridView1.CurrentRow.Index].Id).ShowDialog();
            showClassChoices(mCourseList[dataGridView1.CurrentRow.Index].Id);
        }

        private void btn_editClassChoice_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null || dataGridView2.RowCount == 0)
                return;
            new FormClassChoice(mClassChoiceList[dataGridView2.CurrentRow.Index]).ShowDialog();
            showClassChoices(mCourseList[dataGridView1.CurrentRow.Index].Id);
        }

        private void btn_deleteClassChoice_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
                return;
            int index = dataGridView2.CurrentRow.Index;
            CourseDbService.DeleteClassChoiceById(mClassChoiceList[index].Id);
            mClassChoiceList.RemoveAt(index);
            dataGridView2.Rows.RemoveAt(index);
        }

        private void btn_process_Click(object sender, EventArgs e)
        {
            minCount = 0;
            minCredit = 0;
            if (checkBox_useMinCout.Checked)
            {
                try
                {
                    minCount = int.Parse(tb_minCount.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("input error");
                }
            }
            if (checkBox_useMinCredit.Checked)
            {
                try
                {
                    minCredit = double.Parse(tb_mincredit.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("input error");
                }
            }
            btn_process.Enabled = false;
            processThread = new Thread(process);
            processThread.Start();
        }
        void process()
        {
            bool finished = false;//flag 
            timer = new System.Threading.Timer(delegate(Object o)//kill the long time thread
            {

                if (finished)
                    return;
                (o as Thread).Abort();
                btn_process.Invoke(new MethodInvoker(() =>
                {
                    btn_process.Enabled = true;
                }));
                MessageBox.Show("not found");
            }, Thread.CurrentThread, 10000, 0);
            List<ClassChoice> allClassChoices = CourseDbService.GetAllClassChoices();//get all classChoice
            var neededchoices = CourseDbService.GetNeedChoices();
            List<ClassChoice> solution;
            double creditsum = 0;
            double bcredit = 0;
            bool w = false;
            do
            {
                solution = Arrange.arrange(allClassChoices);
                //solution = Arrange.arrange(neededchoices, allClassChoices);
                creditsum = 0;
                bcredit = 0;
                w = false;
                foreach (var cc in solution)
                {
                    var coursec = CourseDbService.GetCourseById(cc.CourseId);
                    creditsum += coursec.Credit;
                    if (coursec.Code.StartsWith("B"))
                    {
                        bcredit += coursec.Credit;
                    }
                    else if (coursec.Code.StartsWith("W"))
                    {

                        w = true;
                    }
                }
            //} while (solution.Count < minCount || creditsum < minCredit-0.1 || bcredit > 9-0.1 || !w);
            } while (solution.Count < minCount || creditsum < minCredit-0.1 );
            finished = true;
            btn_process.Invoke(new MethodInvoker(() =>
            {
                btn_process.Enabled = true;
            }));
            new FormCourseTable(solution).ShowDialog();
        }

        private void checkBox_useMinCout_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_useMinCout.Checked)
            {
                tb_minCount.Enabled = true;
            }
            else
            {
                tb_minCount.Enabled = false;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start("http://hikarivanish.lofter.com/");
        }

        private void checkBox_useMinCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_useMinCredit.Checked)
            {
                tb_mincredit.Enabled = true;
            }
            else
            {
                tb_mincredit.Enabled = false;
            }
        }
    }
}
