namespace DAL.Abstractions;

public interface IDataStoreService
{
    void Initialize();
    Task SeedAsync();
    Task ClearAsync();
}