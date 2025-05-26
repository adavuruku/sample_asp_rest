using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookStoreApi.KafkaConfig
{
    public class KafkaProducerConfig
    {
        private readonly IConfiguration _configuration;

        private readonly IProducer<Null, string> _producer;
        private readonly IProducer<string, string> _producerWithKey;

        public KafkaProducerConfig(IConfiguration configuration)
        {
            _configuration = configuration;

            var producerconfig = new ProducerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"]
            };

            _producer = new ProducerBuilder<Null, string>(producerconfig).Build();

            _producerWithKey = new ProducerBuilder<string, string>(producerconfig).Build();
        }

        public async Task ProduceAsync(string topic, string message)
        {
            var kafkamessage = new Message<Null, string> { Value = message, };

            await _producer.ProduceAsync(topic, kafkamessage);
        }

        public async Task SendTransactionEventAsync(string topic, string key, object card)
        {
            var uuid = Guid.NewGuid().ToString("N"); // equivalent to Java's UUID with no dashes

            var message = new Message<string, string>
            {
                Key = key,
                Value = JsonSerializer.Serialize(card),
                Headers = new Headers {
                    { "eventType", Encoding.UTF8.GetBytes("AddCardRequested") },
                    { "id", Encoding.UTF8.GetBytes(uuid) }
                }
            };

            // Send to a specific partition (optional — just like partition = 0 in Java)
            var topicPartition = new TopicPartition("Transaction.events", new Partition(0));
            var result = await _producerWithKey.ProduceAsync( topicPartition, message);


            Console.WriteLine($"Message sent to {result.TopicPartitionOffset}");
        }

    }
}
