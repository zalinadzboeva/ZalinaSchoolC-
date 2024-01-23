using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Ministry
    {
        public List<School> ListSchool { get; set; }

        public Ministry(List<School> schools)
        {
            ListSchool = schools;
        }
        public Ministry()
        {
            ListSchool = new List<School>();
        }
        public void AddSchool(School school)
        {
            ListSchool.Add(school);
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < ListSchool.Count; i++)
            {
                result += $"{i + 1}. {ListSchool[i].Name}\n{ListSchool[i]}\n";
                
            }
            return result;
        }
        public List<School> Analyze()
        {
            var res = new List<School>();
            foreach (var s in ListSchool)
                if (s.ListStudents.Count > 30)
                    res.Add(s);
            for (var i = 0; i < res.Count; i++)
                for (var j = 0; j < res.Count - 1; j++)
                    if (FindSum(res[j]) > FindSum(res[j + 1]))
                    {
                        var temp = res[j + 1];
                        res[j + 1] = res[j];
                        res[j] = temp;
                    }
            return res;
        }

        public List<Student> Analyze(Func<Student, bool> selector)
        {
            var res = new List<Student>();
            foreach (var s in ListSchool)
                foreach (var st in s.ListStudents)
                    if (selector(st))
                        res.Add(st);
            return res;
        }

        public List<School> Analyze(Func<School, bool> selector)
        {
            var resLinq = ListSchool
                .Where(selector)
                .ToList();
            return resLinq;
        }

        private int FindSum(School school)
        {
            int sum = 0;
            foreach (var st in school.ListStudents)
                sum += st.Grade;
            return sum;
        }
    }
}
