using TDD.Dollar;

namespace MoneyTest;

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
        Dollar product = five.times(2);
        Assert.AreEqual(5, five.Amount);
        Assert.AreEqual(10, product.Amount);
        
        Dollar product2 = five.times(3);
        Assert.AreEqual(15, product2.Amount);
    }
}