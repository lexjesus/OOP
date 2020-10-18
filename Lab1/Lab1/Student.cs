using System;
using System.Collections.Generic;

namespace proj
{
    class Student
    {
        private string firstName;
        private string secondName;
        private string thirdName;
        public byte grCount = 0;
        internal List<byte> marks = new List<byte>();

        public Student() : this("Unknown", "Unknown", "Unknown")
        { }
        public Student(string secondName, string firstName, string thirdName)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                secondName = value;
            }
        }

        public string ThirdName
        {
            get
            {
                return thirdName;
            }
            set
            {
                thirdName = value;
            }
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
        public override string ToString()
        {
            return $" Student {secondName} {firstName} {thirdName} studies in {grCount} groups.";
        }

    }

}