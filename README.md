# C# Kafka Clients

A simple .NET 10 application demonstrating a Kafka Producer and Consumer using the `Confluent.Kafka` library, configured for Confluent Cloud.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- A Kafka cluster (e.g., [Confluent Cloud](https://confluent.cloud/) or a local Docker instance)
- API Key and Secret (if using Confluent Cloud)

## Local Development (Docker)

To run a local Kafka cluster for development and testing, you can use the provided `docker-compose.yaml` file. This configuration sets up a 3-node Kafka cluster along with Schema Registry and Kafka UI.

Run the following command to start the cluster:

```bash
docker-compose up -d
```

Once started, you can access the Kafka UI at [http://localhost:8080](http://localhost:8080).

## Configuration

Before running the application, you must update the configuration in `Producer.cs` and `Consumer.cs` with your Kafka cluster details.

### Producer Configuration (`Producer.cs`)

Update the configuration in `Producer.cs`:
- For **local Docker**, use `BootstrapServers = "localhost:9092,localhost:9093,localhost:9094"` and remove the SASL/SSL security settings.
- For **Confluent Cloud**, update the following placeholders:
  - `<CLUSTER_ENDPOINT>`: Your Confluent Cloud bootstrap server address.
  - `<API_KEY>`: Your API key.
  - `<API_SECRET>`: Your API secret.

### Consumer Configuration (`Consumer.cs`)

Ensure the `ConsumerConfig` in `Consumer.cs` matches your environment (local vs cloud).

## Project Structure

- `Program.cs`: The entry point that runs the producer and then the consumer.
- `Producer.cs`: Produces a pharma product JSON message to the `pharma-products` topic.
- `Consumer.cs`: Consumes messages from the `pharma-products` topic.
- `KafkaCsharp.csproj`: Project file with dependencies (e.g., `Confluent.Kafka`).

## How to Run

1.  **Restore dependencies:**
    ```bash
    dotnet restore
    ```

2.  **Build the project:**
    ```bash
    dotnet build
    ```

3.  **Run the application:**
    ```bash
    dotnet run
    ```

The application will first produce a message to the specified topic and then attempt to consume a message from the same topic.

## Sample Data

The producer sends a JSON payload representing a pharmaceutical product:

```json
{
  "gtin": "7680500010471",
  "productName": "Dafalgan Filmtabl 500 mg",
  "manufacturer": "UPSA SAS",
  ...
}
```
