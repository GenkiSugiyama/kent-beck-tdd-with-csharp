namespace TDD.Money.Franc;

public class Franc
{
    // テストを通すための実装を行う
    // 今回だとアサーションでAmountプロパティの値をテストしていたので初期値に期待結果を設定する
    // テストがとったことが確認できたらリファクタリングを行ってまたテストが通るかを確認していく
    public int Amount {get;}  // = 5 * 2;
    
    public Franc(int amount)
    {
        this.Amount = amount;
    }

    public Franc Times(int multiplier)
    {
        return new Franc(this.Amount * multiplier);
    }

    public override bool Equals(object? obj)
    {
        Franc franc = (Franc)obj;
        return this.Amount == franc.Amount;
    }
}
