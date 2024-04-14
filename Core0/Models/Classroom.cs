using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core0.Models
{
    public class Classroom
    {
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
       public ClassroomType Type { get; set; }
        public int Capacity { get;  set; }

        public Student[] students;
        private ClassroomType _classType;

        public Classroom(string name,ClassroomType type)
        {
            Id = ++_id;
            students = new Student[] { };
            Name = name;
          Type = type;
        Capacity = type == ClassroomType.BackEnd ? 20 : 15;
            students = new Student[Capacity];
            
        }

        public Classroom(ClassroomType classType)
        {
            this._classType = classType;
        }

        public void StudentAdd(Student student)
        {
            Array.Resize(ref students, students.Length + 1);
            students[students.Length - 1] = student;
        }



        public Student FindId(int id)
        {

            foreach (Student std in students)
            {
                if (std.Id == id)
                {
                    return std;
                }
            }
            throw new StudentNotFoundException("Student not found.");

        }
        public Student[] DisplayStudentsInClassroom()
        {
            return students;
        }
        public void Delete(int id)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null && students[i].Id == id)
                {
                    students[i] = null;
                    return;
                }
            }
            throw new StudentNotFoundException("Telebe tapilmadi.");
        }

    }
}
