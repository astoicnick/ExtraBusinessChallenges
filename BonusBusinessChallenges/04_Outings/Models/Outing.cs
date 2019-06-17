using System;

namespace _Outings.Models
{
    public enum EventType { Golf,Bowling,AmusementPark,Concert}

    public class Outing
    {
        public int Attendees { get; set; }
        public DateTime DateOfOuting { get; set; }
        public decimal CostOfEvent { get; set; }
        public decimal CostPerPerson { get; set; }
        public EventType TypeOfEvent { get; set; }

        public Outing(){ }
        public Outing(int attendees,DateTime dateOfOuting, decimal costOfEvent,
            decimal costPerPerson, EventType typeOfEvent)
        {
            Attendees = attendees;
            DateOfOuting = dateOfOuting;
            CostOfEvent = costOfEvent;
            CostPerPerson = costPerPerson;
            TypeOfEvent = typeOfEvent;
        }
    }
}
