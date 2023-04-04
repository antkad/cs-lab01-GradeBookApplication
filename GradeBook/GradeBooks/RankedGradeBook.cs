using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int higherGrades = 0;

            foreach (var studentAvarageGrade in Students)
            {
                if (averageGrade < studentAvarageGrade.AverageGrade)
                {
                    higherGrades++;
                }
            }

            int top20 = (int)(Students.Count * 0.2f);

            if (higherGrades < top20)
            {
                return 'A';
            }
            else if ((higherGrades >= top20) && (higherGrades < top20 * 2))
            {
                return 'B';
            }
            else if ((higherGrades >= top20 * 2) && (higherGrades < top20 * 3))
            {
                return 'C';
            }
            else if ((higherGrades >= top20 * 3) && (higherGrades < top20 * 4))
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}