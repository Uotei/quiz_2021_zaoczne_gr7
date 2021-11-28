using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Pytanie
    {
        public int Id { get; set; }
        public string Tresc { get; set; }
        public int Kategoria { get; set; }
        public List<Odpowiedz> Odpowiedzi { get; set; } = new List<Odpowiedz>();
    }
}
