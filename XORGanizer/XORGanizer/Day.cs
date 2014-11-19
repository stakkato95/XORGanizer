﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XORGanizer
{
    public class Day
    {
        DateTime currentDay;
        private SortedList<DateTime, Event> listOfEvents;

        public Day()
        {
            this.currentDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.listOfEvents = new SortedList<DateTime, Event>();
        }

        public Day(DateTime someDay)
        {
            this.currentDay = new DateTime(someDay.Year, someDay.Month, someDay.Day);
            this.listOfEvents = new SortedList<DateTime, Event>();
        }

        public void AddEvent(Event someEvent)
        {
            if (listOfEvents.ContainsKey(someEvent.Starting))
            {
                throw new Exception("The beginning time coincides with the beginning time of another event");
            }
            if (someEvent.Starting > someEvent.Ending)
            {
                throw new InvalidTimeZoneException("The ending time is bigger than starting time");
            }
            listOfEvents.Add(someEvent.Starting, someEvent);
        }

        public void DeleteEvent(Event someEvent)
        {
            listOfEvents.Remove(someEvent.Starting);
        }

        public IEnumerator GetEnumerator()
        {
            return listOfEvents.TakeWhile((t, i) => i != listOfEvents.Count).Select((t, i) => listOfEvents.ElementAt(i)).GetEnumerator();
        }
    }
}
