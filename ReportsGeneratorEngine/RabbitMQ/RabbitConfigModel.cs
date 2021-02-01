namespace ReportsGeneratorEngine.RabbitMQ
{
    public class RabbitConfigurationModel
    {
        public string Queue { get; set; }

        public string Exchange { get; set; }

        public string RoutingKey { get; set; }

        public static class Factory
        {
            public static RabbitConfigurationModel NewConfigurationForError() =>
                new RabbitConfigurationModel
                {
                    Queue      = "queue.for.error",
                    Exchange   = "exchange.notification",
                    RoutingKey = "error"
                };

            public static RabbitConfigurationModel NewConfigurationForException() =>
                new RabbitConfigurationModel
                {
                    Queue      = "queue.for.exception",
                    Exchange   = "exchange.notification",
                    RoutingKey = "exception"
                };
        }
    }
}
