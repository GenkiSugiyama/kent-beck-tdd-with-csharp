namespace TDD.Money;

public class Sum : Expression
{
    public Money Augend {get; set;}
    public Money Addend {get; set;}

    public Sum(Money augend, Money addend)
    {
        this.Augend = augend;
        this.Addend = addend;
    }

    public Money Reduce(String to)
    {
        int amount = this.Augend.Amount + this.Addend.Amount;
        return new Money(amount, to);
    }
}
