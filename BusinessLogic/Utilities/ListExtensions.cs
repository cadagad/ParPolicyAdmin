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

        public static List<List<Barcode>> SplitList(List<Barcode> barcodes, int nSize = 30)
        {
            var list = new List<List<Barcode>>();

            for (int i = 0; i < barcodes.Count; i += nSize)
            {
                list.Add(barcodes.GetRange(i, Math.Min(nSize, barcodes.Count - i)));
            }

            return list;
        }
    }
}
