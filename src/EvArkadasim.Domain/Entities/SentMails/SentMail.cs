using System;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.SentMails
{
    public class SentMail : Entity<int>
    {
        public string ToAddress { get; set; }
        public string CcAddress { get; set; }
        public string BccAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
