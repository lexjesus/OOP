using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace proj
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentGroup group1 = new StudentGroup("8091", 10);
            StudentGroup group2 = new StudentGroup("8311", 10);


            Student s1 = new Student("Шаклеин", "Всеволод", "Иванович");
            Student s2 = new Student("Баранов", "Алексей", "Сергеевич");
            Student s3 = new Student("Ефимов", "Артем", "Сергеевич");
            Student s4 = new Student("Артемов", "Ефим", "Алексеевич");
            Student s5 = new Student("Григорьев", "Дмитрий", "Григорьевич");
            Student s6 = new Student("Магомедов", "Магомед", "Магомедович");

            try
            {
                group1.AddStudent(new List<Student> { s1, s2, s3, s4, s5, s6 });
            }
            catch (AddStudentException e)
            {
                WriteLine(e.Message);
                WriteLine($"{e.Value} students are not added");
            }

            try
            {
                group2.AddStudent(s5);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            try
            {
                group2.AddStudent(s6);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            try
            {
                group1.AddStudent(new Student("Путин", "Владимир", "Владимирович"));
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            Student s7;

            s7 = group1.GetStudent("Путин", "Владимир", "Владимирович");

            try
            {
                group2.AddStudent(s7);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            group1.DisplaySortedByName();

            try
            {
                group1.AddMarks("Артемов", "Ефим", "Алексеевич", new List<int> { 3, 4, 4, 5 });
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            try
            {
                group1.AddMarks(s7, new List<int> { 2, 4, 6, 3, 7 });
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            try
            {
                group2.AddMarks(s1, new List<int> { 2, 4, 6, 3, 7 });
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }



            group1.DisplaySortedByMarks();

            WriteLine(group1);
            WriteLine(group2);
            WriteLine(s5);
            WriteLine(s6);
            WriteLine(s7);


            ReadLine();


        }
    }
}
