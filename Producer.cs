using Confluent.Kafka;
using System.Text.Json;

public class Producer
{
    public static async Task RunAsync()
    {
        // var config = new ProducerConfig 
        // { 
        //     BootstrapServers = "<CLUSTER_ENDPOINT>",
        //     SecurityProtocol = SecurityProtocol.SaslSsl,
        //     SaslMechanism = SaslMechanism.Plain,
        //     SaslUsername = "<API_KEY>",
        //     SaslPassword = "<API_SECRET>",
        // };
        
        var config = new ProducerConfig { BootstrapServers = "localhost:9092,localhost:9093,localhost:9094" };
        using var producer = new ProducerBuilder<string, string>(config).Build();

        var product = new
        {
            gtin = "7680500010471",
            authorizationNumber = "50001",
            productName = "Dafalgan Filmtabl 500 mg",
            atcCode = "N02BE01",
            dosageForm = "Filmtablette",
            manufacturer = "UPSA SAS",
            activeSubstance = "Paracetamolum",
            marketingStatus = "ACTIVE",
            exFactoryPriceCHF = 4.20,
            publicPriceCHF = 5.85,
            lastUpdatedUtc = 1735689600000L,
            dataSource = "swissmedic_api_v2",
            packageSize = "40 Stk",
            narcoticsCategory = (string?)null
        };
        var message = new Message<string, string> { 
            Key = product.gtin, 
            Value = JsonSerializer.Serialize(product) 
        };
        // var topicPartition = new TopicPartition("pharma-products", new Partition(3));
        // var result = await producer.ProduceAsync(topicPartition, message);
        var result = await producer.ProduceAsync("pharma-products", message);
        Console.WriteLine($"Delivered to {result.TopicPartitionOffset}");
    }
}
