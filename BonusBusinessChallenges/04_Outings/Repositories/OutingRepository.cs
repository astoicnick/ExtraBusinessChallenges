using System;
using System.Collections.Generic;
using _Outings.Models;

namespace _Outings.Repositories
{
    public class OutingRepository : IOutingRepository
    {
        private List<Outing> _outings = new List<Outing>();

        public void AddInitialOuting()
        {
            Outing testOuting = new Outing(50,new DateTime(2000, 10, 10), 500.00m, 0, EventType.AmusementPark);
            _outings.Add(testOuting);
        }
        public void AddOuting(Outing outingToAdd)
        {
            outingToAdd.CostPerPerson = outingToAdd.CostOfEvent / outingToAdd.Attendees;
            _outings.Add(outingToAdd);
        }

        public decimal CostOfAllOutings()
        {
            decimal costCounter = 0m;

            foreach (Outing outing in _outings)
            {
                costCounter += outing.CostOfEvent;
            }
            return costCounter;
        }

        public List<Outing> displayOutings()
        {
            return _outings;
        }

        public decimal OutingCostByType(EventType eventType)
        {
            decimal outingCostByType = 0m;
            foreach (Outing outing in _outings)
            {
                if (outing.TypeOfEvent == eventType)
                {
                    outingCostByType += outing.CostOfEvent;
                }
            }
            return outingCostByType;
        }
    }
}
