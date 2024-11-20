
namespace Core.Abstractions
{
    public interface IDataService
    {
        void InitializeDataStore();
        Task SeedAsync();
        Task ClearAsync();
    }
}
