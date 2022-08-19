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
        /// <param name="path">The path to the log file. The log file name will be 'mqttLogs.txt'.</param>
        /// <returns>Returns a <see cref="LoggerConfiguration"/> for further configuration.</returns>
        public static LoggerConfiguration WithMqttCommLogging(
            this LoggerConfiguration loggerConfiguration,
            IEnumerable<string> path) =>
            loggerConfiguration
                .WriteTo.Logger(x => x
                    .Filter.ByIncludingOnly(Matching.FromSource<IMqttService>())
                    .WriteTo
                    .File(
                        Path.Combine(path.Append("MqttLogs.txt").ToArray()),
                        rollOnFileSizeLimit: true,
                        retainedFileCountLimit: 10,
                        fileSizeLimitBytes: 10 * 1024 * 1024));
    }
}
