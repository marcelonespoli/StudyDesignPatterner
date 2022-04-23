using CleanCodeCurso.FareCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCurso
{
    public class Ride
    {       
        public const double MIN_FARE = 10;
        public readonly IFareCalculator _fareCalculator;
        private List<Segment> _segments { get; set; }

        public Ride(IFareCalculator fareCalculator)
        {
            _fareCalculator = fareCalculator;
            _segments = new List<Segment>();
        }               

        public void AddSegment(double distance, DateTime date)
        {
            _segments.Add(new Segment(distance, date));
        }

        // OOB code
        public double Finish()
        {
            double fare = 0;
            foreach (var segment in _segments)
            {
                fare += _fareCalculator.Calculate(segment);
            }
            return (fare < MIN_FARE) ? MIN_FARE : fare;
        }


        // *** Factory
        //
        //public double Finish()
        //{
        //    double fare = 0;
        //    foreach (var segment in _segments)
        //    {
        //        var factory = new FareCalculatorFactory();
        //        fare += factory.Create(segment).Calculate(segment);
        //    }
        //    return (fare < MIN_FARE) ? MIN_FARE : fare;
        //}


        // *** procedural code
        //
        //      public double Finish()
        //      {
        //	        double fare = 0;
        //          foreach (var segment in _segments)
        //          {
        //              if (segment.IsOvernight() && !segment.IsSunday())
        //              {
        //                  fare += segment.Distance * OVERNIGHT_FARE;
        //                  continue;
        //              }
        //              if (segment.IsOvernight() && segment.IsSunday())
        //              {
        //                  fare += segment.Distance * OVERNIGHT_SUNDAY_FARE;
        //                  continue;
        //              }
        //              if (segment.IsSunday())
        //              {
        //                  fare += segment.Distance * SUNDAY_FARE;
        //                  continue;
        //              }                    
        //              fare += segment.Distance * NORMAL_FARE;
        //          }
        //          return (fare < MIN_FARE) ? MIN_FARE : fare;
        //}

    }
}
