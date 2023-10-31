using Math.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;

namespace Math.Test.Services;

public class MathServices
{
    private readonly ServiceProvider service;

    public MathServices()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<IMathService, MathService>();

        this.service = serviceCollection.BuildServiceProvider();
    }

    [Fact]
    public void ShouldAddCorrect()
    {
        var mathService = service.GetRequiredService<IMathService>();

        var a = 3;
        var b = 1;

        var result = mathService.AddAsync(a, b)
            .GetAwaiter().GetResult();

        Assert.Equal(4, result);
    }

    [Theory]
    [InlineData(9223372036854775807, 1)]
    [InlineData(-9223372036854775807, -2)]
    public async void ShouldReturnException(long a, long b)
    {
        var mathService = service.GetRequiredService<IMathService>();

        var task = async () => mathService.AddAsync(a, b);

        await Assert.ThrowsAsync<OverflowException>(task);
    }



    [Fact]
    public void ShouldSubstractCorrect()
    {
        var mathService = service.GetRequiredService<IMathService>();

        var a = 3;
        var b = 1;

        var result = mathService.SubAsync(a, b)
            .GetAwaiter().GetResult();

        Assert.Equal(2, result);
    }
}