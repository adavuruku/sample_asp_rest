using Confluent.Kafka;
using System.Text;

namespace BookStoreApi.KafkaConfig
{
    public class KafkaConsumerConfig : BackgroundService
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly ILogger<KafkaConsumerConfig> _logger;

        public KafkaConsumerConfig(IConfiguration configuration, ILogger<KafkaConsumerConfig> logger)
        {
            _logger = logger;

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"],
                GroupId = "InventoryConsumerGroup",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true
            };

            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                _consumer.Subscribe("Transaction.events");

                try
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        try
                        {
                            var consumeResult = _consumer.Consume(stoppingToken);

                            if (consumeResult != null)
                            {

                                var eventTypeBytes = consumeResult.Message.Headers.FirstOrDefault(h => h.Key == "eventType");
                                if (eventTypeBytes != null)
                                {
                                    var eventType = Encoding.UTF8.GetString(eventTypeBytes.GetValueBytes());
                                    _logger.LogInformation($" eventType: {eventType}");
                                }

                                var message = consumeResult.Message.Value;
                                _logger.LogInformation($"Received transaction events : {message}");

                            
                            }
                        }
                        catch (ConsumeException ce)
                        {
                            _logger.LogError($"Kafka consume error: {ce.Error.Reason}");
                        }
                        catch (OperationCanceledException)
                        {
                            // Expected when shutting down
                            break;
                        }
                    }
                }
                finally
                {
                    _consumer.Close();
                }
            }, stoppingToken);
        }
    }
}