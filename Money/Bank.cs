using Money;

namespace TDD.Money;

public class Bank
{
    private Dictionary<Pair, int> rates = new Dictionary<Pair, int>();

    public Money Reduce(Expression source, String to)
    {
        return source.Reduce(this, to);
    }

    public void AddRate(string from, string to, int rate)
    {
        rates.Add(new Pair(from, to), rate);
    }

    public int Rate(string from, string to)
    {
        if (from.Equals(to))
        {
            return 1;
        }

        var key = new Pair(from, to);
        var result = this.rates.Keys.First().Equals(key);
        var result2 = this.rates.ContainsKey(key);
        rates.TryGetValue(key, out int rate);
        return rate;
    }

}
