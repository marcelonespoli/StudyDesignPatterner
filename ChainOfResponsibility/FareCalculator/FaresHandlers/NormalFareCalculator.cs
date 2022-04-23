using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCurso
{
    public class NormalFareCalculator : IFareCalculator
    {
        public const double FARE = 2.1;

        public IFareCalculator Next { get; }

        public NormalFareCalculator(IFareCalculator next = null)
        {
            Next = next;
        }

        public double Calculate(Segment segment)
        {
            if(!segment.IsSunday() && !segment.IsOvernight())
            {
                return segment.Distance * FARE;
            }
            if (Next == null) throw new ArgumentException("");
            return Next.Calculate(segment);
        }
    }
}
