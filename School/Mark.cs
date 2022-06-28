namespace School;

public class Mark
{
    public Mark(int value, string className, DateTime date)
    {
        if (value < 0 || value > 5)
        {
            throw new ArgumentOutOfRangeException("invalid mark value");
        }
        Value = value;
        ClassName = className;
        Date = date;
    }

    public int Value { get; private set; }
    public string ClassName { get; private set; }
    public DateTime Date { get; private set; }
}