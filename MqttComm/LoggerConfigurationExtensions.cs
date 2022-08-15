using Serilog;
using Serilog.Filters;

namespace MqttComm
{
    public static class LoggerConfigurationExtensions
    {
        public static LoggerConfiguration WithMqttCommLogging(this LoggerConfiguration loggerConfiguration)
        {
            return loggerConfiguration
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
}
