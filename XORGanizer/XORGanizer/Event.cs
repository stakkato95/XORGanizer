using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XORGanizer
{
    public sealed class Event
    {
        public DateTime Starting { get; private set; }
        public DateTime Ending { get; private set; }
        public bool Fulfillment { get; private set; } //событие выполнено или не выполнено
        public string Title { get; private set; }
        public string Description { get; private set; }

    //    public long Id { get; private set; } айдишкик как думаешь нужен или нет

        //public enum priority //было бы не плохо организовать приоритет
        //{
        //    IMPORTANT,
        //    NORMAL,
        //    MATTER
        //}
       
        

        public Event()
        {
            Starting = DateTime.Now;
            Ending = DateTime.Now.AddMinutes(15);
            Fulfillment = false;
            Description = "Описание отсутствует";
        }
        public Event(int startYear, int startMonth, int startDay, int startHour, int startMinute, int startSecond, int endYear, int endMonth, int endDay, int endHour, int endMinute, int endSecond, string description = "Описание отсутствует", string title = "Заголовок отсутствует") //я думаю,что будем использовать этот конструктор http://msdn.microsoft.com/ru-ru/library/272ba130(v=vs.110).aspx, т.к. в формсах явно будет неудобно забивать такую например дату March 01, 2008 7:00:00 AM вручную 
        {
            Starting = new DateTime(startYear, startMonth, startDay, startHour, startMinute, startSecond);
            Ending = new DateTime(endYear, endMonth, endDay, endHour, endMinute, endSecond);
            Fulfillment = false;
            Description = description;
            Title = title;

        }
    }
}
