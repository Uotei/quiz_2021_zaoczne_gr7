using QuizBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public static class Ekran
    {
        public static void Wygrana()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Brawo !!! Ukończyłaś/eś QUIZ WYGRYWASZ 1000 pkt.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void PokazEkranPowitalny()
        {
            Console.WriteLine();
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("*                                                                 *");
            Console.WriteLine("*                       WITAM W MOIM QUIZIE                       *");
            Console.WriteLine("*                                                                 *");
            Console.WriteLine("*           Odpowiedz na 5 pytań, aby wygrać 10 000 PLN           *");
            Console.WriteLine("*                                                                 *");
            Console.WriteLine("*                          _____________                          *");
            Console.WriteLine("*                                                                 *");
            Console.WriteLine("*                  Programowanie: Andrzej Herman                  *");
            Console.WriteLine("*                                                                 *");
            Console.WriteLine("*******************************************************************");
            Console.WriteLine();
            Console.Write("Naciśnij klawisz ENTER / RETURN, aby rozpocząć grę ...");
            Console.ReadKey();
            Console.WriteLine();
        }

        public static void WyswietlPytanie(Pytanie pytanie, bool czyWyswietlamyPierwszyRaz)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Pytanie za {pytanie.Kategoria} pkt.");
            Console.WriteLine();
            Console.WriteLine(pytanie.Tresc);
            Console.WriteLine();
            foreach (Odpowiedz odp in pytanie.Odpowiedzi)
            {
                Console.WriteLine($"{odp.Kolejnosc}. {odp.Tresc}");
            }

            Console.WriteLine();
            if (czyWyswietlamyPierwszyRaz)
                Console.Write("Proszę wpisać 1, 2, 3 lub 4: ");
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Nieprawidłowy klawisz. Proszę wpisać 1, 2, 3 lub 4: ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        public static int PokazPytanieGraczowi(Pytanie pytanie)
        {
            Console.Clear();
            WyswietlPytanie(pytanie, true);
            string klawisz = Console.ReadLine();
            bool czyPrawdiwlowyKlawisz = CzyPrawidlowyKlawisz(klawisz);
            while (!czyPrawdiwlowyKlawisz)
            {
                WyswietlPytanie(pytanie, false);
                klawisz = Console.ReadLine();
                czyPrawdiwlowyKlawisz = CzyPrawidlowyKlawisz(klawisz);
            }

            return int.Parse(klawisz);
        }

        public static bool CzyPrawidlowyKlawisz(string klawisz)
        {
            List<string> prawidloweKlawisze = new List<string> { "1", "2", "3", "4", };
            return prawidloweKlawisze.Contains(klawisz);
        }


        public static void DobraOdpowiedz(Pytanie pytanie)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Brawo !!! Dobra odpowiedź.");
            Console.WriteLine();
            Console.WriteLine($"Wygrywasz {pytanie.Kategoria} pkt.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Proszę wcisnąć ENTER aby zobaczyć kolejne pytanie");
            Console.ReadLine();
        }

        public static void KoniecGry()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Niestety, to zła odpowiedź");
            Console.WriteLine();
            Console.WriteLine("K O N I E C   G R Y !!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
