using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MP.SampleCode.StringCalculator.Handlers;
using MP.SampleCode.StringCalculator.Interfaces.Handlers;
using MP.SampleCode.StringCalculator.Interfaces.Services;
using MP.SampleCode.StringCalculator.Interfaces.Validators;
using MP.SampleCode.StringCalculator.Services;
using MP.SampleCode.StringCalculator.Validators;

namespace MP.SampleCode
{
    public class Program
    {
        public static int Main(string?[] args)
        {
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<IAdditionService, AdditionService>();
                    services.AddTransient<IStringParserService, StringParserService>();
                    services.AddTransient<IStringCalculatorAddHandler, StringCalculatorAddHandler>();
                    services.AddTransient<IAdditionValidator, AdditionValidator>();
                })
                .Build();

            var handler = host.Services.GetRequiredService<IStringCalculatorAddHandler>();

            var input = args[0];

            var result = handler.Add(input);

            return result;
        }
    }
}