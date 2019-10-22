using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieAPI.Models
{
    public class CookiePreferencesModel
    {
        public Guid Id { get; set; }
        public string Batch { get; set; }
        public DateTime Created { get; set; }
        public DateTime TimestampJoined { get; set; }
        public DateTime? TimestampYes { get; set; }
        public DateTime? TimestampNo { get; set; }
        public DateTime? TimeStampRead { get; set; }
        public DateTime? TimestampAgreeAll { get; set; }
        public DateTime? TimestampDisagreeAll { get; set; }
        public DateTime? TimestampCustom { get; set; }

    }
}
