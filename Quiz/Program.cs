using System;
using System.Linq;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            PokazEkranPowitalny();
            Gra gra = new Gra();

            // Wersja 1
            //bool czyGraczOdpowiadaPrawidlowo = true;
            //while (czyGraczOdpowiadaPrawidlowo)
            //{
            //    Pytanie p = gra.WylosujPytanie();
            //    string odpGracza = PokazPytanieGraczowi(p);
            //    // gracz podajne Kolejnosc odpowiedzi (on o tym nie wiem ale my wiemy)
            //    // wiemy która odpowiedz jest prawidlowa (CzyPrawidlowa)
            //    int odpowiedzGraczaJakoLiczba = int.Parse(odpGracza);
            //    var wybranaOdpowiedz = p.Odpowiedzi.FirstOrDefault(o => o.Kolejnosc == odpowiedzGraczaJakoLiczba);
            //    if (wybranaOdpowiedz.CzyPrawidlowa)
            //    {
            //        DobraOdpowiedz(p);
            //        // przejscie do wyższej kategorii
            //        gra.PrzejdzDoNastepnejKategorii();
            //    }
            //    else
            //    {
            //        KoniecGry();
            //        czyGraczOdpowiadaPrawidlowo = false;
            //    }
            //}

            // Wersja 2
            //bool czyGraczOdpowiadaPrawidlowo = true;
            //do
            //{
            //    Pytanie p = gra.WylosujPytanie();
            //    string odpGracza = PokazPytanieGraczowi(p);
            //    // gracz podajne Kolejnosc odpowiedzi (on o tym nie wiem ale my wiemy)
            //    // wiemy która odpowiedz jest prawidlowa (CzyPrawidlowa)
            //    int odpowiedzGraczaJakoLiczba = int.Parse(odpGracza);
            //    var wybranaOdpowiedz = p.Odpowiedzi.FirstOrDefault(o => o.Kolejnosc == odpowiedzGraczaJakoLiczba);
            //    if (wybranaOdpowiedz.CzyPrawidlowa)
            //    {
            //        DobraOdpowiedz(p);
            //        // przejscie do wyższej kategorii
            //        gra.PrzejdzDoNastepnejKategorii();
            //    }
            //    else
            //    {
            //        KoniecGry();
            //        czyGraczOdpowiadaPrawidlowo = false;
            //    }
            //}
            //while (czyGraczOdpowiadaPrawidlowo);

            while (true)
            {
                Pytanie p = gra.WylosujPytanie();
                string odpGracza = PokazPytanieGraczowi(p);
                // gracz podajne Kolejnosc odpowiedzi (on o tym nie wiem ale my wiemy)
                // wiemy która odpowiedz jest prawidlowa (CzyPrawidlowa)
                int odpowiedzGraczaJakoLiczba = int.Parse(odpGracza);
                var wybranaOdpowiedz = p.Odpowiedzi.FirstOrDefault(o => o.Kolejnosc == odpowiedzGraczaJakoLiczba);
                if (wybranaOdpowiedz.CzyPrawidlowa)
                {
                    DobraOdpowiedz(p);
                    // przejscie do wyższej kategorii
                    if (!gra.PrzejdzDoNastepnejKategorii())
                    {
                        Wygrana();
                        return;
                    }
                }
                else
                {
                    KoniecGry();
                    return;
                }
            }

            Console.ReadLine();
        }

        static void Wygrana()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Brawo !!! Ukończyłaś/eś QUIZ WYGRYWASZ 1000 pkt.");
            Console.ForegroundColor = ConsoleColor.White;
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
                Console.WriteLine($"{odp.Kolejnosc}. {odp.Tresc}");
            }

            Console.WriteLine();
            Console.Write("Proszę wpisać 1, 2, 3 lub 4: ");
            return Console.ReadLine();
        }


        static void DobraOdpowiedz(Pytanie pytanie)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Brawo !!! Dobra odpowiedź.");
            Console.WriteLine();
            Console.WriteLine($"Wygrywasz {pytanie.Kategoria} pkt.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        static void KoniecGry()
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
