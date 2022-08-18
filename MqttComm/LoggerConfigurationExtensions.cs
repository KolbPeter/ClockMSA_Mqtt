using Serilog;
using Serilog.Filters;

namespace MqttComm
{
    /// <summary>
    /// Extension methods for <see cref="LoggerConfiguration"/>.
    /// </summary>
    public static class LoggerConfigurationExtensions
    {
        /// <summary>
        /// Exzension method to add separate logger for MQTT service.
        /// </summary>
        /// <param name="loggerConfiguration">The <see cref="LoggerConfiguration"/> to use.</param>
        /// <returns>Returns a <see cref="LoggerConfiguration"/> for further configuration.</returns>
        public static LoggerConfiguration WithMqttCommLogging(this LoggerConfiguration loggerConfiguration) =>
            loggerConfiguration
                .WriteTo.Logger(x => x
                    .Filter.ByIncludingOnly(Matching.FromSource<IMqttService>())
                    .WriteTo
                    .File(
                        Path.Combine("Logs", "MqttLogs.txt"),
                        rollOnFileSizeLimit: true,
                        retainedFileCountLimit: 10,
                        fileSizeLimitBytes: 10 * 1024 * 1024));
    }
}
