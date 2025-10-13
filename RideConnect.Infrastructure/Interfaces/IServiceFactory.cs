
namespace RideConnect.Infrastructure.Interfaces;

public interface IServiceFactory
{
    T GetService<T>() where T : class;
}
