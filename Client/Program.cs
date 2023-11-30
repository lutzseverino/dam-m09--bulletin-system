namespace BulletinSystem
{
    class Client
    {
        static void Main(string[] args)
        {
            string name = args[0];
            string surname = args[1];
            int course = Convert.ToInt32(args[2]);
            GenerateBulletin(name, surname, course);
        }

        private static void GenerateBulletin(string name, string surname, int course)
        {
            Random r = new Random();

            Console.WriteLine($"┌───────────────────────────┐");
            Console.WriteLine($"│       Buletín Escolar     │");
            Console.WriteLine($"├───────────────────────────┤");
            Console.WriteLine($"│ Alumne: {name} {surname}        │");
            Console.WriteLine($"│ Curs: DAM{course}                │");

            if (course == 1)
            {
                for (int i = 1; i < 6; i++)
                {
                    var nota = r.Next(0, 11);
                    Console.WriteLine($"│ M0{i}: {nota,-3}                  │");
                }
            }
            else if (course == 2)
            {
                for (int i = 6; i < 14; i++)
                {
                    var nota = r.Next(0, 11);
                    Console.WriteLine($"│ M0{i}: {nota,-3}                 │");
                }
            }
            else
            {
                Console.WriteLine($"│ El alumno {name} {surname} está cursando el curso {course,-2}, que no existe. │");
            }

            Console.WriteLine($"└───────────────────────────┘");
        }
    }
}