using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBackend
{
    public class Odpowiedz
    {
        public int Id { get; set; }
        public string Tresc { get; set; }
        public bool CzyPrawidlowa { get; set; }
        public int Kolejnosc { get; set; }
    }
}
