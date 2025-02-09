using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C43_G03_EX02.AbstractQuestion;

namespace C43_G03_EX02.AbstractExam
{
    internal class FinalExam : Exam
    {
        public FinalExam(double Time, int NumberofQuestions , List<Question>questions) : base(Time, NumberofQuestions,questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("Do you Want to Start the exam ? Y:N");
            char start = Console.ReadKey().KeyChar;
            Console.Clear();
            Console.WriteLine();
            switch (start)
            {
                case 'Y':
                case 'y':
                    //------solve
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    stopwatch.Start();

                    List<Answer> userAns = new List<Answer>();
                    int totalmark = 0;

                    //start 
                    foreach (Question q in Questions)
                    {
                    solve:
                        Console.WriteLine($"{q.Header} - {q.Body} - ({q.Mark} Marks)");

                        //display Answers
                        foreach (Answer a in q.Answers)
                            Console.WriteLine(a);

                        Console.WriteLine("write AnswerId [1]");
                        Console.WriteLine("----------------------------------------");
                        if (!int.TryParse(Console.ReadLine(), out int answerID) || (answerID < 1 || answerID > 4))
                        {
                            Console.WriteLine("Please Try again invalid id");
                            goto solve;
                        }
                        
                        totalmark += q.Mark;
                        if (stopwatch.Elapsed.TotalMinutes >= Time)
                        {
                            Console.WriteLine("Time finished exam canceled!");
                            break;
                        }
                        //add user's answer by searching with id 
                        userAns.Add(q.searchByid(answerID));
                    }
                    
                    //stop
                    stopwatch.Stop();
                    TimeSpan elapsedTime = stopwatch.Elapsed;

                    //-------grading
                    Console.Clear();
                    int mark = 0;
                    for (int i = 0; i < NumberofQuestions; i++)
                    {
                        Console.WriteLine($"{Questions[i].Header} : {Questions[i].Body} - ({Questions[i].Mark} Marks)");

                        Console.WriteLine($"Your Answer : {userAns[i].AnswerText} ");

                        Answer correctAnswer = Questions[i].searchByid(Questions[i].RightAnswer);


                        Console.WriteLine($"Correct Ans : {correctAnswer?.AnswerText} ");
                        Console.WriteLine("----------------------------------------");
                        if (userAns[i].AnswerId == Questions[i].RightAnswer)
                            mark += Questions[i].Mark;
                    }
                    Console.WriteLine($"Your Grade is {mark} from {totalmark}");

                    Console.WriteLine($"Time = {elapsedTime.Minutes} min {elapsedTime.Seconds} sec");

                    break;
                case 'N':
                    return;
            }
        }
    }
}
