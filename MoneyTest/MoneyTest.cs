using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.IO.Enumeration;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NuGet.Frameworks;
using TDD.Money;
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
        Assert.IsFalse(TDD::Money.IssueFranc(5).Equals(TDD::Money.IssueDollar(5)));
    }

    [TestMethod]
    public void TestCurrency()
    {
        Assert.AreEqual("USD", TDD::Money.IssueDollar(1).GetCurrency());
        Assert.AreEqual("CHF", TDD::Money.IssueFranc(1).GetCurrency());
    }

    [TestMethod]
    public void TestSimpleAddition()
    {
        TDD::Money five = TDD::Money.IssueDollar(5);
        TDD::Expression sum = five.Plus(five);
        Bank bank = new Bank();
        TDD::Money reduced = bank.Reduce(sum, "USD");
        Assert.AreEqual(TDD::Money.IssueDollar(10), reduced);
    }

    [TestMethod]
    public void TestPlusReturnSum()
    {
        TDD::Money five = TDD::Money.IssueDollar(5);
        TDD::Expression result = five.Plus(five);
        Sum sum = (Sum)result;
        Assert.AreEqual(five, sum.Augend);
        Assert.AreEqual(five, sum.Addend);
    }

    [TestMethod]
    public void TestReduceSum()
    {
        TDD::Expression sum = new Sum(TDD::Money.IssueDollar(3), TDD::Money.IssueDollar(4));
        Bank bank = new Bank();
        TDD::Money result = bank.Reduce(sum, "USD");
        Assert.AreEqual(TDD::Money.IssueDollar(7), result); 
    }

    [TestMethod]
    public void TestReduceMoney()
    {
        Bank bank = new Bank();
        TDD::Money result = bank.Reduce(TDD::Money.IssueDollar(1), "USD");
        Assert.AreEqual(TDD::Money.IssueDollar(1), result);
    }

    // フラン ：ドル = 2 : 1 テスト
    [TestMethod]
    public void TestReduceMoneyDifferentCurrency()
    {
        Bank bank = new Bank();
        bank.AddRate("CHF", "USD", 2);
        TDD::Money result = bank.Reduce(TDD::Money.IssueFranc(2), "USD");
        Assert.AreEqual(TDD::Money.IssueDollar(1), result);
    }

    [TestMethod]
    public void TestIdentityRate()
    {
        Assert.AreEqual(1, new Bank().Rate("USD", "USD"));
    }
}