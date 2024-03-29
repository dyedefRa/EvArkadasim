﻿using EvArkadasim.Entities.Adverts;
using EvArkadasim.Entities.Files;
using EvArkadasim.Entities.Messages;
using EvArkadasim.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace EvArkadasim.Entities.Users
{
    public class AppUser : FullAuditedAggregateRoot<Guid>, IUser
    {
        #region Base properties

        public virtual Guid? TenantId { get; private set; }
        public virtual string UserName { get; private set; }
        public virtual string Name { get; private set; }
        public virtual string Surname { get; private set; }
        public virtual string Email { get; private set; }
        public virtual bool EmailConfirmed { get; private set; }
        public virtual string PhoneNumber { get; private set; }
        public virtual bool PhoneNumberConfirmed { get; private set; }

        #endregion

        public UserType? UserType { get; set; }
        public GenderType? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public virtual int? ImageId { get; set; }
        [ForeignKey("ImageId")]
        public virtual File Image { get; set; }
        public Status? Status { get; set; }


        //>>
        public virtual ICollection<Advert> Adverts { get; set; }
        public virtual ICollection<Message> SendedMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }
    }
}
