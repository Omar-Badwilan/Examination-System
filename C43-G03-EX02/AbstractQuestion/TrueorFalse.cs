using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G03_EX02.AbstractQuestion
{
    internal class TrueorFalse : Question
    {
        public TrueorFalse(string header, string body, int mark, List<Answer> answers, int rightAnswer) : base(header, body, mark, answers, rightAnswer)
        {
        }
        
    }
}
