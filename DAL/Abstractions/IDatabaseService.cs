namespace DAL.Abstractions;

public interface IDatabaseService
{
    void Initialize();
    Task SeedAsync();
    Task ClearAsync();
}