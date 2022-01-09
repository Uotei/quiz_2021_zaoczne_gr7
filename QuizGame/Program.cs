using QuizBackend;
using System;

namespace QuizGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ekran.PokazEkranPowitalny();
            Gra gra = new Gra();
            while (true)
            {
                gra.WylosujPytanie();
                if (gra.CzyPrawidlowaOspowiedz(Ekran.PokazPytanieGraczowi(gra.AktualnePytanie)))
                {
                    Ekran.DobraOdpowiedz(gra.AktualnePytanie);
                    if (!gra.PrzejdzDoNastepnejKategorii())
                    {
                        Ekran.Wygrana();
                        return;
                    }
                }
                else
                {
                    Ekran.KoniecGry();
                    return;
                }
            }
        }
    }
}
