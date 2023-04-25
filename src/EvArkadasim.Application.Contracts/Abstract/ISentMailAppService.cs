using EvArkadasim.Dtos.SentMails;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EvArkadasim.Abstract
{
    public interface ISentMailAppService : ICrudAppService<SentMailDto, int, PagedAndSortedResultRequestDto, SentMailDto, SentMailDto>
    {
        Task<bool> SaveAsync(SentMailDto sendMailDto);
    }
}
