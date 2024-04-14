using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core0.Models
{
    public class Student
    {
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public Student(string name,string surname)
        {
           Id = ++_id;
            Name=name;
            SurName = surname;
        }

    }
}
