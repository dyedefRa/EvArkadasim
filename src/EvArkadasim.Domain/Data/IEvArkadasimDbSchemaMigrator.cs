using System.Threading.Tasks;

namespace EvArkadasim.Data
{
    public interface IEvArkadasimDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
