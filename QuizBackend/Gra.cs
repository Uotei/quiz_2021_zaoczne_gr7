using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBackend
{
    public class Gra
    {
        public int BiezacaKategoriaPytania { get; set; }
        public List<Pytanie> WszystkiePytania { get; set; }
        public List<int> KategoriePytan { get; set; }
        public int IndeksKategorii { get; set; }
        public Pytanie AktualnePytanie { get; set; }

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

        public void WylosujPytanie()
        {         
            List<Pytanie> pytaniaZBiezacejKategorii = WszystkiePytania.Where(p => p.Kategoria == BiezacaKategoriaPytania).ToList();        
            int liczbaLosowa = Randomizer.Randomizer.GenarateRandomNumber(pytaniaZBiezacejKategorii.Count);
            var pytanie = pytaniaZBiezacejKategorii[liczbaLosowa - 1];
            List<int> losoweCzteryLiczby = Randomizer.Randomizer
                .ListOfRandomNumbers(pytanie.Odpowiedzi.Count, pytanie.Odpowiedzi.Count);

            for (int idx = 0; idx < pytanie.Odpowiedzi.Count; idx++)
            {
                pytanie.Odpowiedzi[idx].Kolejnosc = losoweCzteryLiczby[idx];
            }

            pytanie.Odpowiedzi = pytanie.Odpowiedzi.OrderBy(p => p.Kolejnosc).ToList();
            AktualnePytanie = pytanie;
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

        public bool CzyPrawidlowaOspowiedz(int odpowiedzGracza)
        {
            return AktualnePytanie.Odpowiedzi.FirstOrDefault(o => o.Kolejnosc == odpowiedzGracza).CzyPrawidlowa;
        }
    }
}
