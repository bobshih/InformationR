using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class ExtensionMethod_IListReverseEnumerator
    {
        public static IEnumerable<T> GetReverseEnumerator<T>(this IEnumerable<T> list)
        {
            if (list is IList<T>)
            {
                foreach (var v in GetReverseEnumerator<T>(list as IList<T>))
                {
                    yield return v;
                }
            }
            else
            {
                foreach (var v in list.Reverse())
                {
                    yield return v;
                }
            }

        }

        public static IEnumerable<T> GetReverseEnumerator<T>(this IList<T> list)
        {
            int count = list.Count;
            for (int i = count - 1; i >= 0; --i)
            {
                yield return list[i];
            }
        }
    }
}
