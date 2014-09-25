using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace course
{
   public  class Course
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Ps { set; get; }
        public int Term { set; get; }
        public double Credit { set; get; }

        public Course(int id, string code, string name, string ps, int term, double credit)
        {
            this.Id = id;
            this.Code = code;
            this.Name = name;
            this.Ps = ps;
            this.Term = term;
            this.Credit = credit;
        }
        public Course(string code, string name, string ps, int term, double credit)
            : this(0, code, name, ps, term, credit)
        { }
        public Course()
            : this("", "", "", 0, 0)
        {
        }
    }
}
