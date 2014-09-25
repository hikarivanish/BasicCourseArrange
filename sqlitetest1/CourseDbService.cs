using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
namespace course
{
    class CourseDbService
    {
        private const string TABLE_NAME_COURSE = "course";
        private const string COLUMN_NAME_COURSE_ID = "id";
        private const string COLUMN_NAME_COURSE_CODE = "code";
        private const string COLUMN_NAME_COURSE_NAME = "name";
        private const string COLUMN_NAME_COURSE_TERM = "term";
        private const string COLUMN_NAME_COURSE_CREDIT = "credit";
        private const string COLUMN_NAME_COURSE_PS = "ps";

        private const string TABLE_NAME_CLASS_CHOICE = "class_choice";
        private const string COLUMN_NAME_CLASS_CHOICE_ID = "id";
        private const string COLUMN_NAME_CLASS_CHOICE_COURSE_ID = "course_id";
        private const string COLUMN_NAME_CLASS_CHOICE_TEACHER = "teacher";
        private const string COLUMN_NAME_CLASS_CHOICE_LOCATION = "location";
        private const string COLUMN_NAME_CLASS_CHOICE_SCHEDULE = "schedule";
        private const string COLUMN_NAME_CLASS_CHOICE_PS = "ps";

        private const string DB_PATH = "course.db";

        private const string TABLE_CREATE_COURSE = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME_COURSE + "("
                + COLUMN_NAME_COURSE_ID + " INTEGER PRIMARY KEY AUTOINCREMENT,"
                + COLUMN_NAME_COURSE_CODE + " TEXT,"
                + COLUMN_NAME_COURSE_NAME + " TEXT,"
                + COLUMN_NAME_COURSE_PS + " TEXT,"
                + COLUMN_NAME_COURSE_TERM + " INTEGER,"
                + COLUMN_NAME_COURSE_CREDIT + " DOUBLE);";
        private const string TABLE_CREATE_CLASS_CHOICE = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME_CLASS_CHOICE + "("
                + COLUMN_NAME_CLASS_CHOICE_ID + " INTEGER PRIMARY KEY AUTOINCREMENT,"
                + COLUMN_NAME_CLASS_CHOICE_COURSE_ID + " INTEGER,"
                + COLUMN_NAME_CLASS_CHOICE_TEACHER + " TEXT,"
                + COLUMN_NAME_CLASS_CHOICE_LOCATION + " TEXT,"
                + COLUMN_NAME_CLASS_CHOICE_SCHEDULE + " TEXT,"
                + COLUMN_NAME_CLASS_CHOICE_PS + " TEXT);";

        private static SQLiteConnection conn = new SQLiteConnection();
        private static SQLiteCommand cmd = null;


