using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XORGanizer
{
    class Day
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

        public void addEvent(Event someEvent)
        {
            if (listOfEvents.ContainsKey(someEvent.Starting))
            {
                throw new Exception("Время начала совпадают!");
            }
            listOfEvents.Add(someEvent.Starting, someEvent);
        }
        public void deleteEvent(Event someEvent)
        {
            listOfEvents.Remove(someEvent.Starting);
        }

        public void modifyEvent(Event somEvent)
        {
            
        }

    }
}
