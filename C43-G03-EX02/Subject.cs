using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C43_G03_EX02.AbstractExam;
using C43_G03_EX02.AbstractQuestion;

namespace C43_G03_EX02
{
    class Subject
    {
        #region Properties
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public Exam SubjectExam { get; set; }
        #endregion

        #region Methods
        public MCQ CreateMCQ(string header)
        {
            Console.WriteLine("MCQ Type");

            Console.WriteLine("Enter Question Body");
            string questionBody = Console.ReadLine();

            Console.WriteLine("Enter Question Mark");
            if (!int.TryParse(Console.ReadLine(), out int questionMark) || (questionMark < 0))
                Console.WriteLine("There is no -ve mark");

            Console.WriteLine("Enter Question Choices");

            List<Answer> answerQuestions = new List<Answer>();

            //Answers for the question
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine($"Please enter choice Number {j + 1}");

                string answerText = Console.ReadLine();

                answerQuestions.Add(new Answer
                {
                    AnswerId = j + 1,
                    AnswerText = answerText
                });
            }

            Console.WriteLine("Enter the rightAnswer id ");

            if (!int.TryParse(Console.ReadLine(), out int rightans) || (rightans < 1) || (rightans > 4))
                Console.WriteLine("Invalid answerid ");

            return new MCQ(header, questionBody, questionMark, answerQuestions, rightans);
        }

        public TrueorFalse CreateTF(string header)
        {
            Console.WriteLine("True | False Question");


            Console.WriteLine("Enter Question Body");
            string questionBody = Console.ReadLine();

            Console.WriteLine("Enter Question Mark");
            if (!int.TryParse(Console.ReadLine(), out int questionMark) || (questionMark < 0))
                Console.WriteLine("There is no -ve mark");

            List<Answer> answerQuestions = new List<Answer>{
                new Answer { AnswerId = 1, AnswerText = "True" },
                new Answer { AnswerId = 2, AnswerText = "False" }
            };

            Console.WriteLine("Please enter the right ans id (1 for true , 2 for false)");

            if (!int.TryParse(Console.ReadLine(), out int rightans) || (rightans != 1 && rightans != 2))
                Console.WriteLine("Invalid answerid ");

            return new TrueorFalse(header, questionBody, questionMark, answerQuestions, rightans);
        }

        public PracticalExam CreatePracticalExam(double examTime, int NumQuestions)
        {
            List<Question> allQuestions = new List<Question>();
            for (int i = 0; i < NumQuestions; i++)
            {
                Console.Clear();
                allQuestions.Add(CreateMCQ($"Q{i + 1}"));
            }
            PracticalExam practicalExam = new PracticalExam(examTime, NumQuestions, allQuestions);

            return practicalExam;
        }

        public FinalExam CreateFinalExam(double examTime, int NumQuestions)
        {
            List<Question> allQuestions = new List<Question>();
            for (int i = 0; i < NumQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine("Please Enter the Type Of Question (1 for MCQ | 2 for True or False)");

                if (!int.TryParse(Console.ReadLine(), out int questionChoice) || (questionChoice != 1 && questionChoice != 2))
                    Console.WriteLine("invalid question type.");

                //mcq
                if (questionChoice == 1)
                    allQuestions.Add(CreateMCQ($"Q{i + 1}"));
                //TF
                else if (questionChoice == 2)
                    allQuestions.Add(CreateTF($"Q{i + 1}"));
            }

            FinalExam finalExam = new FinalExam(examTime, NumQuestions, allQuestions);
            return finalExam;
        }

        public Exam CreateExam()
        {
            Console.WriteLine($"Please Enter the type of the Exam (1 for Practical | 2 for Final): ");
        againtype:
            if (!int.TryParse(Console.ReadLine(), out int examChoice) || (examChoice != 1 && examChoice != 2))
            {
                Console.WriteLine("invalid you only can choose 1 or 2");
                goto againtype;
            }

        againtime:
            Console.WriteLine($"Please Enter the time for the exam from (30 min to 180 min)");

            if (!double.TryParse(Console.ReadLine(), out double examTime) || (examTime < 30 || examTime > 180))
            {
                Console.WriteLine("invalid you should choose between 30 and 180");
                goto againtime;
            }

        againQuestion:
            Console.WriteLine($"Please Enter the Number of Questions)");
            if (!int.TryParse(Console.ReadLine(), out int NumQuestions) || (NumQuestions <= 0))
            {
                Console.WriteLine("number can't be negative try again!");
                goto againQuestion;
            }


            Exam exam = null;
            // 1 is Practical ( MCQ ) , 2  is Final ( MCQ , TF)
            switch (examChoice)
            {
                case 1:
                    exam = CreatePracticalExam(examTime, NumQuestions);
                    break;
                case 2:
                    exam = CreateFinalExam(examTime, NumQuestions);
                    break;
            }
            Console.Clear();
            return exam;
        } 
        #endregion
    }
}
