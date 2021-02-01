using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReportsGeneratorEngine.Logger
{
    public interface ILogger
    {
        void Log(string message);

        void Log(string message, object obj);
    }

    public class LoggerContext : ILogger
    {
        public void Log(string message) => Log(message, new { });

        public void Log(string message, object obj)
        {
            var objSerialized = JsonSerializer.Serialize(obj,
                new JsonSerializerOptions {
                    MaxDepth = 0,
                    IgnoreNullValues = true,
                    IgnoreReadOnlyProperties = true
                });

            Console.WriteLine($"Message: {message} | Object : {objSerialized}");
        }
    }
}
