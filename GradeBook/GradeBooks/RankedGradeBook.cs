using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int counter = 0;

            if (Students.Count < 5)
                throw new InvalidOperationException();

            foreach(Student s in Students)
            {
                if(s.AverageGrade > averageGrade)
                    counter++;

                else
                {
                    if ((counter / Students.Count) <= 0.2)
                        return 'A';
                    else if ((counter / Students.Count) <= 0.4)
                        return 'B';
                    else if ((counter / Students.Count) <= 0.6)
                        return 'C';
                    else if ((counter / Students.Count) <= 0.8)
                        return 'D';
                    else
                        return 'F';
                }
            }

            return ' ';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
