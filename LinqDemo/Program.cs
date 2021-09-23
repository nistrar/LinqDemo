using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityManager um = new UniversityManager();

            um.MaleStudents();
            um.FemaleStudents();
            um.SortStudentsByAge();
            um.AllStudentsFromBeijing();
            int id;
            int.TryParse(Console.ReadLine(), out id);

            um.AllStundentsFromUniversityID(id);

            um.StudentAndUniversityNameCollection();

            Console.ReadKey();
        }

        static void OddNumbers(int[] numbers)
        {
            Console.WriteLine("Ungerade Zahlen");

            IEnumerable<int> oddNumbers = from number in numbers where number % 2 != 0 select number;

            foreach (int i in oddNumbers)
            {
                Console.WriteLine(i);
            }
            
            Console.ReadKey();
        }

        class UniversityManager
        {
            public List<University> universities;
            public List<Student> students;

            //Constructor
            public UniversityManager()
            {
                //Init
                universities = new List<University>();
                students = new List<Student>();

                //Fill
                universities.Add(new University { Id = 1, Name = "Yale" });
                universities.Add(new University { Id = 2, Name = "Beijing" });

                students.Add(new Student { Id = 1, Name = "Carla", Gender = "Female", Age = 17, UniversityId = 1 });
                students.Add(new Student { Id = 2, Name = "Tony", Gender = "Male", Age = 21, UniversityId = 1 });

                students.Add(new Student { Id = 3, Name = "Lejla", Gender = "Female", Age = 18, UniversityId = 2 });
                students.Add(new Student { Id = 4, Name = "James", Gender = "Male", Age = 22, UniversityId = 2 });
                students.Add(new Student { Id = 5, Name = "Linda", Gender = "Female", Age = 26, UniversityId = 2 });
                students.Add(new Student { Id = 6, Name = "Michael", Gender = "Male", Age = 22, UniversityId = 1 });
            }

            public void SortStudentsByAge()
            {
                var sortedStudents = from student in students orderby student.Age select student;

                Console.WriteLine("Sorted Student by Age");

                foreach (Student student in sortedStudents)
                {
                    student.Print();
                }
            }

            public void AllStudentsFromBeijing()
            {
                IEnumerable<Student> beijingStudents = from student in students
                                                       join university in universities on student.UniversityId
                                                       equals university.Id
                                                       where university.Name == "Beijing"
                                                       select student;

                Console.WriteLine("Students from Beijing:");

                foreach (Student student in beijingStudents)
                {
                    student.Print();
                }
            }

            public void AllStundentsFromUniversityID(int id)
            {
                IEnumerable<Student> beijingStudents = from student in students
                                                       join university in universities on student.UniversityId
                                                       equals university.Id
                                                       where university.Id == id
                                                       select student;

                Console.WriteLine("Students from Beijing:");

                foreach (Student student in beijingStudents)
                {
                    student.Print();
                }
            }

            public void StudentAndUniversityNameCollection()
            {
                var newCollection = from student in students
                                    join university in universities on student.UniversityId equals university.Id
                                    orderby student.Name
                                    select new { StudentName = student.Name, UniversityName = university.Name };
                Console.WriteLine("New Collection");

                foreach (var coll in newCollection)
                {
                    Console.WriteLine(coll.StudentName + " " + coll.UniversityName);
                }
            }

            public void MaleStudents()
            {
                IEnumerable<Student> maleStudents = from student in students where student.Gender == "Male" select student;

                Console.WriteLine("Male Students");

                foreach (Student student in maleStudents)
                {
                    Console.WriteLine(student.Name);
                }
            }

            public void FemaleStudents()
            {
                IEnumerable<Student> femaleStudents = from student in students where student.Gender == "Female" select student;

                Console.WriteLine("Female Students");

                foreach (Student student in femaleStudents)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }

        class University
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public void Print()
            {
                Console.WriteLine("Universität {0} mit der ID {1}", Name, Id);
            }
        }

        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public int UniversityId { get; set; }

            public void Print()
            {
                Console.WriteLine("Student {0} mit der ID {1}, dem Geschlecht {2} und Alter {3} und Universität ID {4}",Name, Id, Gender, Age, UniversityId);
            }

        }
    }
}
