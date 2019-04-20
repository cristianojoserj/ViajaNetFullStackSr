using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using ViajaNetFullStackSr.Domain;
using ViajaNetFullStackSr.Domain.Interfaces.Repositories;

namespace ViajaNetFullStackSr.Infra
{
    public class RabbitMQRepository : IRabbitMQRepository
    {
        #region Fields

        private readonly IConnection _connection;
        private readonly IConfiguration _configuration;

        #endregion

        #region Builders

        public RabbitMQRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = GetConnection();
        }

        #endregion

        #region Methods

        public void Insert(Log entity)
        {
            using (var chanel = _connection.CreateModel())
            {
                chanel.QueueDeclare(
                    queue: "LogAccess",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                
                var body = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(entity));

                chanel.BasicPublish(
                    exchange: "",
                    routingKey: "LogAccess",
                    basicProperties: null,
                    body: body);
            }
        }

        #endregion

        #region Private Methods

        private IConnection GetConnection()
        {
            var factory = new ConnectionFactory() {
                HostName = _configuration["RobbitMQHost"]
            };

            return factory.CreateConnection();
        }

        #endregion
    }
}
