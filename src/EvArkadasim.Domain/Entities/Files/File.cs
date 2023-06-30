using EvArkadasim.Entities.AdvertFiles;
using EvArkadasim.Entities.Users;
using EvArkadasim.Enums;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.Files
{
    public class File : Entity<int>
    {
        public string Name { get; set; }
        public long? Size { get; set; }
        public string Path { get; set; }
        public string FullPath { get; set; }
        public FileType FileType { get; set; }
        public int Rank { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<AdvertFile> AdvertFiles { get; set; }
        public virtual ICollection<AppUser> Users { get; set; }
    }
}
