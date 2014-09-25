using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace course
{
    public class ClassChoice : IComparable
    {
        public int Id { set; get; }
        public int CourseId { set; get; }
        public string Teacher { set; get; }
        public string Location { set; get; }
        public string Schedule { set; get; }
        public string Ps { set; get; }

        public ClassChoice(int id, int courseId, string teacher, string location, string schedule, string ps)
        {
            this.Id = id;
            this.CourseId = courseId;
            this.Teacher = teacher;
            this.Location = location;
            this.Schedule = schedule;
            this.Ps = ps;
        }
        public ClassChoice(int courseId, string teacher, string location, string schedule, string ps)
            : this(0, courseId, teacher, location, schedule, ps)
        {
        }
        public ClassChoice(string teacher, string location, string schedule, string ps)
            : this(0, teacher, location, schedule, ps)
        {
        }
        public ClassChoice()
            : this("", "", "", "")
        {

        }
        public bool[] GetScheduleBoolArray()
        {
            bool[] boolArray = new bool[60];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    boolArray[12 * i + j] = Schedule[13 * i + j] == '1';
                }
            }

            return boolArray;
        }
        public void SetScheduleByBoolArray(bool[] boolArray)
        {
            if (boolArray == null || boolArray.Length == 0)
                return;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    sb.Append(boolArray[12 * i + j] ? '1' : '0');
                }
                if (i < 4)
                    sb.Append('-');
            }
            Schedule = sb.ToString();
        }
        public bool IsConflictWith(ClassChoice cc)
        {
            if (cc.CourseId == CourseId)
                return true;
            for (int i = 0; i < cc.Schedule.Length; i++)
            {
                if (cc.Schedule[i] == '1' && Schedule[i] == '1')
                    return true;
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            return (obj as ClassChoice).Id - Id;
        }
    }
}
