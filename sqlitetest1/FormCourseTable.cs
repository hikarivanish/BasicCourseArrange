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
    public partial class FormCourseTable : Form
    {
        private static Random random = new Random();
        private List<ClassChoice> solution;
        const int LABLE_WIDTH = 70, LABLE_HEIGHT = 40; //label's width and height for one block
        const int LABLE_X = 830, LABLE_Y = 5;//label's starting position
        const int INTERVAL = 10;//interval between morning and afternoon and evening
        public FormCourseTable(List<ClassChoice> solution)
        {
            InitializeComponent();
            this.solution = solution;
        }

        private void FormCourseTable_Load(object sender, EventArgs e)//display the solution
        {
            this.AutoSize = true;
            foreach (ClassChoice cc in solution)
            {
                Course c = CourseDbService.GetCourseById(cc.CourseId);
                dataGridView.Rows.Add(c.Name, cc.Ps, cc.Teacher, cc.Location, c.Code, c.Credit);
                string choiceInfo = c.Code + "\n" + c.Name + "\n" + cc.Teacher + "\n" + cc.Location;
                int start = 0;
                int r = random.Next(255), g = random.Next(255), b = random.Next(255);//color rgb
                for (int i = 0; i < 5; i++)
                {
                    bool flagOne = false;
                    for (int j = 0; j < 13; j++)
                    {
                        if (flagOne && (j == 12 || cc.Schedule[13 * i + j] != '1'))
                        {
                            Label label = new Label();
                            label.AutoSize = false;
                            label.BackColor = Color.FromArgb(r, g, b);
                            label.ForeColor = Color.FromArgb(255 - r, 255 - g, 255 - b);
                            label.TextAlign = ContentAlignment.MiddleCenter;
                            label.Width = LABLE_WIDTH;
                            label.Location = new Point(LABLE_X + i * LABLE_WIDTH,
                                LABLE_Y + start * LABLE_HEIGHT + (j > 4 ? INTERVAL : 0) + (j > 10 ? INTERVAL : 0));
                            label.Height = LABLE_HEIGHT * (j - start);
                            label.Text = choiceInfo;
                            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7,
                                FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                            this.Controls.Add(label);
                            flagOne = false;
                        }
                        else if (!flagOne && j != 12 && cc.Schedule[13 * i + j] == '1')
                        {
                            flagOne = true;
                            start = j;
                        }

                    }
                }
            }
        }
    }
}
