using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class VwBarcodeMailing
    {
        [MaxLength(3)]
        public string SystemCode { get; set; }

        [MaxLength(10)]
        public string PolicyNumber { get; set; }

        [MaxLength(9)]
        public string PostalCode { get; set; }

        [MaxLength(1)]
        public string CountryCode { get; set; }

        [MaxLength(1)]
        public string LanguageCode { get; set; }

        [MaxLength(32)]
        public string HolderName { get; set; }

        [MaxLength(32)]
        public string Address1 { get; set; }

        [MaxLength(32)]
        public string Address2 { get; set; }

        [MaxLength(32)]
        public string Address3 { get; set; }

        [MaxLength(32)]
        public string Address4 { get; set; }

        [MaxLength(32)]
        public string Address5 { get; set; }

        [MaxLength(32)]
        public string Address6 { get; set; }

        [MaxLength(32)]
        public string KeyName { get; set; }

        [MaxLength(7)]
        public string BarcodeNumber { get; set; }
    }
}
