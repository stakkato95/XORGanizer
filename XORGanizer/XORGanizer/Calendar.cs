using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XORGanizer
{
    public class Calendar
    {
        SortedList<DateTime, Day> listOfDays = new SortedList<DateTime, Day>();

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

    }
}
