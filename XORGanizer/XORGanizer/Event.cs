using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XORGanizer
{
    public enum EventImportance { Low, Middle, High }
    public sealed class Event
    {
        public DateTime Starting { get; private set; }
        public DateTime Ending { get; private set; }
        public string Description { get; private set; }
        public EventImportance Importance { get; private set; }

        public Event(int startYear, int startMonth, int startDay, int startHour, int startMinute, int endYear, int endMonth, int endDay, int endHour, int endMinute, EventImportance importance, string description)
        {
            Starting = new DateTime(startYear, startMonth, startDay, startHour, startMinute, 0);
            Ending = new DateTime(endYear, endMonth, endDay, endHour, endMinute, 0);
            Description = String.IsNullOrEmpty(description) ? "Описание отсутствует" : description;
            Importance = importance;
        }
        public Event(long startTicks, long endTicks, EventImportance importance, string description)
        {
            Starting = new DateTime(startTicks);
            Ending = new DateTime(endTicks);
            Description = String.IsNullOrEmpty(description) ? "Описание отсутствует" : description;
            Importance = importance;
        }
    }
}
