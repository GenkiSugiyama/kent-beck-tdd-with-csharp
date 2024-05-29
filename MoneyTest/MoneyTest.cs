using System.Runtime;
using System.Runtime.CompilerServices;
using TDD = TDD.Money;

namespace TDD.Test.MoneyTest;

[TestClass]
public class MoneyTest
{
    [TestMethod]
    public void TestMultiplication()
    {
        // 実装前、「どういうオブジェクトが必要なんだ」と考える前にテストから始める
        // 下記のようにとりあえずテストを書くとコンパイルエラーが発生する
        // まずはコンパイルエラーを解消するところから始める
        TDD::Money five = TDD::Money.IssueDollar(5);
        Assert.AreEqual(TDD::Money.IssueDollar(10), five.Times(2));
        
        Assert.AreEqual(TDD::Money.IssueDollar(15), five.Times(3));
    }

    [TestMethod]
    public void TestEquality()
    {
        // 三角測量：テストがたまたま通ってしまうことをさけるために複数のテストケースを用意して実装を一般化させる
        Assert.IsTrue(TDD::Money.IssueDollar(5).Equals(TDD::Money.IssueDollar(5)));
        Assert.IsFalse(TDD::Money.IssueDollar(5).Equals(TDD::Money.IssueDollar(6)));
        Assert.IsTrue(TDD::Money.IssueFranc(5).Equals(TDD::Money.IssueFranc(5)));
        Assert.IsFalse(TDD::Money.IssueFranc(5).Equals(TDD::Money.IssueFranc(6)));
        Assert.IsFalse(TDD::Money.IssueFranc(5).Equals(TDD::Money.IssueDollar(5)));
    }

    [TestMethod]
    public void TestFrancMultiplication()
    {
        TDD::Money five = TDD::Money.IssueFranc(5);
        Assert.AreEqual(TDD::Money.IssueFranc(10), five.Times(2));
        Assert.AreEqual(TDD::Money.IssueFranc(15), five.Times(3));
    }

    [TestMethod]
    public void TestCurrency()
    {
        Assert.AreEqual("USD", TDD::Money.IssueDollar(1).GetCurrency());
        Assert.AreEqual("CHF", TDD::Money.IssueFranc(1).GetCurrency());

    }
}