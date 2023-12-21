using Labb2_databaser.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Labb2_databaser
{
    public class Program
    {
        static void Main(string[] args)
        {
            using SchoolSystemContext dBContext = new SchoolSystemContext();

            string[] Menu = { "See all employees", "See all students", "See all classes and their students", "See all courses and average grades", "See all grades from december month", "Add new students", "Add new employees", "End program" };

            Console.WriteLine("NAVIGATION MENU");
            Console.WriteLine("~ALL SEVEN OPTIONS~");

            int i = 1;
            foreach (string option in Menu)
            {
                Console.WriteLine($"{i}. {option}");
                i++;
            }
            
            Console.Write("Enter your chosen number between 1 - 8 here: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    
                    Console.WriteLine($"{Menu[0]}");
                    
                    Console.WriteLine("Employee selction");
                    string[] employeeArray = { "See all employees", "See all teachers", "See principal", "See vice principal", "See admin", "See Nurse", "See janitors", "See librarian", "See cafeteria staff", "See career counselor", "See school counselors" };

                    int x = 1;
                    foreach (string employeeChoice in employeeArray)
                    {
                        Console.WriteLine($"{x}.{employeeChoice}");
                        x++;
                    }

                    Console.Write("Enter your chosen number: ");
                    string input = Console.ReadLine();
     
                    switch (input)
                    {
                        case "1":

                            Console.Clear();

                            Console.WriteLine("All employees");

                            var allEmployees = dBContext.Employees.ToList();

                            foreach (var Employee in allEmployees)
                            {
                                Console.WriteLine($"Name: {Employee.FirstName} {Employee.LastName} Personal number: {Employee.PersonalNumber} Role: {Employee.FkroleId}");
                            }
                            break;  

                        case "2":
                            
                            Console.Clear();

                            Console.WriteLine("All teachers");

                            var teachers = (from Employee in dBContext.Employees
                                            where Employee.FkroleId == 3
                                            select Employee).ToList();

                            foreach (var teacher in teachers)
                            {
                                Console.WriteLine($"Name: {teacher.FirstName} {teacher.LastName} Personal number: {teacher.PersonalNumber}");
                            }

                            break;

                        case "3":

                            Console.Clear();

                            Console.WriteLine("Principal");

                            var principalRole = (from Employee in dBContext.Employees
                                             where Employee.FkroleId == 1
                                             select Employee).ToList();

                            foreach (var principal in principalRole)
                            {
                                Console.WriteLine($"Name: {principal.FirstName} {principal.LastName} Personal number: {principal.PersonalNumber}");
                            }

                            break;

                        case "4":

                            Console.Clear();

                            Console.WriteLine("Vice principal");

                            var vicePrincipalRole = (from Employee in dBContext.Employees
                                                 where Employee.FkroleId == 2
                                                 select Employee).ToList();

                            foreach (var vicePrincipal in vicePrincipalRole)
                            {
                                Console.WriteLine($"Name: {vicePrincipal.FirstName} {vicePrincipal.LastName} Personal number: {vicePrincipal.PersonalNumber}");
                            }

                            break;

                        case "5":

                            Console.Clear();

                            Console.WriteLine("Admin");

                            var adminRole = (from Employee in dBContext.Employees
                                                     where Employee.FkroleId == 4
                                                     select Employee).ToList();

                            foreach (var admin in adminRole)
                            {
                                Console.WriteLine($"Name: {admin.FirstName} {admin.LastName} Personal number: {admin.PersonalNumber}");
                            }

                            break;

                        case "6":

                            Console.Clear();

                            Console.WriteLine("Nurse");

                            var nurseRole = (from Employee in dBContext.Employees
                                             where Employee.FkroleId == 5
                                             select Employee).ToList();

                            foreach (var nurse in nurseRole)
                            {
                                Console.WriteLine($"Name: {nurse.FirstName} {nurse.LastName} Personal number: {nurse.PersonalNumber}");
                            }

                            break;

                        case "7":

                            Console.Clear();

                            Console.WriteLine("Janitor");

                            var janitorRole = (from Employee in dBContext.Employees
                                             where Employee.FkroleId == 6
                                             select Employee).ToList();

                            foreach (var janitor in janitorRole)
                            {
                                Console.WriteLine($"Name: {janitor.FirstName} {janitor.LastName} Personal number: {janitor.PersonalNumber}");
                            }

                            break;

                        case "8":

                            Console.Clear();

                            Console.WriteLine("Librarian");

                            var librarianRole = (from Employee in dBContext.Employees
                                               where Employee.FkroleId == 7
                                               select Employee).ToList();

                            foreach (var librarian in librarianRole)
                            {
                                Console.WriteLine($"Name: {librarian.FirstName} {librarian.LastName} Personal number: {librarian.PersonalNumber}");
                            }

                            break;

                        case "9":

                            Console.Clear();

                            Console.WriteLine("Cafeteria staff");

                            var cafeteriaRole = (from Employee in dBContext.Employees
                                                 where Employee.FkroleId == 8
                                                 select Employee).ToList();

                            foreach (var cafeteriaStaff in cafeteriaRole)
                            {
                                Console.WriteLine($"Name: {cafeteriaStaff.FirstName} {cafeteriaStaff.LastName} Personal number: {cafeteriaStaff.PersonalNumber}");
                            }

                            break;

                        case "10":

                            Console.Clear();

                            Console.WriteLine("Career counselor");

                            var ccRole = (from Employee in dBContext.Employees
                                                 where Employee.FkroleId == 9
                                                 select Employee).ToList();

                            foreach (var cc in ccRole)
                            {
                                Console.WriteLine($"{cc.FirstName} {cc.LastName}, {cc.PersonalNumber}");
                            }

                            break;

                        case "11":

                            Console.Clear();

                            Console.WriteLine("School counselor");

                            var scRole = (from Employee in dBContext.Employees
                                                 where Employee.FkroleId == 10
                                                 select Employee).ToList();

                            foreach (var sc in scRole)
                            {
                                Console.WriteLine($"{sc.FirstName} {sc.LastName}, {sc.PersonalNumber}");
                            }

                            break;
                    }

                    break;

                case "2":
                    
                    Console.Clear();

                    var students = dBContext.Students.ToList();
                    Console.WriteLine($"{Menu[1]}");

                    Console.WriteLine("Choose sorting option:");

                    string[] studentsMenuOptions = { "Students sorted by first name in an ascending order (A - Z)", "Students sorted by first name in a descending order (Z - A)", "Students sorted by last name in an ascending order (A - Z)", "Students sorted by last name in a descending order (Z - A)" };
                    int y = 1;
                    foreach (string menuOptions in studentsMenuOptions)
                    {
                        Console.WriteLine($"{y}. {menuOptions}");
                        y++;
                    }

                    string sortOption = Console.ReadLine();
                    switch (sortOption)
                    {
                        case "1":
                            students = dBContext.Students.OrderBy(s => s.FirstName).ToList();
                            break;
                        case "2":
                            students = dBContext.Students.OrderByDescending(s => s.FirstName).ToList();
                            break;
                        case "3":
                            students = dBContext.Students.OrderBy(s => s.LastName).ToList();
                            break;
                        case "4":
                            students = dBContext.Students.OrderByDescending(s => s.LastName).ToList();
                            break;
                        default:
                            Console.WriteLine("Invalid option selected.");
                            students = dBContext.Students.ToList(); 
                            break;
                    }

                    if (sortOption == "1" || sortOption == "2")
                    {
                        foreach (var student in students)
                        {
                            Console.WriteLine($"{student.FirstName} {student.LastName}");
                        }
                    }

                    else if (sortOption == "3" || sortOption == "4")
                    {
                        foreach (var student in students)
                        {
                            Console.WriteLine($"{student.LastName} {student.FirstName}");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Error: invalid choice.");
                    }
                    
                    break;

                case "3":
                    
                    Console.Clear();

                    Console.WriteLine($"{Menu[2]}");

                    var classesList = (from cls in dBContext.Classes
                                       select cls).ToList();

                    Console.WriteLine("List of all classes:");
                    foreach (var cls in classesList)
                    {
                        Console.WriteLine($"{cls.ClassName}");
                    }

                    Console.Write("Choose a class: ");
                    if (!int.TryParse(Console.ReadLine(), out int classChoice) || classChoice < 1 || classChoice > classesList.Count)
                    {
                        Console.WriteLine("Invalid choice.");
                        break;
                    }

                    // Get selected class
                    var selectedClass = classesList[classChoice - 1];
                    
                    var studentsInSelectedClass = (from student in dBContext.Students
                                                   where student.FkclassId == selectedClass.ClassId
                                                   select student).ToList();

                    // Printing out students in chosen class
                    Console.WriteLine($"{selectedClass.ClassName}:");
                    foreach (var student in studentsInSelectedClass)
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName}");
                    }

                    break;

                case "4":

                    Console.Clear();

                    Console.WriteLine($"{Menu[3]}");

                    var coursesAndGrades = (
                        from enrollment in dBContext.Enrollments
                        group enrollment by enrollment.CourseId into courseGrades
                        select new
                        {
                            CourseId = courseGrades.Key,
                            AverageGrade = courseGrades.Average(e => e.GradeInfo),
                            HighestGrade = courseGrades.Max(e => e.GradeInfo),
                            LowestGrade = courseGrades.Min(e => e.GradeInfo)
                        }
                      ).ToList();

                    Console.WriteLine("\nList of all classes:");

                    foreach (var course in coursesAndGrades)
                    {
                        Console.WriteLine($"CourseID: {course.CourseId}  Highest course grade: {course.HighestGrade}   Lowest course grade: {course.LowestGrade}   Average course grade: {course.AverageGrade}");
                    }

                    break;

                case "5":

                    Console.Clear();

                    Console.WriteLine($"{Menu[4]}");

                    DateTime startDate = new DateTime(2023, 11, 30);
                    DateTime endDate = new DateTime(2023, 12, 30);
                    
                    var gradesFromDecemberMonth = (
                        from enrollment in dBContext.Enrollments
                        where enrollment.DateOfGrade >= startDate && enrollment.DateOfGrade <= endDate
                        join course in dBContext.Courses on enrollment.CourseId equals course.CourseId
                        join student in dBContext.Students on enrollment.StudentId equals student.StudentId
                        select new
                        {
                            enrollment.StudentId,
                            enrollment.CourseId,
                            course.CourseName,
                            enrollment.GradeInfo,
                            enrollment.DateOfGrade
                        }
                    ).ToList();

                    Console.WriteLine("Grades from december month");
                    foreach (var grade in gradesFromDecemberMonth)
                    {
                        Console.WriteLine($"COURSE-ID: {grade.CourseId} GRADE:{grade.GradeInfo}  DATE: {grade.DateOfGrade} STUDENT-ID: {grade.StudentId} NAME OF COURSE: {grade.CourseName}");
                    }

                    break;

                case "6":
                    Console.Clear();

                    Console.WriteLine($"{Menu[5]}");

                    Console.WriteLine("Enter StudentID: ");
                    string studentId = Console.ReadLine();
                    Console.WriteLine("Enter first name of new student: ");
                    string _firstName = Console.ReadLine();
                    Console.WriteLine("Enter last name of new student: ");
                    string _lastName = Console.ReadLine();
                    Console.WriteLine("Enter gender of new student: ");
                    string gender = Console.ReadLine();
                    Console.WriteLine("Enter personal number of new employee (It should be written as such: YYYY-MM.DD): ");
                    string _personalNumber = Console.ReadLine();
                    Console.WriteLine("Enter eventual health infomation about new student. If nothing special, enter 'None': ");
                    string healthInfo = Console.ReadLine();
                    Console.WriteLine("Enter ClassID of new student: ");
                    int classId = Convert.ToInt32(Console.ReadLine());

                    Student newStudent = new Student()
                    {
                        StudentId = studentId,
                        FirstName = _firstName,
                        LastName = _lastName,
                        Gender = gender,
                        PersonalNumber = _personalNumber,
                        HealthInfo = healthInfo,
                        FkclassId = classId
                    };

                    dBContext.Students.Add(newStudent);
                    dBContext.SaveChanges();
                     
                    break;

                case "7":
                    Console.Clear();

                    Console.WriteLine($"{Menu[6]}");

                    Console.WriteLine("Enter EmployeeID: ");
                    int employeeId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter first name of new employee: ");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter last name of new employee: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter personal number of new employee (It should be written as such: YYYY-MM.DD): ");
                    string personalNumber = Console.ReadLine();
                    Console.WriteLine("Enter role of new employee: ");
                    int fkRoleId = Convert.ToInt32(Console.ReadLine());

                    Employee newEmployee = new Employee()
                    {
                        EmployeesId = employeeId,
                        FirstName = firstName,
                        LastName = lastName,
                        PersonalNumber = personalNumber,
                        FkroleId = fkRoleId
                    };

                    dBContext.Employees.Add(newEmployee);
                    dBContext.SaveChanges();
                    break;

                case "8":
                    Console.Clear();

                    Console.WriteLine($"{Menu[7]}");

                    Console.WriteLine("Enter 'exit' to exit program");
                    string endProgramInput = Console.ReadLine();

                    if (endProgramInput.ToLower() == "exit")
                    {
                        Environment.Exit(0);
                    }
                    break;
            }
        }
    }
}
