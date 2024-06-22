namespace TDD.Money;

// 同じ基底クラスを継承する複数のサブクラスがあり、それぞれが似通っているかつあまり力を持っていない場合極力サブクラスは消したほうがよい？
// 消していくためには実装を寄せていき、完全一致したものから基底クラスに移動、サブクラス側は削除していく
public class Money : Expression
{
    public int Amount { get; set;}
    public string Currency { get; set;}

    public Money(int amount, string currency)
    {
        this.Amount = amount;
        this.Currency = currency;
    }

    public override bool Equals(object? obj)
    {
        Money money = (Money)obj;
        return this.Amount == money.Amount && this.Currency.Equals(money.Currency);
    }

    public Money Times(int multiplier){
        return new Money(this.Amount * multiplier, this.Currency);
    }
    
    public Expression Plus(Money addend)
    {
        return new Sum(this, addend);
    }

    public Money Reduce(Bank bank, string to)
    {
        //return this;
        int rate = bank.Rate(this.Currency, to);
        return new Money(this.Amount / rate, to);
    }

    public string GetCurrency()
    {
        return this.Currency;
    }

    public static Money IssueDollar(int amount)
    {
        return new Money(amount, "USD");
    }

    public static Money IssueFranc(int amount)
    {
        return new Money(amount, "CHF");
    }
}
