using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp16.Program;

namespace ConsoleApp16
{
    
        public enum EducationLevel
        {
            Elementary=0,
            Secondary=1,
            Higher=2
        }

    public class Program
    {
        public static bool FilterHonors(Student st)
        {
            return st.Performance == 5;
        }

        public static bool FilterLoser(School s)
        {
            foreach (var st in s.ListStudents)
                if (st.Performance < 3)
                    return true;
            return false;
        }

        static void Main(string[] args)
        {
            Student studA = new Student();
            Student studB = new Student();
            Student studAbaev = new Student("Абаев Георгий", 7, 3.4);
            Student studBagaev = new Student("Багаев Аслан", 4, 4);
            Console.WriteLine(studA);
            Console.WriteLine(studB);
            Console.WriteLine(studAbaev);
            Console.WriteLine(studBagaev);
            studBagaev.Pass();
            Console.WriteLine(studBagaev);

            School school = new School("ФизМат");
            Student stud5 = new Student("Абаев Георгий", 7, 5);
            school.Add(stud5);
            school.Add(studA);
            school.Add(studB);
            school.Add(studAbaev);
            school.Add(studBagaev);
            Console.WriteLine(school);


            var m = new Ministry();

            m.AddSchool(school);

            School school1 = new School("40 учеников");
            for (int i = 0; i < 40; i++)
            {
                Student student = new Student();
                school1.Add(student);
            }
            Student student5 = new Student("Дзбоева Залина", 8, 5);
            school1.Add(student5);
            m.AddSchool(school1);
            foreach (var e in m.Analyze())
            {
                Console.WriteLine(e);
            }
            foreach (var e in m.Analyze(FilterHonors))
            {
                Console.WriteLine(e);
            }

            foreach (var e in m.Analyze(FilterLoser))
            {
                Console.WriteLine(e.Name);
            }
        }
    }
}
