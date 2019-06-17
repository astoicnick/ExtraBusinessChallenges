using System;
using System.Collections.Generic;
using _Outings.Models;

namespace _Outings.Repositories
{
    public interface IOutingRepository
    {
        List<Outing> displayOutings();
        void AddOuting(Outing outingToAdd);
        decimal CostOfAllOutings();
        decimal OutingCostByType(EventType eventType);
        void AddInitialOuting();
    }
}
