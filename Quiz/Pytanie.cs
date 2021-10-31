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
        public string Odpowiedz1 { get; set; }
        public string Odpowiedz2 { get; set; }
        public string Odpowiedz3 { get; set; }
        public string Odpowiedz4 { get; set; }
    }
}
