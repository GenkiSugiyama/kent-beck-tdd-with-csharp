using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    // 為替レート用のクラス
    internal class Pair
    {
        public string From;
        public string To;

        public Pair(string from, string to)
        {
            this.From = from;
            this.To = to;
        }

        public override bool Equals(object obj)
        {
            if(obj == null) return false;
            Pair pair = (Pair)obj;
            return this.From.Equals(pair.From) && this.To.Equals(pair.To);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
