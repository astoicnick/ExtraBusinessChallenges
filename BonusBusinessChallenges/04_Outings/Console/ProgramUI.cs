using System;
using _Outings.Models;
using _Outings.Repositories;

namespace _Outings.Console
{
    public class ProgramUI
    {
        IOutingRepository _repo;
        public ProgramUI(IOutingRepository repo)
        {
            _repo = repo;
        }
        public void Run()
        {
            while (Menu()) { }
        }
        private bool Menu()
        {
            System.Console.WriteLine("Komodo Outings Software:\n" +
                "1. Display all outings\n" +
                "2. Add an outing\n" +
                "3. See cost of all events for the year\n" +
                "4. See cost by event type\n" +
                "5. Exit");
            string userKey = System.Console.ReadLine();
            switch (userKey)
            {
                case "1":
                    DisplayOutings();
                    break;
                case "2":
                    _repo.AddOuting(GetOuting());
                    break;
                case "3":
                    DisplayTotalCost();
                    break;
                case "4":
                    DisplayEventTypeCost();
                    break;
                case "5":
                    return false;
                default:
                    System.Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
            return true;
        }
        private void DisplayOutings()
        {
            System.Console.WriteLine("Event Type\t\tAttendee Count \tEvent Cost\tDate Of Outing");
            int outingCounter = 1;
            foreach (Outing outing in _repo.displayOutings())
            {
                System.Console.WriteLine($"{outingCounter}. {outing.TypeOfEvent}\t{outing.Attendees}\t\t{outing.CostOfEvent}\t\t{outing.DateOfOuting.ToString("m")}");
                outingCounter++;
            }
            System.Console.WriteLine("");
        }
        private Outing GetOuting()
        {
            Outing userOuting = new Outing();
            int enumcount = 1;
            System.Console.WriteLine("What is the type of event?");
            foreach (EventType type in Enum.GetValues(typeof(EventType)))
            {
                System.Console.WriteLine($"{enumcount}. {type}");
                enumcount++;
            }
            string userKey = System.Console.ReadLine();
            switch (userKey)
            {
                case "1":
                    userOuting.TypeOfEvent = EventType.Golf;
                    break;
                case "2":
                    userOuting.TypeOfEvent = EventType.Bowling;
                    break;
                case "3":
                    userOuting.TypeOfEvent = EventType.AmusementPark;
                    break;
                case "4":
                    userOuting.TypeOfEvent = EventType.Concert;
                    break;
            }
            System.Console.WriteLine("How many people attended the event?");
            userOuting.Attendees = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("When was the outing? ex: (06-15)");
            userOuting.DateOfOuting = DateTime.Parse(System.Console.ReadLine());
            System.Console.WriteLine("How much did the event cost total?");
            userOuting.CostOfEvent = decimal.Parse(System.Console.ReadLine());
            return userOuting;
        }
        private void DisplayTotalCost()
        {
            System.Console.WriteLine($"Cost of all events this year is ${_repo.CostOfAllOutings()}");
        }
        private void DisplayEventTypeCost()
        {
            EventType userType = new EventType();
            int enumcount = 1;
            System.Console.WriteLine("What is the type of event you want to calculate?");
            foreach (EventType type in Enum.GetValues(typeof(EventType)))
            {
                System.Console.WriteLine($"{enumcount}. {type.ToString()}");
                enumcount++;
            }
            string userKey = System.Console.ReadLine();
            switch (userKey)
            {
                case "1":
                    userType = EventType.Golf;
                    break;
                case "2":
                    userType = EventType.Bowling;
                    break;
                case "3":
                    userType = EventType.AmusementPark;
                    break;
                case "4":
                    userType = EventType.Concert;
                    break;
            }
            decimal userCost = _repo.OutingCostByType(userType);
            System.Console.WriteLine($"The cost for all {userType.ToString()} this year is ${userCost}.");
        }

    }
}
