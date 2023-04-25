using System.Threading.Tasks;

namespace EvArkadasim.HangfireServices.Abstract
{
    public interface IRecurringJobService
    {
        Task<bool> SendProductionMailsJob();
    }
}
