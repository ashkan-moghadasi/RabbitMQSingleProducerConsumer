// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using RabbitMQ.Client;


var factory = new ConnectionFactory()
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare("demo-queue", durable: true, exclusive: false, autoDelete: false, null);
var message=new {Name="Producer" , Message="Hello World!"};
var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
channel.BasicPublish(exchange:"",routingKey: "demo-queue",null,body);
  