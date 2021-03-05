using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace plock_m1.Models
{
    public class dag
    {

        public int Week { get; set; }
        public string WeekDag { get; set; }
        public DateTime Date { get; set; }
        public string Naam { get; set; }
        public string BeginTijd { get; set; }
        public string EindTijd { get; set; }
        public int Klanten { get; set; }

        public dag(DateTime aDate, string aNaam, string aBeginTijd, string aEindTijd, int aKlanten)
        {
            Week = GetIso8601WeekOfYear(aDate);
            WeekDag = aDate.DayOfWeek.ToString();
            Date = aDate;
            Naam = aNaam;
            BeginTijd = aBeginTijd;
            EindTijd = aEindTijd;
            Klanten = aKlanten;
        }
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
