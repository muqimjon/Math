namespace Math.Api.Services;

public class MathService : IMathService
{
    public Task<long> AddAsync(long a, long b)
    {
        var result = checked(a + b);
        return Task.FromResult(result)
    }
}