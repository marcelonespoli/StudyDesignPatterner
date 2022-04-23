using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCurso
{
    public class OvernightFareCalculator : IFareCalculator
    {
        public const double OVERNIGHT_FARE = 3.90;

        public IFareCalculator Next { get; }

        public OvernightFareCalculator(IFareCalculator next = null)
        {
            Next = next;
        }

        public double Calculate(Segment segment)
        {
            if (segment.IsOvernight() && !segment.IsSunday())
            {
                return segment.Distance * OVERNIGHT_FARE;
            }
            if (Next == null) throw new AggregateException("");
            return Next.Calculate(segment);
        }
    }
}
