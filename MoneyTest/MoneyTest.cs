using TDD.Money.Dollar;
using TDD.Money.Franc;

namespace TDD.Test.MoneyTest;

[TestClass]
public class MoneyTest
{
    [TestMethod]
    public void TestMethod1()
    {
        // 実装前、「どういうオブジェクトが必要なんだ」と考える前にテストから始める
        // 下記のようにとりあえずテストを書くとコンパイルエラーが発生する
        // まずはコンパイルエラーを解消するところから始める
        Dollar five = new Dollar(5);
        Assert.AreEqual<Dollar>(new Dollar(10), five.Times(2));
        
        Assert.AreEqual(new Dollar(15), five.Times(3));
    }

    [TestMethod]
    public void TestEquality()
    {
        // 三角測量：テストがたまたま通ってしまうことをさけるために複数のテストケースを用意して実装を一般化させる
        Assert.IsTrue(new Dollar(5).Equals(new Dollar(5)));
        Assert.IsFalse(new Dollar(5).Equals(new Dollar(6)));
    }

    [TestMethod]
    public void TestFrancMultiplication()
    {
        Franc five = new Franc(5);
        Assert.AreEqual(new Franc(10), five.Times(2));
        Assert.AreEqual(new Franc(15), five.Times(3));
    }
}