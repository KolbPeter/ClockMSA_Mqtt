using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.SystemConsole.Themes;

namespace Common
{
    /// <summary>
    /// Extension methods for <see cref="Serilog.ILogger"/> and <seealso cref="ILogger{TCategoryName}"/>.
    /// </summary>
    public static class ConfigureLogger
    {
        /// <summary>
        /// Extension method to create an <see cref="ILogger{TCategoryName}"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> for the logger.</typeparam>
        /// <returns>Returns an <see cref="ILogger{TCategoryName}"/>.</returns>
        public static ILogger<T> Create<T>() =>
            new LoggerFactory()
                .AddSerilog(Create())
                .CreateLogger<T>();

        /// <summary>
        /// Creates a <see cref="Serilog.ILogger"/> with the given configuration.
        /// </summary>
        /// <returns>Returns a <see cref="Serilog.ILogger"/> with the given configuration.</returns>
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
