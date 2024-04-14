using Core0.Models;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace mini_consoleapp_class
{
    internal class Program
    {
      
        static Classroom[] classrooms=new Classroom[26];
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Sinif yarat");
                Console.WriteLine("2. Telebe yarat");
                Console.WriteLine("3. Butun Telebeleri ekrana cixart");
                Console.WriteLine("4. Secilmis sinifdeki telebeleri ekrana cixart");
                Console.WriteLine("5. Telebe sil");
                Console.WriteLine("6. Cixis");
                Console.Write("Seciminiz: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateClassroom();
                        break;
                    case "2":
                        CreateStudent();
                        break;
                    case "3":
                        DisplayAllStudents();
                        break;
                    case "4":
                        DisplayStudentsInClassroom();
                        break;
                    case "5":
                        DeleteStudent();
                        break;
                    case "6":
                        Console.WriteLine("Proqramnan chixdiniz");
                        return;
                    default:
                        Console.WriteLine("Yanlis secim.");
                        break;
                }
            }
        }

        private static void DeleteStudent()
        {
            Console.WriteLine("Silinecek telebenin ID-sini daxil edin:");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                throw new Exception("Duzgun ID daxil edin.");
            }

            foreach (Classroom classroom in classrooms)
            {
                if (classroom != null)
                {
                    try
                    {
                        classroom.Delete(studentId);
                        Console.WriteLine("Telebe silindi.");
                        return;
                    }
                    catch (StudentNotFoundException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            throw new Exception("Telebe tapilmadi.");

  
        }

        static void CreateClassroom()
        {
            Console.Write("Sinifin adi: ");
            string name = Console.ReadLine();

            if (!Helper.ClassNameCheck(name))
            {
                Console.WriteLine("Sinifin adi duzgun deyil.");
                return;
            }

            ClassroomType type;
            while (true)
            {
                Console.Write("Sinifin tipi (0 - Backend, 1 - Frontend): ");
                string typeInput = Console.ReadLine();
                if (typeInput == "0")
                {
                    type = ClassroomType.BackEnd;
                    break;
                }
                else if (typeInput == "1")
                {
                    type = ClassroomType.FrontEnd;
                    break;
                }
                else
                {
                    Console.WriteLine("Yanlis tip. 0 (Backend) ve ya 1 (Frontend) daxil edin.");
                }
               
            }
            int classroomIndex = Array.FindIndex(classrooms, c => c == null);
            classrooms[classroomIndex] = new Classroom(name, type);
            Console.WriteLine("Sinif yaradildi.");


        }

        static void CreateStudent()

        {
            if (classrooms.All(c => c == null))
            {
                Console.WriteLine("Heç bir sinif yaradilmayib.");
                return;
            }

            Console.Write("Ad: ");
            string name = Console.ReadLine();

            if (!name.NameCheck())
            {
                Console.WriteLine("Ad duzgun deyil.");
                return;
            }

            Console.Write("Soyad: ");
            string surname = Console.ReadLine();

            if (!surname.SurnameCheck())
            {
                Console.WriteLine("Soyad duzgun deyil.");
                return;
            }

            Console.Write("Sinifin adi: ");
            string className = Console.ReadLine();

            Classroom classroom = classrooms.FirstOrDefault(c => c?.Name == className);
            if (classroom == null)
            {
                Console.WriteLine("Qeyd olunan sinif tapilmadi");
                return;
            }

            try
            {
                classroom.StudentAdd(new Student(name, surname));
                Console.WriteLine("Telebe yaradildi.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static void DisplayAllStudents()
        {
            foreach (var classroom in classrooms)
            {
                if (classroom != null)
                {
                    foreach (var student in classroom.students)
                    {
                        if (student != null)
                        {
                            Console.WriteLine($"Id: {student.Id}, Ad: {student.Name}, Soyad: {student.SurName}, Sinif: {classroom.Name}");
                        }
                    }
                }
            }

        }
        

        static void DisplayStudentsInClassroom()
        {
            Console.Write("Sinifin adi: ");
            string className = Console.ReadLine();

            Classroom classroom = classrooms.FirstOrDefault(c => c.Name == className);
            if (classroom == null)
            {
                Console.WriteLine("Qey olunan adli sinif tapilmadi.");
                return;
            }

            foreach (var student in classroom.students)
            {
                if (student != null)
                {
                    Console.WriteLine($"Id: {student.Id}, Ad: {student.Name}, Soyad: {student.SurName}");
                }
            }
            
        }  
         
    }     
}


        
    

