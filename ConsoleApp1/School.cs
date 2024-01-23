using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class School
    {
        public string Name { get; set; }
        public List<Student> ListStudents { get; set; }

        public School(string name)
        {
            Name = name;
            ListStudents = new List<Student>();
        }

        public void Add(Student student)
        {
            ListStudents.Add(student);
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < ListStudents.Count; i++)
            {
                result += $"{i + 1}. {ListStudents[i]}\n";
            }
            return result;
        }
    }
}
