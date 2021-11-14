using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Gra
    {
        public int BiezacaKategoriaPytania { get; set; }
        public List<Pytanie> WszystkiePytania { get; set; }


        public Gra()
        {
            BiezacaKategoriaPytania = 500;
            WszystkiePytania = new List<Pytanie>();
            StworzBazePytan();
        }


        public void StworzBazePytan()
        {
            WszystkiePytania = //
        }

        public Pytanie WylosujPytanie()
        {
            Pytanie p = new Pytanie();
            p.Id = 1;
            p.Tresc = "Jak miał na imię Einstein?";
            p.Kategoria = 500;

            Odpowiedz odp1 = new Odpowiedz();
            odp1.Id = 1;
            odp1.Tresc = "Albert";
            odp1.CzyPrawidlowa = true;
            p.Odpowiedzi.Add(odp1);

            Odpowiedz odp2 = new Odpowiedz();
            odp2.Id = 2;
            odp2.Tresc = "Aaron";
            p.Odpowiedzi.Add(odp2);

            Odpowiedz odp3 = new Odpowiedz();
            odp3.Id = 3;
            odp3.Tresc = "Andrew";
            p.Odpowiedzi.Add(odp3);

            Odpowiedz odp4 = new Odpowiedz();
            odp4.Id = 4;
            odp4.Tresc = "Anthony";
            p.Odpowiedzi.Add(odp4);

            return p;
        }

    }
}
