using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReportsGeneratorEngine.Logger
{
    public interface ILogger
    {
        void LogInfo(string message);

        void LogInfo(string message, object obj);

        void LogWarn(string message);

        void LogWarn(string message, object obj);

        void LogFatal(string message);

        void LogFatal(string message, object obj);
    }

    public class LoggerContext : ILogger
    {
        public void LogInfo(string message) => Log(type: "info", message);

        public void LogInfo(string message, object obj) => Log(type: "info", message, obj);

        public void LogWarn(string message) => Log(type: "warn", message);

        public void LogWarn(string message, object obj) => Log(type: "warn", message, obj);

        public void LogFatal(string message) => Log(type: "fatal", message);

        public void LogFatal(string message, object obj) => Log(type: "fatal", message, obj);

        private void Log(string type, string message) => Log(type, message, new { });

        private void Log(string type, string message, object obj)
        {
            var objSerialized = JsonSerializer.Serialize(obj,
                new JsonSerializerOptions {
                    MaxDepth = 0,
                    IgnoreNullValues = true,
                    IgnoreReadOnlyProperties = true
                });

            Console.WriteLine($"Type: {type} | Message: {message} | Object : {objSerialized}");
        }
    }
}
