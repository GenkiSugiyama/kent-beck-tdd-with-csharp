namespace TDD.Money;
public abstract class Money
{
    protected int Amount { get; set;}

    public abstract Money Times(int multiplier);  // このTimesメソッドでエラーが発生

    public override bool Equals(object? obj)
    {
        Money money = (Money)obj;
        return this.Amount == money.Amount && this.GetType().Equals(money.GetType());
    }

    public static Dollar IssueDollar(int amount)
    {
        return new Dollar(amount);
    }

    public static Franc IssueFranc(int amount)
    {
        return new Franc(amount);
    }
}
