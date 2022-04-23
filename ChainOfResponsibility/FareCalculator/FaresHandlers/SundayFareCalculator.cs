using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCurso
{
    public class SundayFareCalculator : IFareCalculator
    {
        public const double SUNDAY_FARE = 2.9;

        public IFareCalculator Next { get; }

        public SundayFareCalculator(IFareCalculator next = null)
        {
            Next = next;
        }

        public double Calculate(Segment segment)
        {
            if (segment.IsSunday())
            {
                return segment.Distance * SUNDAY_FARE;
            }
            if (Next == null) throw new ArgumentException("");
            return Next.Calculate(segment);
        }
    }
}
