using System.Collections.Generic;
using System;
using System.Linq;
namespace proj
{
    public class StudentGroup
    {
        public List<Student> students = new List<Student>();
        public List<Exam> exams = new List<Exam>();

        public string grName;
        private byte maxStCount;

        public StudentGroup(string grName) : this(grName, 25)
        { }

        public StudentGroup(string grName, byte maxStCount)
        {
            this.maxStCount = maxStCount;
            this.grName = grName;
        }


        public int AddStudent(Student s1)
        {
            if (students.Count < maxStCount)
            {
                students.Add(s1);
                s1.groups.Add(this);
            }
            else
            {
                return 1;
            }
            return 0;
        }

        public int RemoveStudent(Student s1)
        {
            var rem1 = students.Remove(s1);
            var rem2 = s1.groups.Remove(this);
            if (!rem1 || !rem2)
            {
                return 1;
            }
            return 0;
        }

        public void DisplaySortedByName()
        {
            Console.WriteLine("Sorted-by-name----------------------------------------------------");
            var sortedByName = from s in students
                               orderby s.secondName
                               select s;
            Console.WriteLine("Group {0}:", grName);
            foreach (Student s in sortedByName)
            {
                s.Display();
            }
            Console.WriteLine("------------------------------------------------------------------\n");
        }

        public void DisplaySortedByMarks()
        {
            Console.WriteLine("Sorted-by-marks---------------------------------------------------");

            var sortedByMarks = from s in students
                                orderby s.AverMarks descending
                                select s;
            Console.WriteLine("Group {0}:", grName);
            foreach (Student s in sortedByMarks)
            {
                s.Display();
            }
            Console.WriteLine("------------------------------------------------------------------\n");
        }

        public Student GetStudent(string SName, string FName, string TName)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (String.Compare(students[i].secondName, SName) == 0 &&
                    String.Compare(students[i].firstName, FName) == 0 &&
                    String.Compare(students[i].thirdName, TName) == 0)
                {
                    students[i].Display();
                    return students[i];
                }
            }
            return null;
        }

        public int AddMarks(Student s, List<int> m)
        {
            Student st = GetStudent(s.secondName, s.firstName, s.thirdName);
            if (st == null)
            {
                return 1;
            }

            for (int j = 0; j < m.Count; j++)
            {
                st.marks.Add((byte)m[j]);
            }
            return 0;
        }

        public override string ToString()
        {
            return $"{students.Count} students in group.";
        }

        public Exam CreateUseExam(string name)
        {
            foreach (Exam e in exams)
            {
                if (e.name == name)
                {
                    return e;
                }
            }
            Exam ex = new Exam(name, this);
            exams.Add(ex);
            return ex;
        }
    }
        public class Exam
        {
            public string name;
            public int maxRetake = 3;
            public StudentGroup gr;
            public Dictionary<Student, byte> dictMarks = new Dictionary<Student, byte>();
            
            public int ExGetMark(Student st)
            {
                if (dictMarks.ContainsKey(st))
                {
                     return (int)dictMarks[st];
                }
                else return -1;
            }
            public Exam(string name, StudentGroup gr)
            {
                this.name = name;
                this.gr = gr;
            }

            public bool DoExam(int min, int max, Student st)
            {
                if (!gr.students.Contains(st))
                {
                    return false;       
                }
                int mark;
                st.dictAtt[this]++;
                Random r = new Random();
                mark = r.Next(min, max + 1);
                if (dictMarks.ContainsKey(st))
                {
                    dictMarks[st] = (byte)mark;
                }
                else
                {
                    dictMarks.Add(st, (byte)mark);
                }
                return true;
            }
        }

    
    
}