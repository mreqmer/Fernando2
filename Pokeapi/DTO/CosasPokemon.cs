using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class CosasPokemon
    {
        public int Count { get; set; }
        public List<ClsPokemon> Results { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }

        public CosasPokemon() { }

        public CosasPokemon(int count, List<ClsPokemon> results, string next, string previous)
        {
            Count = count;
            Results = results;
            Next = next;
            Previous = previous;
        }
    }
}
