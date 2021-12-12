using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Gra
    {
        public int BiezacaKategoriaPytania { get; set; }
        public List<Pytanie> WszystkiePytania { get; set; }
        public List<int> KategoriePytan { get; set; }
        public int IndeksKategorii { get; set; }

        public Gra()
        {         
            StworzBazePytan();
            StworzListeKategorii();
            BiezacaKategoriaPytania = KategoriePytan[IndeksKategorii];
        }

        public void StworzBazePytan()
        {
            string path = Directory.GetCurrentDirectory() + "\\pytania.json";
            string content = File.ReadAllText(path);
            WszystkiePytania = JsonConvert.DeserializeObject<List<Pytanie>>(content);

            // PĘTLA FOREACH
            //int numer = 1;
            //foreach (Pytanie pytanie in WszystkiePytania)
            //{
            //    pytanie.Id = numer;
            //    numer++;
            //}

            // PĘTLA FOR
            for (int idx = 0; idx < WszystkiePytania.Count; idx++)
            {
                WszystkiePytania[idx].Id = idx + 1;
            }
        }

        public void StworzListeKategorii()
        {
            // Select => tworzy nową listę o takiej samej długości z wybranymi właściwościami
            // Distinct => elimunuje z listy duplikaty
            KategoriePytan = WszystkiePytania.Select(p => p.Kategoria).Distinct().OrderBy(o => o).ToList();
        }

        public Pytanie WylosujPytanie()
        {
            // 1. musimy wyfiltrować WszystkiePytania żeby zostały tylko pytania z BiezącejKategorii
            List<Pytanie> pytaniaZBiezacejKategorii = WszystkiePytania.Where(p => p.Kategoria == BiezacaKategoriaPytania).ToList();

            // 2. wylosować jakiś element tej kolekcji => DO ZROBIENIA
            int liczbaLosowa = Randomizer.Randomizer.GenarateRandomNumber(pytaniaZBiezacejKategorii.Count);

            var pytanie = pytaniaZBiezacejKategorii[liczbaLosowa - 1];

            // 3. Losujemy kolejność odpowiedzi na pytanie
            List<int> losoweCzteryLiczby = Randomizer.Randomizer
                .ListOfRandomNumbers(pytanie.Odpowiedzi.Count, pytanie.Odpowiedzi.Count);

            for (int idx = 0; idx < pytanie.Odpowiedzi.Count; idx++)
            {
                pytanie.Odpowiedzi[idx].Kolejnosc = losoweCzteryLiczby[idx];
            }

            // OrderBy
            // OrderByDescending
            pytanie.Odpowiedzi = pytanie.Odpowiedzi.OrderBy(p => p.Kolejnosc).ToList();
            return pytanie;


            // PRZYDATNE METODY LISTY (KOLEKCJI)
            //List<int> numerki = new List<int>();
            //numerki.Add(10);
            //numerki.Add(3);
            //numerki.Add(4);
            //numerki.Add(6);
            //numerki.Add(11);

            ////// WYRAŻENIE LAMBDA =>
            //int numerek1 = numerki.First();
            //var numerek2 = numerki.FirstOrDefault(x => x < 10);
            //List<int> mojeNumerki = numerki.Where(x => x >= 10).ToList();
            //int numerek3 = numerki.Max();
            //int numerek4 = numerki.Sum();
            //var test = numerki.Average();
        }

        public bool PrzejdzDoNastepnejKategorii()
        {
            IndeksKategorii++;
            if (IndeksKategorii <= KategoriePytan.Count - 1)
            {
                BiezacaKategoriaPytania = KategoriePytan[IndeksKategorii];
                return true;
            }
            else
                return false;    
        }
    }
}
