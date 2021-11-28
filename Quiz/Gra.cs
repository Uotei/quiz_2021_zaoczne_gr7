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

        public Gra()
        {
            BiezacaKategoriaPytania = 500;
            StworzBazePytan();
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

        public Pytanie WylosujPytanie()
        {
            // 1. musimy wyfiltrować WszystkiePytania żeby zostały tylko pytania z BiezącejKategorii
            List<Pytanie> pytaniaZBiezacejKategorii = WszystkiePytania.Where(p => p.Kategoria == BiezacaKategoriaPytania).ToList();

            // 2. wylosować jakiś element tej kolekcji => DO ZROBIENIA
            int liczbaLosowa = 2;
            return pytaniaZBiezacejKategorii[liczbaLosowa - 1];


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

    }
}
