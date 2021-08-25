using System;
using System.Collections.Generic;


namespace TeamHarrySpyDuhPoject.Models
{
    public class Spy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SpySkills> Skills { get; set; }

        public List<SpyServices> Services { get; set; }

        public List<Spy> Friends { get; set; }

        public List<Spy> Enemies { get; set; }
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
