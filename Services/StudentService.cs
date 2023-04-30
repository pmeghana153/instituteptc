using DbExample.DBHelpers;
using DbExample.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace DbExample.Services
{
    public class StudentService
    {
        private readonly string _connectionString;
        private readonly SqlHelper sqlHelper;
		int counter=0;
        public StudentService(string connectionString)
        {
            sqlHelper=new SqlHelper(connectionString);
        }
        public void AddStudent(Student student)
        {
			counter++;
            string Query = "insert into student(roll,s_name,DOB,Course) values(@roll,@s_name,@DOB,@Course)";

            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@roll",SqlDbType.Int);
            sqlParameters[0].Value = student.Roll;

            sqlParameters[1] = new SqlParameter("@s_name", SqlDbType.VarChar);
            sqlParameters[1].Value = student.Name;

            sqlParameters[2] = new SqlParameter("@DOB", SqlDbType.DateTime);
            sqlParameters[2].Value = student.DOB;

            sqlParameters[3] = new SqlParameter("@Course", SqlDbType.VarChar);
            sqlParameters[3].Value = student.Course;
            sqlHelper.InsertUpdateAndDeleteRecord(Query, sqlParameters);
        }

        public void UpdateStudent(Student student)
        {
            string Query = "update student set s_name=@s_name,DOB=@DOB,Course=@Course where roll=@roll";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@roll", SqlDbType.Int);
            sqlParameters[0].Value = student.Roll;

            sqlParameters[1] = new SqlParameter("@s_name", SqlDbType.VarChar);
            sqlParameters[1].Value = student.Name;

            sqlParameters[2] = new SqlParameter("@DOB", SqlDbType.DateTime);
            sqlParameters[2].Value = student.DOB;

            sqlParameters[3] = new SqlParameter("@Course", SqlDbType.VarChar);
            sqlParameters[3].Value = student.Course;
            sqlHelper.InsertUpdateAndDeleteRecord(Query, sqlParameters);
        }
        public List<Student> getStudent()
        {
            List<Student> students = new List<Student>();
            DataTable dt= sqlHelper.GetRecord("select * from student");
            if(dt!=null&&dt.Rows.Count>0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DateTime? dob;
                   if(Convert.IsDBNull(row["DOB"]))
                    {
                        dob = null;
                    }
                   else
                    {
                        dob = Convert.ToDateTime(row["DOB"]);
                    }
                    students.Add(new Student() {
                        Roll =Convert.ToInt32(row["roll"]),
                        Name = row["s_name"].ToString(),
                        Course = row["course"].ToString(),
                        DOB=dob
                    });
                }
            }
            return students;
        }


    }
}
