using static BlazorApp3.Pages.Index;
using System.Text.Json.Serialization;

namespace BlazorApp3
{
    public class objSumula
    {
        public objSumula(int i)
        {
            jogadoresTimeA = new();
            jogadoresTimeA.Add(new("GK"));
            jogadoresTimeA.Add(new("ZAG"));
            jogadoresTimeA.Add(new("MID"));
            jogadoresTimeA.Add(new("ATK"));

            jogadoresTimeB = new();
            jogadoresTimeB.Add(new("GK"));
            jogadoresTimeB.Add(new("ZAG"));
            jogadoresTimeB.Add(new("MID"));
            jogadoresTimeB.Add(new("ATK"));
        }
        public objSumula()
        {
        }
        public string nomeTimeA { get; set; } = "";
        public string nomeTimeB { get; set; } = "";
        [JsonIgnore]
        public int placarTimeA { get { return jogadoresTimeB.Select(a => a.golsContra).Sum() + jogadoresTimeA.Select(a => a.gols).Sum(); } }
        [JsonIgnore]
        public int placarTimeB { get { return jogadoresTimeA.Select(a => a.golsContra).Sum() + jogadoresTimeB.Select(a => a.gols).Sum(); } }
        public List<Jogadores> jogadoresTimeA { get; set; } = new();
        public List<Jogadores> jogadoresTimeB { get; set; } = new();
        [JsonIgnore]
        public List<Jogadores> todosJogadores
        {
            get
            {
                var jogadores = new List<Jogadores>();
                jogadores.AddRange(jogadoresTimeA);
                jogadores.AddRange(jogadoresTimeB);
                return jogadores;
            }
        }


        [JsonIgnore]
        public string sssumula { get; set; }
        public string Anotacoes { get; set; } = "";
    }
}
