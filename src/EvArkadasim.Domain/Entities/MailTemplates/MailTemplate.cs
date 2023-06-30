using EvArkadasim.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.MailTemplates
{
    public class MailTemplate : Entity<int>
    {
        public string Subject { get; set; }
        public string MailKey { get; set; }
        public string MailTemplateValue { get; set; }
        public DateTime InsertedDate { get; set; }
        public Status Status { get; set; }
    }
}
