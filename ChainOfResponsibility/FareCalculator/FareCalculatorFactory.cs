namespace CleanCodeCurso.FareCalculator
{
    public class FareCalculatorFactory
    {
        public IFareCalculator Create(Segment segment)
        {
			if (segment.IsOvernight() && !segment.IsSunday())
			{
				return new OvernightFareCalculator();
			}
			if (segment.IsOvernight() && segment.IsSunday())
			{
				return new OvernightSundayFareCalculator();
			}
			if (segment.IsSunday())
			{
				return new SundayFareCalculator();
			}
			return new NormalFareCalculator();
		}
    }
}
