using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Utilities
{
    public static class ListExtensions
    {
        public static List<List<Policy>> SplitList(List<Policy> policies, int nSize = 30)
        {
            var list = new List<List<Policy>>();

            for (int i = 0; i < policies.Count; i += nSize)
            {
                list.Add(policies.GetRange(i, Math.Min(nSize, policies.Count - i)));
            }

            return list;
        }
    }
}
