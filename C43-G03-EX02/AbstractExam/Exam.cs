using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C43_G03_EX02.AbstractQuestion;

namespace C43_G03_EX02.AbstractExam
{
    abstract class Exam
    {
        public double Time { get; set; }

        public int NumberofQuestions { get; set; }

        public List<Question> Questions { get; set; }

        public Exam(double Time , int NumberofQuestions , List<Question>questions) 
        { 
            this.Time = Time;
            this.NumberofQuestions = NumberofQuestions;
            this.Questions = questions;
        }

        public abstract void ShowExam();




    }
}
