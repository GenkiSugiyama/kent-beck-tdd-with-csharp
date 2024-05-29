namespace TDD.Money;

public class Dollar : Money
{
    public Dollar(int amount, string currency): base(amount, currency) { }

    public override Money Times(int multiplier)
    {
        return Money.IssueDollar(this.Amount * multiplier);
    }
}
