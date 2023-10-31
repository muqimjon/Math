namespace Math.Api.Services;

public interface IMathService
{
    Task<long> AddAsync(long a, long b);
    Task<long> SubAsync(long a, long b);
}
