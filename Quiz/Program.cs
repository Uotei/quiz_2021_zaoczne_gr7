using System;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            PokazEkranPowitalny();
            Gra gra = new Gra();
            Pytanie p1 = gra.WylosujPytanie();
            string odpGracza = PokazPytanieGraczowi(p1);
            
            if (odpGracza == "1")
            {
                DobraOdpowiedz(p1);
            }
            else
            {
                KoniecGry();
            }




            Console.ReadLine();
        }


        static void PokazEkranPowitalny()
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






        static string PokazPytanieGraczowi(Pytanie pytanie)
        {
            Console.Clear();
            Console.WriteLine();
            //Console.WriteLine("Pytanie za " + pytanie.Kategoria + " pkt.");
            Console.WriteLine($"Pytanie za {pytanie.Kategoria} pkt.");
            Console.WriteLine();
            Console.WriteLine(pytanie.Tresc);
            Console.WriteLine();
            foreach (Odpowiedz odp in pytanie.Odpowiedzi)
            {
                Console.WriteLine($"{odp.Id}. {odp.Tresc}");
            }

            Console.WriteLine();
            Console.Write("Proszę podać numer odpowiedzi: ");
            return Console.ReadLine();
        }


        static void DobraOdpowiedz(Pytanie pytanie)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Brawo !!! Dobra odpowiedź.");
            Console.WriteLine();
            Console.WriteLine($"Wygrywasz {pytanie.Kategoria} pkt.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void KoniecGry()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Niestety, to zła odpowiedź");
            Console.WriteLine();
            Console.WriteLine("K O N I E C   G R Y !!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
