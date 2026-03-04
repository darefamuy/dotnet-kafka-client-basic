using Confluent.Kafka;

public class Consumer
{
    public static void Run()
    {
        // var config = new ConsumerConfig {
        //     BootstrapServers = "<CLUSTER_ENDPOINT>",
        //     SecurityProtocol = SecurityProtocol.SaslSsl,
        //     SaslMechanism = SaslMechanism.Plain,
        //     SaslUsername = "<API_KEY>",
        //     SaslPassword = "<API_SECRET>",
        //     GroupId = "biblio-aggregator-groupx",
        //     AutoOffsetReset = AutoOffsetReset.Earliest
        // };
        
        var config = new ConsumerConfig {
            BootstrapServers = "localhost:9092,localhost:9093,localhost:9094",
            GroupId = "biblio-aggregator-groupx",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        consumer.Subscribe("pharma-products");

        try {
            // Consuming one message for the sequential demo
            var cr = consumer.Consume(TimeSpan.FromSeconds(10));
            if (cr != null)
            {
                Console.WriteLine($"Processing source data for Biblio: {cr.Message.Value}");
            }
            else
            {
                Console.WriteLine("No message received within timeout.");
            }
        } catch (OperationCanceledException) {
            consumer.Close();
        }
    }
}
