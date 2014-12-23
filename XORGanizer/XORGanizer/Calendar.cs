using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace XORGanizer
{
    public class Calendar
    {
        private SortedList<DateTime, Day> listOfDays = new SortedList<DateTime, Day>();

        public void AddDay(DateTime dateTime, Day day)
        {
            listOfDays.Add(dateTime, day);
        }

        public void RemoveDay(DateTime dateTime)
        {
            listOfDays.Remove(dateTime);
        }

        public bool ContainsKey(DateTime dateTime)
        {
            return listOfDays.ContainsKey(dateTime);
        }

        public Day this[ DateTime key ]
        {
            get
            {
                return listOfDays[key];
            }
            set
            {
                listOfDays[key] = value;

            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < listOfDays.Count; i++)
            {
                if (i == listOfDays.Count)
                    yield break;
                yield return listOfDays.ElementAt(i);
            }
        }
    }
}
