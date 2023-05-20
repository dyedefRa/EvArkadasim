using EvArkadasim.Dtos.Messages;
using EvArkadasim.Dtos.Messages.ViewModels;
using EvArkadasim.Models.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EvArkadasim.Abstract
{
    public interface IMessageAppService : ICrudAppService<MessageDto, int, PagedAndSortedResultRequestDto, MessageDto, MessageDto>
    {
        Task<IDataResult<List<MessageViewModel>>> GetUserMessageListAsync();
        int GetUnseenMessageCount();
    }
}
