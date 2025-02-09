using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G03_EX02.AbstractQuestion
{
     abstract class Question 
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }

        public List<Answer> Answers { get; set; }     

        public int RightAnswer { get; set; }


        public Question(string header, string body, int mark , List<Answer> answers , int rightAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = answers;
            RightAnswer = rightAnswer;
        }


        public Answer? searchByid(int id)
        {
            foreach (Answer answer in Answers)
            {
                if (answer.AnswerId == id)
                {
                    return answer;
                }
            }
            return null;
        }
    }
}
