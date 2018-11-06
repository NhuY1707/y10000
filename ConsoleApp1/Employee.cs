using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm2016
{
    [Serializable]
    public class Employee
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Skill { get; set; }
        public Company HomeBase { get; set; }
        public Employee Manager { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} ({2})", FullName, Skill, Salary);
        }
        public Employee(int id,string fullname,string skill,double sal,Employee mn,Company com )
        {
            ID = id;
            FullName = fullname;
            Skill = skill;
            Salary = sal;
            HomeBase = com;
            Manager = mn;
            
        }
      
    }
}
