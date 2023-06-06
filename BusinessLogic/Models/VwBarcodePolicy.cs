using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class VwBarcodePolicy
    {
        public long BarcodeId { get; set; }
        public string BarcodeNumber { get; set; }
        public string PolicyNumber { get; set; }
        public string HolderName { get; set; }
        public string BirthDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
    }
}
