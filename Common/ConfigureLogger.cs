using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.SystemConsole.Themes;

namespace Common
{
    public static class ConfigureLogger
    {
        public static ILogger<T> Create<T>() =>
            new LoggerFactory()
                .AddSerilog(Create())
                .CreateLogger<T>();

        public static Serilog.ILogger Create() =>
            new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithExceptionDetails()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.Logger(x => x
                    .WriteTo
                    .File(
                        Path.Combine("Logs", "Logs.txt"),
                        rollOnFileSizeLimit: true,
                        retainedFileCountLimit: 10,
                        fileSizeLimitBytes: 10 * 1024 * 1024))
                .CreateLogger();
    }
}
