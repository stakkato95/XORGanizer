using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            foreach (KeyValuePair<DateTime, Event> evnt in listOfEvents)
            {
                if ((someEvent.Starting <= evnt.Value.Starting && evnt.Value.Ending <= someEvent.Ending) ||                                            // 1. [new.beginning   (existing)    new.ending]
                    (evnt.Value.Starting <= someEvent.Starting && someEvent.Ending <= evnt.Value.Ending) ||                                            // 2. (existing.beginning [new] existing.ending)
                    (evnt.Value.Starting <= someEvent.Starting && evnt.Value.Ending <= someEvent.Ending && someEvent.Starting <= evnt.Value.Ending) || // 3. (existing.beginning [new.beginning existing.ending) new.ending]
                    (someEvent.Starting <= evnt.Value.Starting && someEvent.Ending <= evnt.Value.Ending && evnt.Value.Starting <=someEvent.Ending))    // 4. [new.beginning (existing.beginning new.ending] existing.ending)
                {
                    throw new Exception("Events intersection");
                }
            }

            if (listOfEvents.ContainsKey(someEvent.Starting))
            {
                throw new Exception("The beginning time coincides with the beginning time of another event");
            }
            listOfEvents.Add(someEvent.Starting, someEvent);
        }

        public void DeleteEvent(Event someEvent)
        {
            listOfEvents.Remove(someEvent.Starting);
        }
        public void DeleteEvent(DateTime someEventStarting)
        {
            listOfEvents.Remove(someEventStarting);
        }

        public IEnumerator GetEnumerator()
        {
            return listOfEvents.TakeWhile((t, i) => i != listOfEvents.Count).Select((t, i) => listOfEvents.ElementAt(i)).GetEnumerator();
        }
    }
}
