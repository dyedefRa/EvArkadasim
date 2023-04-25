using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace EvArkadasim.Entities.Users
{
    public class AppUser : FullAuditedAggregateRoot<Guid>, IUser
    {
        #region Base properties

        public virtual Guid? TenantId { get; private set; }
        public virtual string UserName { get; private set; }
        //public virtual string NormalizedUserName { get; private set; }
        //public virtual string Password { get; private set; }
        public virtual string Name { get; private set; }
        public virtual string Surname { get; private set; }
        public virtual string Email { get; private set; }
        //public virtual string NormalizedEmail { get; private set; }
        public virtual bool EmailConfirmed { get; private set; }
        public virtual string PhoneNumber { get; private set; }
        public virtual bool PhoneNumberConfirmed { get; private set; }


        #endregion
        //public UserType? UserType { get; set; }
        ////Bire bir  Appuser id companyde tutuluyor.
        ////public virtual UserDetail UserDetail { get; set; }
        //public virtual int? ImageId { get; set; }
        //[ForeignKey("ImageId")]
        //public virtual File Image { get; set; }
        //public Status? Status { get; set; }
    }
}
