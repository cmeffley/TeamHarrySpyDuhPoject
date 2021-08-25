using System;
using System.Collections.Generic;
using System.Linq;
using TeamHarrySpyDuhPoject.Models;

namespace TeamHarrySpyDuhPoject.DataAccess
{
    public class SpyRepository
    {
        static List<Spy> _spies = new List<Spy>
        {
            new Spy
            {
                Id = Guid.NewGuid(),
                Name = "Rick",
                Skills = new List<SpySkills>()
                {
                    SpySkills.Commando,
                    SpySkills.Infiltrator,
                    SpySkills.NaturalOrator
                },
                Services = new List<SpyServices>()
                {
                    SpyServices.CounterIntelligence,
                    SpyServices.Propaganda,
                    SpyServices.StealBlueprint
                },
            },
            new Spy
            {
                Id = Guid.NewGuid(),
                Name = "Morty",
                Skills = new List<SpySkills>()
                {
                    SpySkills.Infiltrator,
                    SpySkills.EscapeArtist,
                    SpySkills.SafeCracker
                },
                Services = new List<SpyServices>()
                {
                    SpyServices.BuildNetwork,
                    SpyServices.DiplomaticPressure,
                    SpyServices.Sabotage
                },

            },
            new Spy
            {
                Id = Guid.NewGuid(),
                Name = "Mary",
                Skills = new List<SpySkills>()
                {
                    SpySkills.Linguist,
                    SpySkills.Tough,
                    SpySkills.DemolitionExpert
                },
                Services = new List<SpyServices>()
                {
                    SpyServices.CounterIntelligence,
                    SpyServices.StealBlueprint,
                    SpyServices.BuildNetwork
                },

            }
        };

        internal IEnumerable<Spy> GetAll()
        {
            return _spies;
        }

        internal Spy GetSpyById(Guid spyId)
        {
            return _spies.FirstOrDefault(spy => spy.Id == spyId);
        }

        //internal void Add(Spy spyFriend)
        //{
        //    _spies.
        //}
    }
}
