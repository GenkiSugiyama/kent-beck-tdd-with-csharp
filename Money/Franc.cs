namespace TDD.Money;

public class Franc : Money
{
    public Franc(int amount)
    {
        base.Amount = amount;
    }

    public override Money Times(int multiplier)
    {
        return new Franc(this.Amount * multiplier);
    }
}
