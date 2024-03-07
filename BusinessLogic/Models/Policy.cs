using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class Policy
    {
        public long PolicyId { get; set; }

        /* Columns in Order - Start */
        [MaxLength(3)]
        public string SystemCode { get; set; }

        [MaxLength(10)]
        public string PolicyNumber { get; set; }

        [MaxLength(9)]
        public string CertificateNumber { get; set; }

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
        public string Address7 { get; set; }

        [MaxLength(9)]
        public string PostalCode { get; set; }

        [MaxLength(1)]
        public string CountryCode { get; set; }

        [MaxLength(2)]
        public string ProvinceStateCode { get; set; }

        [MaxLength(1)]
        public string LanguageCode { get; set; }

        [MaxLength(8)]
        public string BirthDate { get; set; }

        [MaxLength(9)]
        public string ShareVotes { get; set; }

        [MaxLength(32)]
        public string KeyName { get; set; }

        /* Columns in Order - End */

        [ForeignKey("PolicyFeed")]
        public int PolicyFeedId { get; set; }
        public virtual PolicyFeed PolicyFeed { get; set; }

        public int LineNumber { get; set; }

        public bool? PossibleDuplicate { get; set; }

        public bool? ExactDuplicate { get; set; }

        public int? PolicyHolderId { get; set; }

        public bool? UserFlaggedDuplicate { get; set; }

        public bool? UserFlaggedDeficient { get; set; }

        public bool? UserFlaggedExclusion { get; set; }

        public string ToCstcFormat()
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

            string add1 = Address1.Replace("\0", "");
            string add2 = Address2.Replace("\0", "");
            string add3 = Address3.Replace("\0", "");
            string add4 = Address4.Replace("\0", "");
            string add5 = Address5.Replace("\0", "");
            string add6 = Address6.Replace("\0", "");

            return String.Format(
                "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}" +
                "{10}{11}{12}{13}{14}{15}{16}{17}{18}{19}" +
                "{20}{21}{22}",
                filler1,
                this.SystemCode != null ? this.SystemCode.PadRight(3) : String.Empty.PadRight(3),
                this.PolicyNumber != null ? this.PolicyNumber.PadRight(10) : String.Empty.PadRight(10),
                this.CertificateNumber != null ? this.CertificateNumber.PadRight(9) : String.Empty.PadRight(9),
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
                add1 != null ? add1.PadRight(34) : String.Empty.PadRight(34),
                add2 != null ? add2.PadRight(34) : String.Empty.PadRight(34),
                add3 != null ? add3.PadRight(34) : String.Empty.PadRight(34),
                add4 != null ? add4.PadRight(34) : String.Empty.PadRight(34),
                add5 != null ? add5.PadRight(34) : String.Empty.PadRight(34),
                add6 != null ? add6.PadRight(34) : String.Empty.PadRight(34),
                votes,
                filler6,
                this.HolderName != null ? this.HolderName.PadRight(32) : String.Empty.PadRight(32));
        }

        public string ToPipeDelimited()
        {
            return String.Format(
                "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|" +
                "{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|" +
                "{20}|{21}|{22}",
                this.PolicyId,
                this.SystemCode,
                this.PolicyNumber,
                this.CertificateNumber,
                this.HolderName,
                this.Address1,
                this.Address2,
                this.Address3,
                this.Address4,
                this.Address5,
                this.Address6,
                this.Address7,
                this.PostalCode,
                this.CountryCode,
                this.ProvinceStateCode,
                this.LanguageCode,
                this.BirthDate,
                this.ShareVotes,
                this.KeyName,
                this.PolicyFeed != null ? this.PolicyFeed.FileName : String.Empty,
                this.LineNumber,
                this.PolicyHolderId,
                this.PossibleDuplicate);
        }

        public string ToTabDelimited()
        {
            return String.Format(
                "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t" +
                "{10}\t{11}\t{12}\t{13}\t{14}\t{15}\t{16}\t{17}\t{18}\t{19}\t" +
                "{20}\t{21}\t{22}",
                this.PolicyId,
                this.SystemCode,
                this.PolicyNumber,
                this.CertificateNumber,
                this.HolderName,
                this.Address1,
                this.Address2,
                this.Address3,
                this.Address4,
                this.Address5,
                this.Address6,
                this.Address7,
                this.PostalCode,
                this.CountryCode,
                this.ProvinceStateCode,
                this.LanguageCode,
                this.BirthDate,
                this.ShareVotes,
                this.KeyName,
                this.PolicyFeed != null ? this.PolicyFeed.FileName : String.Empty,
                this.LineNumber,
                this.PolicyHolderId,
                this.PossibleDuplicate);
        }
    }
}
