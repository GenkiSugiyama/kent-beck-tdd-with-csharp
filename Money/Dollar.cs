namespace TDD.Money;

public class Dollar : Money
{
    public Dollar(int amount)
    {
       base.Amount = amount;
    }

    public override Money Times(int multiplier)
    {
        return new Dollar(base.Amount * multiplier);
    }
}
