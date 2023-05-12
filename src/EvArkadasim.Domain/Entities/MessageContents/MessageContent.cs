using EvArkadasim.Entities.Messages;
using EvArkadasim.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.MessageContents
{
    [Table(EvArkadasimConsts.DbTablePrefix + "MessageContents")]
    public class MessageContent : Entity<int>
    {
        public int MessageId { get; set; }
        [ForeignKey("MessageId")]
        public virtual Message Message { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public bool IsSeen { get; set; }
        public bool IsDeletedForSender { get; set; }
        public bool IsDeletedForReceiver { get; set; }
        public DateTime? DeletedDateForSender { get; set; }
        public DateTime? DeletedDateForReceived { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }

    }
}
