using ConsoleApp16;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Student
    {
        public string FIO { get; set; }
        public int Grade { get; set; }
        public double Performance { get; set; }
        public EducationLevel Stage;
        private static int counter = 0;

        public Student()
        {
            FIO = Convert.ToChar('A' + counter % 26).ToString();
            Grade = new Random().Next(1, 12);
            Performance = new Random().Next(0, 3);
            Stages();
            counter = counter + 1;

        }

        public Student(string fio, int grade, double performance)
        {
            FIO = fio;
            Grade = grade;
            Performance = performance;
            Stages();
        }
        public EducationLevel Stages(){
            if (Grade <= 4)
            {
                Stage = EducationLevel.Elementary;
            }
            else if (Grade <= 8)
            {
                Stage = EducationLevel.Secondary;
            }
            else
            {
                Stage = EducationLevel.Higher;
            }
            return Stage;
        }

        public void Pass()
        {
            if (Grade < 11)
            {
                Grade++;
                Stages();
            }
        }
        public override string ToString()
        {
            string stage = "";
            if (EducationLevel.Elementary == Stage)
            {
                stage = "младшая";
            }
            else if (EducationLevel.Secondary == Stage)
            {
                stage = "средняя ";
            }
            else
            {
                stage = "старшая ";
            }
            return $"{FIO}, {stage} школа, {Grade} класс, {Performance} балла";
        }
    }
}
