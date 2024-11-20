using Core.Abstractions;
using DAL.Abstractions;

namespace Core.Services
{
    public class DataService(IDataStoreService dataStoreService) : IDataService
    {
        public void InitializeDataStore()
        {
            dataStoreService.Initialize();
        }

        public async Task SeedAsync()
        {
            await dataStoreService.SeedAsync();
        }

        public async Task ClearAsync()
        {
            await dataStoreService.ClearAsync();
        }
    }
}
