using System;
using System.Collections.Generic;

namespace TeamHarrySpyDuhPoject.Models
{
    public class Spy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<SpySkills> Skills { get; set; } = new List<SpySkills>();

        public List<SpyServices> Services  { get; set; }  = new List<SpyServices>();

        public List<Spy> Friends { get; set; } = new List<Spy>();

        public List<Spy> Enemies { get; set; } = new List<Spy>();
    }

    public enum SpySkills
    {
        Commando,
        DemolitionExpert,
        EscapeArtist,
        Infiltrator,
        Linguist,
        MasterInterrogator,
        NaturalOrator,
        SafeCracker,
        Tough
    }

    public enum SpyServices
    {
        CounterIntelligence,
        BuildNetwork,
        Propaganda,
        DiplomaticPressure,
        StealBlueprint,
        Sabotage
    }

}
