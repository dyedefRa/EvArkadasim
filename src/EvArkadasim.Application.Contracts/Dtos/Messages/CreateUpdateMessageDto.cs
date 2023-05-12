using EvArkadasim.Dtos.MessageContents;
using EvArkadasim.Enums;
using System;
using System.Collections.Generic;

namespace EvArkadasim.Dtos.Messages
{
    public class CreateUpdateMessageDto
    {
        public CreateUpdateMessageDto()
        {
            MessageContents = new List<MessageContentDto>();
        }

        public MessageStatus SenderStatus { get; set; } = MessageStatus.Default;
        public MessageStatus ReceiverStatus { get; set; } = MessageStatus.Default;
        public DateTime SenderStatusDate { get; set; } = DateTime.Now;
        public DateTime ReceiverStatusDate { get; set; } = DateTime.Now;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int CreatedById { get; set; }
        public int FirstReceivedById { get; set; }
        public MessageType MessageType { get; set; } = MessageType.User;
        public Status Status { get; set; } = Status.Active;

        public List<MessageContentDto> MessageContents { get; set; }
    }
}
