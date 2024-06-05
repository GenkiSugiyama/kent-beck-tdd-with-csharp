namespace TDD.Money;

public interface Expression
{
    Money Reduce(string to);
}
