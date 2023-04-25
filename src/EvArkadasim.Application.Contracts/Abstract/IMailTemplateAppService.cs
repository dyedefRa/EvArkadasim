using EvArkadasim.Dtos.MailTemplates;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EvArkadasim.Abstract
{
    public interface IMailTemplateAppService : ICrudAppService<MailTemplateDto, int, PagedAndSortedResultRequestDto, MailTemplateDto, MailTemplateDto>
    {
        Task<bool> SendNewPasswordMailAsync(string passwordChangeUrl, string toMail);
    }
}
