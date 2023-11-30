using System.Diagnostics;
using Scheduler.Menu;

namespace Scheduler.Student;

public class Student
{
    private string Name { get; set; }
    private string Surname { get; set; }
    private int Course { get; set; }

    private Student(string name, string surname, int course)
    {
        Name = name;
        Surname = surname;
        Course = course;
    }
    
    public static Student Build()
    {
        var question = new Question();
        var name = question.Ask("Introduce el nombre del alumno: ");
        var surname = question.Ask("Introduce el apellido del alumno: ");
        var course = question.AskInt("Introduce el curso del alumno: ");
        return new Student(name, surname, course);
    }
    
    public static Process BuildProcess(string clientPath, Student student)
    {
        return new Process
        {
            StartInfo =
            {
                FileName = clientPath,
                Arguments = $"{student.Name} {student.Surname} {student.Course}"
            }
        };
    }
}