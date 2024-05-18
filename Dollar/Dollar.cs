namespace TDD.Dollar;

// namespaceとクラス名が全く一致していると参照先で参照に失敗する
// Dollar is a namespaece but is used like a type と怒られる
// 以下のリンクを後で読んでみる
// https://stackoverflow.com/questions/15007727/namespace-but-is-used-like-a-type

public class Dollar
{
    public int Amount {get; set;}
    
    public Dollar(int amount)
    {

    }

    public void times(int multiplier)
    {

    }
}
