namespace ShuttleRouteManager.Application.Contracts.Persistence;
public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync();
}
