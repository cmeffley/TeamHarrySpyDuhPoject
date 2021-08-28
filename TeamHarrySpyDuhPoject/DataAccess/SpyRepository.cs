using System;
using System.Collections.Generic;
using System.Linq;
using TeamHarrySpyDuhPoject.Models;

namespace TeamHarrySpyDuhPoject.DataAccess
{
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
                    SpySkills.NaturalOrator,
                    SpySkills.MasterInterrogator
                },
                Services = new List<SpyServices>()
                {
                    SpyServices.CounterIntelligence,
                    SpyServices.Propaganda,
                    SpyServices.StealBlueprint
                },
                AgencyId = Guid.NewGuid()
            },
            new Spy
            {
                Id = Guid.NewGuid(),
                Name = "Morty",
                Skills = new List<SpySkills>()
                {
                    SpySkills.Commando,
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
                AgencyId = Guid.NewGuid()
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
                AgencyId = Guid.NewGuid()
            }
        };

            internal IEnumerable<Spy> GetAll()
        {
           return _spies;
        }

        internal IEnumerable<Spy> GetBySkill(SpySkills skill)
        {
            var specificSpies = _spies
                .Where(s => s.Skills.Contains(skill));             

            return specificSpies;

        }


        internal SpyInfo GetInfo(Guid id)
        {
            var spy = _spies.Where(spy => spy.Id == id).FirstOrDefault();

            return new SpyInfo { Skills = spy.Skills, Services = spy.Services };
        }

        internal Spy GetSpyById(Guid spyId)
        {
            return _spies.FirstOrDefault(spy => spy.Id == spyId);
        }

<<<<<<< HEAD
        internal IEnumerable<Spy> GetAgencySpies(Guid agencyId)
        {
            var AgencySpies = _spies.Where(spy => spy.AgencyId == agencyId);

            return AgencySpies;
        }

=======
>>>>>>> 3edfb95e1d946b2d52b10d2e4e1dc515f60ff054
    }
    public class SpyInfo
    {
        public List<SpySkills> Skills { get; set; }
        public List<SpyServices> Services { get; set; }
    }

}
