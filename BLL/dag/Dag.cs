using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CL;
using FL;

namespace BLL
{
    public class Dag
    {
        IDagDAL _dagDAL = FactoryDagDAL.CreateDagDAL();
        public int ID { get; set; }
        public int UserID { get; set; }
        public int Week { get; set; }
        public string WeekDag { get; set; }
        public DateTime Date { get; set; }
        public string DagType { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateTime BeginTijd { get; set; }
        public DateTime EindTijd { get; set; }
        public int Klanten { get; set; }
        public Dag(){}

        public Dag(DagDTO dagDTO)
        {
            ID = dagDTO.dagID;
            Week = GetIso8601WeekOfYear(dagDTO.Date);
            WeekDag = dagDTO.Date.DayOfWeek.ToString();
            Date = dagDTO.Date;
            DagType = dagDTO.DagType;
            Naam = dagDTO.Naam;
            BeginTijd = dagDTO.BeginTijd;
            EindTijd = dagDTO.EindTijd;
            Klanten = dagDTO.Klanten;// use a querry to get all klanten
            Beschrijving = dagDTO.Beschrijving;
        }

        //public Dag(int aID, DateTime aDate, string aNaam, string aBeginTijd, string aEindTijd, int aKlanten)
        //{
        //    ID = aID;
        //    Week = GetIso8601WeekOfYear(aDate);
        //    WeekDag = aDate.DayOfWeek.ToString();
        //    Date = aDate;
        //    Naam = aNaam;
        //    BeginTijd = aBeginTijd;
        //    EindTijd = aEindTijd;
        //    Klanten = aKlanten;
        //    Beschrijving = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque tempor arcu eu nisi tincidunt pretium. Cras ornare purus a purus vestibulum, vitae cursus enim ullamcorper. Quisque semper urna non eros suscipit, et laoreet lectus convallis. Sed euismod et nunc id finibus. Nulla quis scelerisque purus, at rhoncus metus. Suspendisse egestas ligula ut nunc sollicitudin luctus. Sed et leo at lorem ultricies gravida sed vitae ipsum. Cras ut orci hendrerit diam consectetur elementum nec sed urna. Vestibulum viverra, justo consequat placerat maximus, neque sapien vulputate magna, sit amet tempor arcu felis at velit. Etiam tempus arcu et tortor pretium malesuada. Aenean tincidunt lectus metus, a faucibus tortor viverra id. In tempus elementum molestie. Nam eget placerat sem. Praesent eget nisi quis quam laoreet aliquam. ";
        //}
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
        public void EditDag()
        {
            DagDTO editedDagDTO = new DagDTO
            {
                dagID = ID,
                Date = Date,
                Naam = Naam,
                DagType = DagType,
                BeginTijd = BeginTijd,
                EindTijd = EindTijd,
                Beschrijving = Beschrijving
            };
            _dagDAL.UpdateDag(editedDagDTO);
        }
    }
}
