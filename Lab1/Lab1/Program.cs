using System;
using static System.Console;
using System.Collections.Generic;

namespace proj
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentGroup group1 = new StudentGroup("8091", 10);
            StudentGroup group2 = new StudentGroup("8311", 10);


            Council s1 = new Council("Шаклеин", "Всеволод", "Иванович");
            Council s2 = new Council("Баранов", "Алексей", "Сергеевич");
            UsualStudent s3 = new UsualStudent("Ефимов", "Артем", "Сергеевич");
            UsualStudent s4 = new UsualStudent("Артемов", "Ефим", "Алексеевич");
            Nerd s5 = new Nerd("Григорьев", "Дмитрий", "Григорьевич");
            Nerd s6 = new Nerd("Магомедов", "Магомед", "Магомедович");


            group1.AddStudent(s1);
            group1.AddStudent(s2);
            group1.AddStudent(s3);
            group2.AddStudent(s3);
            group2.AddStudent(s4);
            group2.AddStudent(s5);
            group2.AddStudent(s6);


            s1.ToExamStudent(group1, "Математика");
            s1.ToExamStudent(group1, "Математика");
            s1.ToExamStudent(group1, "Математика");
            s1.ToExamStudent(group1, "Математика");
            s3.ToExamStudent(group1, "Математика");
            s3.ToExamStudent(group2, "Математика");
            s5.ToExamStudent(group2, "Математика");
            WriteLine(s1);
            WriteLine(s3);
            WriteLine(s5);

            s1.DisplayExams();
            s3.DisplayExams();
            s5.DisplayExams();

            ReadLine();


        }
    }
}
