using System;
using System.Collections.Generic;

namespace proj
{
    public abstract class Student
    {
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public List<StudentGroup> groups = new List<StudentGroup>();
        public List<byte> marks = new List<byte>();
        public Dictionary<Exam, int> dictAtt = new Dictionary<Exam, int>();


        public Student() : this("Unknown", "Unknown", "Unknown")
        { }
        public Student(string secondName, string firstName, string thirdName)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
        }

        public float AverMarks
        {
            get
            {
                float sum = 0;
                for (int i = 0; i < marks.Count; i++)
                {
                    sum += marks[i];
                }
                float aver = sum / marks.Count;
                return aver;
            }
        }
        public void Display()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Name(FIO): {0} {1} {2}", secondName, firstName, thirdName);
            if (marks.Count == 0)
            {
                Console.WriteLine("MarksList is empty.");
            }
            else
            {
                foreach (byte m in marks)
                {
                    Console.Write("{0} ", m);
                }
                Console.WriteLine("");
                Console.WriteLine("Average mark: {0}", AverMarks);
            }
            Console.WriteLine("-------------------");
        }

        public void DisplayExams()
        {
            string exMrks = "";
            foreach (var g in groups)
            {
                exMrks += g.grName + ":\n";
                foreach (var i in g.exams)
                {
                    if (i.ExGetMark(this) != -1)
                    {
                        exMrks += i.name + ": " + i.ExGetMark(this) + "\n";
                    }
                    else
                    {
                        exMrks += i.name + ": " + "None" + "\n";
                    }
                }
                exMrks += "\n";
            }

            Console.WriteLine($"Student {secondName} {firstName} {thirdName}: \n{exMrks}");
        }
        public override string ToString()
        {
            string grps = "";
            foreach(var i in groups)
            {
                grps += " " + i.grName;
            }
            return $" Student {secondName} {firstName} {thirdName} studies in groups:{grps}.";
        }

        
    }

    public class Nerd : Student
    {
        public Nerd(string secondName, string firstName, string thirdName)
            : base(secondName, firstName, thirdName)
        { }
        public bool ToExamStudent(StudentGroup sg, string exName)
        {
            if (!sg.students.Contains(this) || !groups.Contains(sg))
            {
                return false;
            }
            Exam examen = sg.CreateUseExam(exName);
            if (!dictAtt.ContainsKey(examen))
            {
                dictAtt.Add(examen, 0);
            }
            examen.DoExam(4, 5, this);
            return true;
        }

    }

    public class UsualStudent : Student
    {
        public UsualStudent(string secondName, string firstName, string thirdName)
            : base(secondName, firstName, thirdName)
        { }
        public bool ToExamStudent(StudentGroup sg, string exName)
        {
            if (!sg.students.Contains(this) || !groups.Contains(sg))
            {
                return false;
            }
            Exam examen = sg.CreateUseExam(exName);
            if (!dictAtt.ContainsKey(examen))
            {
                dictAtt.Add(examen, 0);
            }
            if (examen.ExGetMark(this) > 2 && examen.ExGetMark(this) != -1)
            {
                return false;
            }
            if (dictAtt[examen] < examen.maxRetake)
            {
                examen.DoExam(2, 5, this);
            }
            else
            {
                return false;
            }
            return true;
        }
    }

    public class Council : UsualStudent
    {
        public Council(string secondName, string firstName, string thirdName)
            : base(secondName, firstName, thirdName)
        { }

        public new bool ToExamStudent(StudentGroup sg, string exName)
        {
            if (!sg.students.Contains(this) || !groups.Contains(sg))
            {
                return false;
            }
            Exam examen = sg.CreateUseExam(exName);
            if (!dictAtt.ContainsKey(examen))
            {
                dictAtt.Add(examen, 0);
            }
            if ((dictAtt[examen] + 1) == examen.maxRetake)
            {
                examen.DoExam(3, 3, this);
            }
            else
            {
                examen.DoExam(2, 5, this);
            }
            return true;
        }
    }

}