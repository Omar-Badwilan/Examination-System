using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G03_EX02
{
     class Answer : IComparable
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public int CompareTo(object? obj)
        {
            Answer? other =(Answer?)obj;

            return this.AnswerId.CompareTo(other?.AnswerId);
        }

        public static bool operator==(Answer a, Answer b)
        {
            return a.CompareTo(b) == 0;
        }   
        public static bool operator!=(Answer a, Answer b)
        {
            return a.CompareTo(b) != 0;
        }

        public override string ToString()
        {
            return String.Format("Choice {0,-2}: {1,-20} (AnswerId: {2})",(char)('a' + AnswerId - 1), AnswerText, AnswerId);
        }
    }
}
