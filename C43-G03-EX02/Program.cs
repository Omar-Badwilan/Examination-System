using System.Collections.Generic;
using C43_G03_EX02.AbstractExam;
using C43_G03_EX02.AbstractQuestion;

namespace C43_G03_EX02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject OOP = new Subject() { SubjectId = 1, SubjectName = "C# Exam" };

            OOP.SubjectExam = OOP.CreateExam();

            OOP.SubjectExam.ShowExam();

        }
    }
}
