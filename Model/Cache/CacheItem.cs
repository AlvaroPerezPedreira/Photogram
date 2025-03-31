using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Cache
{
    public class CacheItem<T>
    {
        public T Value { get; set; }

        public bool ExistMore { get; set; }

        public int StartIndex { get; set; }

        public CacheItem(T value, bool existMore, int startIndex)
        {
            Value = value;
            ExistMore = existMore;
            StartIndex = startIndex;
        }

    }
}
