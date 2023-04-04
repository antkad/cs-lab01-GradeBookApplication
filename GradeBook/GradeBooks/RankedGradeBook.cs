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
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
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

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}