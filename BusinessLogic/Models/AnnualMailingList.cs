using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class AnnualMailingList
    {
        public long AnnualMailingListId { get; set; }

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

        public int LineNumber { get; set; }

        public bool? UserFlaggedDuplicate { get; set; } = false;

        public bool? UserFlaggedDeficient { get; set; } = false;

        public bool? UserFlaggedExclusion { get; set; } = false;

        public bool? UserManualAdd { get; set; } = false;
    }   
}
