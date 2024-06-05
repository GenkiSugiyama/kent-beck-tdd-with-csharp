namespace TDD.Money;

public class Bank
{
    public Money Reduce(Expression source, String to)
    {
        return source.Reduce(to);
    }

}
