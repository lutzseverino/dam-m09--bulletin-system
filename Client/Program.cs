class Client
{
    static void Main(string[] args)
    {
        string nom = args[0];
        string cognom = args[1];
        int curs = Convert.ToInt32(args[2]);
        generarButlleti(nom, cognom, curs);

    }
    static void generarButlleti(string nom, string cognom, int curs)
    {
        Random r = new Random();

        Console.WriteLine($"Alumne: {nom} {cognom}");
        Console.WriteLine($"Curs: DAM{curs}");

        if (curs == 1)
        {
            for(int i = 1; i < 6; i++)
            {
                var nota = r.Next(0, 11);
                Console.WriteLine($"M0{i}: {nota}");
            }
        } 
        else if (curs == 2)
        {
            for (int i = 6; i < 14; i++)
            {
                var nota = r.Next(0, 11);
                Console.WriteLine($"M0{i}: {nota}");
            }
        }
        else
        {
            Console.WriteLine($"L'alumne {nom} {cognom} esta cursant el curs {curs} que es inexistent.");
        }
    }
}
