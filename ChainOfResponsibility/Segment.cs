using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCurso
{
    public class Segment
    {
        public const int OVERNIGHT_START = 22;
        public const int OVERNIGHT_END = 6;

        public double Distance { get; }
        public DateTime Date { get; }

        public Segment(double distance, DateTime date)
        {
            Distance = distance;
            Date = date;

            if (!IsValidDistance()) throw new ArgumentException("Invalid Distance");
            if (!IsValidDate()) throw new ArgumentException("Invalid Date");
        }        

        public bool IsValidDistance()
        {
            return Distance != null && (Distance is double) && Distance > 0;
        }

        public bool IsValidDate()
        {
            DateTime temp;
            return Date != null && (Date is DateTime) && DateTime.TryParse(Date.ToString(), out temp);
        }

        public bool IsOvernight()
        {
            return Date.Hour >= OVERNIGHT_START || Date.Hour <= OVERNIGHT_END;
        }

        public bool IsSunday()
        {
            return Date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
