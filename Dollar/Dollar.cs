namespace TDD.Money.Dollar;

// namespaceとクラス名が全く一致していると参照先で参照に失敗する
// Dollar is a namespaece but is used like a type と怒られる
// 以下のリンクを後で読んでみる
// https://stackoverflow.com/questions/15007727/namespace-but-is-used-like-a-type

public class Dollar
{
    // テストを通すための実装を行う
    // 今回だとアサーションでAmountプロパティの値をテストしていたので初期値に期待結果を設定する
    // テストがとったことが確認できたらリファクタリングを行ってまたテストが通るかを確認していく
    public int Amount {get;}  // = 5 * 2;
    
    public Dollar(int amount)
    {
        this.Amount = amount;
    }

    public Dollar Times(int multiplier)
    {
        return new Dollar(this.Amount * multiplier);
    }

    public override bool Equals(object? obj)
    {
        Dollar dollar = (Dollar)obj;
        return this.Amount == dollar.Amount;
    }
}
