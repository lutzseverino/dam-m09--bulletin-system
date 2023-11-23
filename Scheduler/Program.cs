using System.Diagnostics;
using static Scheduler;


    class Scheduler
    {
    public class Alumno
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Curso { get; set; }

        public Alumno(string nombre, string apellido, int curso)
        {
            Nombre = nombre;
            Apellido = apellido;
            Curso = curso;
        }
    }
    static void Main(string[] args)
        {
            Process P = new Process();
            P.StartInfo.FileName = @"../../../../Client/bin/Debug/net7.0/Client.exe";

            int numeroAlumnos = 0;
            List<Alumno> listaAlumnos = new List<Alumno>();

            int opcion;
            do
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Introducir datos de alumnos");
                Console.WriteLine("2. Crear notas");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3)
                {
                    Console.WriteLine("Por favor, ingrese una opción válida (1-3).");
                    Console.Write("Seleccione una opción: ");
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el número de alumnos: ");
                        while (!int.TryParse(Console.ReadLine(), out numeroAlumnos) || numeroAlumnos <= 0)
                        {
                            Console.WriteLine("Por favor, ingrese un número válido de alumnos mayor que 0.");
                            Console.Write("Ingrese el número de alumnos: ");
                        }
                        for (int i = 1; i <= numeroAlumnos; i++)
                        {
                            Console.WriteLine($"Introduce los datos del alumno {i}:");
                            Console.Write("Nombre: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Apellido: ");
                            string apellido = Console.ReadLine();
                            Console.Write("Curso: ");
                            if (int.TryParse(Console.ReadLine(), out int curso))
                            {
                                listaAlumnos.Add(new Alumno(nombre, apellido, curso));
                            }
                            else
                            {
                                Console.WriteLine("Entrada no válida. Por favor, introduce un valor numérico.");
                            }
                        }
                        break;
                    case 2:
                        if (numeroAlumnos>0) { 
                            Console.WriteLine($"A continuación se crearán los {numeroAlumnos} alumnos:");
                            for (int i = 0; i <= numeroAlumnos-1; i++)
                            {
                                P.StartInfo.Arguments = ($"{listaAlumnos[i].Nombre} {listaAlumnos[i].Apellido} {listaAlumnos[i].Curso}");
                                P.Start();
                            }
                            Thread.Sleep(5000);
                            break;
                        }
                        else
                        {
                        Console.WriteLine("Primero debes introducir alumnos");
                        }
                        break;
                    case 3:
                        Console.WriteLine("¡Chao!");
                        break;
                    }
               } while (opcion != 3);
        }

    }

