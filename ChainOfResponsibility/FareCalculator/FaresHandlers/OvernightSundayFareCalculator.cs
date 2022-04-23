using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCurso
{
    public class OvernightSundayFareCalculator : IFareCalculator
    {
        public const double OVERNIGHT_SUNDAY_FARE = 5;

        public IFareCalculator Next { get; }

        public OvernightSundayFareCalculator(IFareCalculator next = null)
        {
            Next = next;
        }

        public double Calculate(Segment segment)
        {
            if (segment.IsOvernight() && segment.IsSunday())
            {
                return segment.Distance * OVERNIGHT_SUNDAY_FARE;
            }
            if (Next == null) throw new ArgumentException("");
            return Next.Calculate(segment);
        }
    }
}
