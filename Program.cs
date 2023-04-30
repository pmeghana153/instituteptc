using DbExample.Services;
using DbExample.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DbExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = "Data Source=DESKTOP-IM0V93L\\SQLEXPRESS;Integrated Security=True;database=institute";
            StudentService studentService = new StudentService(ConnectionString);

            //////Student student = new Student();
            //////Console.WriteLine("Enter roll number ");
            //////student.Roll =Convert.ToInt32(Console.ReadLine());

            //////Console.WriteLine("Enter Student Name ");
            //////student.Name = Console.ReadLine();

            //////Console.WriteLine("Enter DOB(yyyy-mm-dd) ");
            //////student.DOB =Convert.ToDateTime(Console.ReadLine());

            //////Console.WriteLine("Enter Course ");
            //////student.Course = Console.ReadLine();

            //////studentService.AddStudent(student);
            //////Console.WriteLine("Student inserted successfully");

            foreach (Student stud in studentService.getStudent())
            {
                Console.WriteLine("Roll " + stud.Roll);
                Console.WriteLine("Name " + stud.Name);
                Console.WriteLine("Course " + stud.Course);
                if (stud.DOB != null)
                {
                    Console.WriteLine("DOB " + stud.DOB.Value.ToString("yyyy-MMM-dd"));
                }
                else
                {
                    Console.WriteLine("DOB ");
                }
            }

            Console.ReadKey();
        }
    }
}
