using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Gra
    {
        public void StworzBazePytan()
        {

        }

        public Pytanie WylosujPytanie()
        {
            Pytanie p = new Pytanie();
            p.Id = 1;
            p.Tresc = "Jak miał na imię Einstein?";
            p.Kategoria = 500;
            p.Odpowiedz1 = "Albert";
            p.Odpowiedz2 = "Aaron";
            p.Odpowiedz3 = "Andrew";
            p.Odpowiedz4 = "Anthony";
            return p;
        }

    }
}
