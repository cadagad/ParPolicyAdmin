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

        /* Format fields to vendor specification */
        public string ToOutboundFormat()
        {
            string filler1 = "000000000000000";
            string spaces1 = "  ";
            string filler2 = "000";
            string SINNumber = "00000000000";
            string filler3 = "0000";
            string filler4 = "                 ";
            string filler5 = "00";
            string votes = "000000000010000";
            string filler6 = "0000000000000000000000000000000000000000000000000000000000000000000000000000";
            string certificateNumber = "         ";

            return String.Format(
                "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}" +
                "{10}{11}{12}{13}{14}{15}{16}{17}{18}{19}" +
                "{20}{21}{22}",
                filler1,
                this.SystemCode != null ? this.SystemCode.PadRight(3) : String.Empty.PadRight(3),
                this.PolicyNumber != null ? this.PolicyNumber.PadRight(10) : String.Empty.PadRight(10),
                certificateNumber,
                spaces1,
                filler2,
                SINNumber,
                filler3,
                this.PostalCode != null ? this.PostalCode.PadRight(9) : String.Empty.PadRight(9),
                this.CountryCode != null ? this.CountryCode.PadRight(1) : String.Empty.PadRight(1),
                filler4,
                this.LanguageCode != null ? this.LanguageCode.PadRight(1) : String.Empty.PadRight(1),
                filler5,
                this.HolderName != null ? this.HolderName.PadRight(34) : String.Empty.PadRight(34),
                this.Address1 != null ? this.Address1.PadRight(34) : String.Empty.PadRight(34),
                this.Address2 != null ? this.Address2.PadRight(34) : String.Empty.PadRight(34),
                this.Address3 != null ? this.Address3.PadRight(34) : String.Empty.PadRight(34),
                this.Address4 != null ? this.Address4.PadRight(34) : String.Empty.PadRight(34),
                this.Address5 != null ? this.Address5.PadRight(34) : String.Empty.PadRight(34),
                this.Address6 != null ? this.Address6.PadRight(34) : String.Empty.PadRight(34),
                votes,
                filler6,
                this.KeyName != null ? this.KeyName.PadRight(32) : String.Empty.PadRight(32));
        }
    }   
}
