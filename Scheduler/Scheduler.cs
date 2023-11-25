using System.Diagnostics;

namespace Scheduler;

public class Scheduler
{
    private class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Course { get; set; }

        public Student(string name, string surname, int course)
        {
            Name = name;
            Surname = surname;
            Course = course;
        }
    }

    private readonly Process _process = new()
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "../../../../Client/bin/Debug/net7.0/Client.exe",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        }
    };
    private readonly List<Student> _students = new();
    private readonly Queue<Student> _bulletinQueue = new();
    private const int MaxBulletins = 3;

    public void RunScheduler()
    {
        int option;
        do
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Introducir datos de alumnos");
            Console.WriteLine("2. Crear notas");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)
            {
                Console.WriteLine("Por favor, ingrese una opción válida (1-3).");
                Console.Write("Seleccione una opción: ");
            }

            switch (option)
            {
                case 1:
                    EnterStudentData();
                    break;
                case 2:
                    CreateBulletins();
                    break;
                case 3:
                    Console.WriteLine("¡Chao!");
                    break;
            }
        } while (option != 3);
    }

    private void EnterStudentData()
    {
        Console.Write("Ingrese el número de alumnos: ");
        int amount;
        while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Por favor, ingrese un número válido de alumnos mayor que 0.");
            Console.Write("Ingrese el número de alumnos: ");
        }

        for (int i = 1; i <= amount; i++)
        {
            Console.WriteLine($"Introduce los datos del alumno {i}:");
            Console.Write("Nombre: ");
            var name = Console.ReadLine();

            Console.Write("Apellido: ");
            var surname = Console.ReadLine();

            Console.Write("Curso: ");
            if (int.TryParse(Console.ReadLine(), out int curso))
            {
                _students.Add(new Student(name, surname, curso));
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, introduce un valor numérico.");
            }
        }
    }

    private void CreateBulletins()
    {
        if (_students.Count > 0)
        {
            Console.WriteLine($"A continuación se crearán los {_students.Count} alumnos:");

            _bulletinQueue.Clear();

            foreach (var student in _students)
            {
                _bulletinQueue.Enqueue(student);
            }

            while (_bulletinQueue.Count > 0)
            {
                for (int i = 0; i < Math.Min(MaxBulletins, _bulletinQueue.Count); i++)
                {
                    var currentStudent = _bulletinQueue.Dequeue();
                    _process.StartInfo.Arguments =
                        $"{currentStudent.Name} {currentStudent.Surname} {currentStudent.Course}";
                    _process.Start();
                }

                Thread.Sleep(5000);
            }
        }
        else
        {
            Console.WriteLine("Primero debes introducir alumnos");
        }
    }
}