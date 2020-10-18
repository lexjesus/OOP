using System.Collections.Generic;
using System;
using System.Linq;
namespace proj
{
    class AddStudentException : Exception
    {
        public int Value { get; }
        public AddStudentException(string message, int val)
            : base(message)
        {
            Value = val;
        }
    }
    class StudentGroup
    {
        private List<Student> students = new List<Student>();
        private string grName { get; }
        private byte maxStCount;
        private byte stCount = 0;

        public StudentGroup(string grName) : this(grName, 25)
        { }

        public StudentGroup(string grName, byte maxStCount)
        {
            this.maxStCount = maxStCount;
            this.grName = grName;
        }

        public void AddStudent(Student newStudent)
        {
            if (stCount < maxStCount)
            {
                students.Add(newStudent);
                newStudent.grCount++;
                stCount++;
            }
            else
            {
                throw new Exception("The group is full as possible.");
            }
        }

        public void AddStudent(List<Student> newStudents)
        {
            for (int i = 0; i < newStudents.Count; i++)
            {
                if (stCount < maxStCount)
                {
                    students.Add(newStudents[i]);
                    newStudents[i].grCount++;
                    stCount++;
                }
                else
                {
                    throw new AddStudentException("The group is full as possible.", newStudents.Count - i);
                }
            }
        }

        public void RemoveStudent(Student s1)
        {
            var ind = students.IndexOf(s1);
            if (ind < 0)
            {
                throw new Exception("Student is not found.");
            }
            else
            {
                students.RemoveAt(ind);
                s1.grCount--;
                stCount--;
            }
        }

        public void DisplaySortedByName()
        {
            Console.WriteLine("Sorted-by-name----------------------------------------------------");
            var sortedByName = from s in students
                               orderby s.SecondName
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
            try
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if (String.Compare(students[i].SecondName, SName) == 0 &&
                        String.Compare(students[i].FirstName, FName) == 0 &&
                        String.Compare(students[i].ThirdName, TName) == 0)
                    {
                        students[i].Display();
                        return students[i];
                    }
                }
                throw new Exception("Student not found.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void AddMarks(string SName, string FName, string TName, List<int> m)
        {
            bool flag = false;
            for (int i = 0; i < students.Count; i++)
            {
                if (String.Compare(students[i].SecondName, SName) == 0 &&
                    String.Compare(students[i].FirstName, FName) == 0 &&
                    String.Compare(students[i].ThirdName, TName) == 0)
                {
                    for (int j = 0; j < m.Count; j++)
                    {
                        students[i].marks.Add((byte)m[j]);
                    }
                    flag = true;
                }
            }
            if (!flag)
            {
                throw new Exception("Student not found.");
            }
            else
            {
                Console.WriteLine("Marks added.\n");
            }
        }

        public void AddMarks(Student s, List<int> m)
        {
            bool flag = false;
            for (int i = 0; i < students.Count; i++)
            {
                if (String.Compare(students[i].SecondName, s.SecondName) == 0 &&
                    String.Compare(students[i].FirstName, s.FirstName) == 0 &&
                    String.Compare(students[i].ThirdName, s.ThirdName) == 0)
                {
                    for (int j = 0; j < m.Count; j++)
                    {
                        students[i].marks.Add((byte)m[j]);
                    }
                    flag = true;
                }
            }
            if (!flag)
            {
                throw new Exception("Student not found.");
            }
            else
            {
                Console.WriteLine("Marks added.\n");
            }
        }

        public override string ToString()
        {
            return $"{stCount} students in group.";
        }
    }
}