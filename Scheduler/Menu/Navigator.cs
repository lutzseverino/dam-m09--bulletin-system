using System.Diagnostics;

namespace Scheduler.Menu;

public class Navigator
{
    private const string ClientPath = "../../../../Client/bin/Debug/net7.0/Client";

    private readonly List<Student.Student> _students = new();
    private readonly List<Process> _processes = new();
    private readonly Scheduler _scheduler = new();

    public void Show()
    {
        var exit = false;

        while (!exit)
        {
            var question = new Question();

            var option = question.AskInt("\n¿Qué quieres hacer?\n" +
                                         "\t1. Añadir alumnos\n" +
                                         "\t2. Generar buletínes de " + $"{_students.Count} alumno/s\n" +
                                         "\t3. Salir\n" +
                                         "> ",
                i => i is >= 1 and <= 3);

            Console.WriteLine();

            switch (option)
            {
                case 1:
                    var finalClientPath = ClientPath;

                    if (Environment.OSVersion.Platform == PlatformID.Win32NT ||
                        Environment.OSVersion.Platform == PlatformID.Win32Windows)
                    {
                        finalClientPath = ClientPath + ".exe";
                    }

                    _students.Add(Student.Student.Build());
                    _processes.Add(Student.Student.BuildProcess(finalClientPath, _students.Last()));
                    break;
                case 2:
                    if (_students.Count > 0)
                        _scheduler.Run(_processes).Wait();
                    else
                        Console.WriteLine("No hay alumnos registrados.");
                    break;
                case 3:
                    exit = true;
                    break;
            }
        }
    }
}