using System;

namespace EntrenamientoNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            EntrenamientoJutsu.PracticarJutsu();
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }

    class EntrenamientoJutsu
    {
        public static void PracticarJutsu()
        {
            int chakra = 100;
            int maestría = 0;
            string[] jutsus = { "Rasengan", "Chidori", "Kage Bunshin" };
         
            Random random = new Random();

            Console.WriteLine("¡Bienvenido al entrenamiento de Jutsu!");

            // Seleccionar Jutsu
            Console.WriteLine("\nJutsus disponibles:");
            int i = 0;
            while (i < jutsus.Length)
            {
                Console.WriteLine($"{i + 1}. {jutsus[i]}");
                i++;
            }

            Console.Write("\nSelecciona un jutsu (1-3): ");
            int selección = int.Parse(Console.ReadLine()) - 1;
            string jutsuSeleccionado = jutsus[selección];

            // Practicar el jutsu
            do
            {
                Console.WriteLine($"\nPracticando {jutsuSeleccionado}...");
                int éxito = random.Next(1, 101);
                chakra -= 10;

                if (éxito > 70)
                {
                    maestría += 5;
                    Console.WriteLine("¡Excelente práctica! +5 maestría");
                }
                else
                {
                    maestría += 2;
                    Console.WriteLine("Práctica regular. +2 maestría");
                }

                Console.WriteLine($"Chakra restante: {chakra}");
                Console.WriteLine($"Maestría actual: {maestría}");

                if (chakra <= 0)
                {
                    Console.WriteLine("\n¡Te has quedado sin chakra!");
                    break;
                }

                Console.WriteLine("\n¿Continuar entrenando? (S/N)");
            } while (Console.ReadLine().ToUpper() == "S");

            Console.WriteLine($"\nEntrenamiento finalizado.");
            Console.WriteLine($"Maestría final en {jutsuSeleccionado}: {maestría}");
        }
    }
}