        public static void InitDb()
        {
            SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder();
            sb.DataSource = DB_PATH;
            conn.ConnectionString = sb.ToString();
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = TABLE_CREATE_COURSE;
            cmd.ExecuteNonQuery();
            cmd.CommandText = TABLE_CREATE_CLASS_CHOICE;
            cmd.ExecuteNonQuery();
        }
        public static int InsertClassChoice(int courseId, string teacher, string location, string schedule, string ps)
        {
            if (cmd == null)
                return 0;
            cmd.CommandText = "INSERT INTO " + TABLE_NAME_CLASS_CHOICE + "("
                + COLUMN_NAME_CLASS_CHOICE_COURSE_ID + ","
                + COLUMN_NAME_CLASS_CHOICE_LOCATION + ","
                + COLUMN_NAME_CLASS_CHOICE_PS + ","
                + COLUMN_NAME_CLASS_CHOICE_SCHEDULE + ","
                + COLUMN_NAME_CLASS_CHOICE_TEACHER + ") VALUES("
                + courseId + ","
                + "'" + location + "',"
                + "'" + ps + "',"
                + "'" + schedule + "',"
                + "'" + teacher + "');";
            cmd.ExecuteNonQuery();
            return (int)conn.LastInsertRowId;
        }
        public static int InsertClassChoice(int courseId, ClassChoice cc)
        {
            return InsertClassChoice(courseId, cc.Teacher, cc.Location, cc.Schedule, cc.Ps);
        }
        public static int UpdateClassChoice(int id, string teacher, string location, string schedule, string ps)
        {
            if (cmd == null)
                return 0;
            cmd.CommandText = "UPDATE " + TABLE_NAME_CLASS_CHOICE + " SET "
                + COLUMN_NAME_CLASS_CHOICE_LOCATION + "='" + location + "',"
                + COLUMN_NAME_CLASS_CHOICE_PS + "='" + ps + "',"
                + COLUMN_NAME_CLASS_CHOICE_SCHEDULE + "='" + schedule + "',"
                + COLUMN_NAME_CLASS_CHOICE_TEACHER + "='" + teacher + "'"
                + " WHERE " + COLUMN_NAME_CLASS_CHOICE_ID + "==" + id + ";";
            return cmd.ExecuteNonQuery();
        }
        public static int UpdateClassChoice(int id, ClassChoice cc)
        {
            return UpdateClassChoice(id, cc.Teacher, cc.Location, cc.Schedule, cc.Ps);
        }
        public static int UpdateClassChoice(ClassChoice cc)
        {
            return UpdateClassChoice(cc.Id, cc);
        }
        public static int DeleteClassChoiceById(int id)
        {
            if (cmd == null)
                return 0;
            cmd.CommandText = "DELETE FROM " + TABLE_NAME_CLASS_CHOICE
                + " WHERE " + COLUMN_NAME_CLASS_CHOICE_ID + "==" + id + ";";
            return cmd.ExecuteNonQuery();
        }
        public static int DeleteClassChoicesByCourseId(int courseId)
        {
            if (cmd == null)
                return 0;
            cmd.CommandText = "DELETE FROM " + TABLE_NAME_CLASS_CHOICE
                + " WHERE " + COLUMN_NAME_CLASS_CHOICE_COURSE_ID + "==" + courseId + ";";
            return cmd.ExecuteNonQuery();
        }
        public static List<ClassChoice> GetClassChoicesByCourseId(int courseId)
        {
            if (cmd == null)
                return null;
            List<ClassChoice> list = new List<ClassChoice>();
            cmd.CommandText = "SELECT " + COLUMN_NAME_CLASS_CHOICE_COURSE_ID + ", "
                + COLUMN_NAME_CLASS_CHOICE_ID + ","
                + COLUMN_NAME_CLASS_CHOICE_LOCATION + ","
                + COLUMN_NAME_CLASS_CHOICE_PS + ","
                + COLUMN_NAME_CLASS_CHOICE_SCHEDULE + ","
                + COLUMN_NAME_CLASS_CHOICE_TEACHER +
                " FROM " + TABLE_NAME_CLASS_CHOICE
                + " WHERE " + COLUMN_NAME_CLASS_CHOICE_COURSE_ID + "==" + courseId + ";";
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ClassChoice(reader.GetInt32(1), reader.GetInt32(0),
                    reader.GetString(5), reader.GetString(2),
                    reader.GetString(4), reader.GetString(3)
                ));
            }
            reader.Close();
            return list;
        }
        public static List<ClassChoice> GetAllClassChoices()
        {
            if (cmd == null)
                return null;
            List<ClassChoice> list = new List<ClassChoice>();
            cmd.CommandText = "SELECT " + COLUMN_NAME_CLASS_CHOICE_COURSE_ID + ", "
                + COLUMN_NAME_CLASS_CHOICE_ID + ","
                + COLUMN_NAME_CLASS_CHOICE_LOCATION + ","
                + COLUMN_NAME_CLASS_CHOICE_PS + ","
                + COLUMN_NAME_CLASS_CHOICE_SCHEDULE + ","
                + COLUMN_NAME_CLASS_CHOICE_TEACHER +
                " FROM " + TABLE_NAME_CLASS_CHOICE + ";";
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ClassChoice(reader.GetInt32(1), reader.GetInt32(0),
                    reader.GetString(5), reader.GetString(2),
                    reader.GetString(4), reader.GetString(3)
                ));
            }
            reader.Close();
            return list;
        }

        public static List<ClassChoice> GetNeedChoices()
        {
            if (cmd == null)
                return null;
            List<ClassChoice> list = new List<ClassChoice>();
            cmd.CommandText = "SELECT " + COLUMN_NAME_CLASS_CHOICE_COURSE_ID + ", "
                + COLUMN_NAME_CLASS_CHOICE_ID + ","
                + COLUMN_NAME_CLASS_CHOICE_LOCATION + ","
                + COLUMN_NAME_CLASS_CHOICE_PS + ","
                + COLUMN_NAME_CLASS_CHOICE_SCHEDULE + ","
                + COLUMN_NAME_CLASS_CHOICE_TEACHER +
                " FROM " + TABLE_NAME_CLASS_CHOICE + " where course_id in (select id from course where code like 'S%'or code like 'A%' or code like 'W%');";
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ClassChoice(reader.GetInt32(1), reader.GetInt32(0),
                    reader.GetString(5), reader.GetString(2),
                    reader.GetString(4), reader.GetString(3)
                ));
            }
            reader.Close();
            return list;
        }

        public static int InsertCourse(string code, string name, string ps, int term, double credit)
        {
            if (cmd == null)
                return 0;
            cmd.CommandText = "INSERT INTO " + TABLE_NAME_COURSE + "("
                + COLUMN_NAME_COURSE_CODE + ","
                + COLUMN_NAME_COURSE_CREDIT + ","
                + COLUMN_NAME_COURSE_NAME + ","
                + COLUMN_NAME_COURSE_PS + ","
                + COLUMN_NAME_COURSE_TERM + ") VALUES("
                + "'" + code + "',"
                + credit + ","
                + "'" + name + "',"
                + "'" + ps + "',"
                + term + ");";
            cmd.ExecuteNonQuery();
            return (int)conn.LastInsertRowId;
        }
        public static int InsertCourse(Course c)
        {
            return InsertCourse(c.Code, c.Name, c.Ps, c.Term, c.Credit);
        }
        public static int UpdateCourse(int id, string code, string name, string ps, int term, double credit)
        {
            if (cmd == null)
                return 0;
            cmd.CommandText = "UPDATE " + TABLE_NAME_COURSE + " SET "
                + COLUMN_NAME_COURSE_CODE + "='" + code + "',"
                + COLUMN_NAME_COURSE_CREDIT + "=" + credit + ","
                + COLUMN_NAME_COURSE_NAME + "='" + name + "',"
                + COLUMN_NAME_COURSE_PS + "='" + ps + "',"
                + COLUMN_NAME_COURSE_TERM + "=" + term
                + " WHERE " + COLUMN_NAME_COURSE_ID + "==" + id + ";";
            return cmd.ExecuteNonQuery();
        }
        public static int UpdateCourse(int id, Course c)
        {
            return UpdateCourse(id, c.Code, c.Name, c.Ps, c.Term, c.Credit);
        }
        public static int DeleteCourseById(int id)
        {
            if (cmd == null)
                return 0;
            cmd.CommandText = "DELETE FROM " + TABLE_NAME_COURSE
                + " WHERE " + COLUMN_NAME_COURSE_ID + "==" + id + ";";
            return cmd.ExecuteNonQuery();
        }

        public static List<Course> GetAllCourses()
        {
            if (cmd == null)
                return null;
            List<Course> list = new List<Course>();
            cmd.CommandText = "SELECT "
                + COLUMN_NAME_COURSE_ID + ","
                + COLUMN_NAME_COURSE_CODE + ","
                + COLUMN_NAME_COURSE_CREDIT + ","
                + COLUMN_NAME_COURSE_NAME + ","
                + COLUMN_NAME_COURSE_PS + ","
                + COLUMN_NAME_COURSE_TERM
                + " FROM " + TABLE_NAME_COURSE + ";";
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Course c = new Course(reader.GetString(1),
                        reader.GetString(3), reader.GetString(4),
                        reader.GetInt32(5), reader.GetDouble(2));
                c.Id = reader.GetInt32(0);
                list.Add(c);
            }
            reader.Close();//important!!
            return list;
        }




        public static Course GetCourseById(int id)
        {
            if (cmd == null)
                return null;
            Course c = null;
            cmd.CommandText = "SELECT "
                + COLUMN_NAME_COURSE_ID + ","
                + COLUMN_NAME_COURSE_CODE + ","
                + COLUMN_NAME_COURSE_CREDIT + ","
                + COLUMN_NAME_COURSE_NAME + ","
                + COLUMN_NAME_COURSE_PS + ","
                + COLUMN_NAME_COURSE_TERM
                + " FROM " + TABLE_NAME_COURSE + " WHERE " + COLUMN_NAME_COURSE_ID + "==" + id + ";";
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                c = new Course(reader.GetString(1),
                       reader.GetString(3), reader.GetString(4),
                       reader.GetInt32(5), reader.GetDouble(2));
                c.Id = reader.GetInt32(0);
            }
            reader.Close();//important!!
            return c;
        }
    }
}
