namespace CleanCodeCurso
{
    public interface IFareCalculator
    {
        IFareCalculator Next { get; }
        double Calculate(Segment segment);
    }
}
