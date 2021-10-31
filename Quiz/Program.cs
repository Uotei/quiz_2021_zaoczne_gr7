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
            Pytanie p2 = gra.WylosujPytanie();



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

    }
}
