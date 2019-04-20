using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using ViajaNetFullStackSr.DataComunication;

namespace ViajaNetFullStackSr.Robot
{
    public class Program
    {
        #region Fields

        public static IConfigurationRoot Configuration { get; set; }

        #endregion

        #region Methods    

        static void Main(string[] args)
        {
            var logs = GetLogs();
            if(logs.Count > 0)
                PostLogs(logs);
        }

        #endregion

        #region Private Methods

        private static List<LogDTO> GetLogs()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var result = new List<LogDTO>();
            using (var connection = factory.CreateConnection())
            {
                using (var chanel = connection.CreateModel())
                {
                    chanel.QueueDeclare(
                        queue: "LogAccess",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var log = new EventingBasicConsumer(chanel);
                    log.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        result.Add(JsonConvert.DeserializeObject<LogDTO>(message));
                    };
                    chanel.BasicConsume(
                        queue: "LogAccess",
                        autoAck: true,
                        consumer: log);
                    System.Threading.Thread.Sleep(2 * 1000);
                }
            }
            return result;
        }

        private static void PostLogs(List<LogDTO> logs)
        {

            var config = new ClientConfiguration()
            {
                Servers = new List<Uri>() { new Uri("http://localhost:8091") }
            };
            IAuthenticator authenticator = new PasswordAuthenticator("Administrator", "123456");
            config.SetAuthenticator(authenticator);
            
            using (var cluster = new Cluster(config))
            {
                using (var bucket2 = cluster.OpenBucket("beer-sample2"))
                {
                    foreach (var item in logs)
                    {
                        var document = new Document<LogDTO>
                        {
                            Id = Guid.NewGuid().ToString(),
                            Content = new LogDTO
                            {
                                Id = item.Id,
                                Ip = item.Ip,
                                PageName = item.PageName,
                                BrowserName = item.BrowserName,
                                Parameters = item.Parameters
                            }
                        };

                        var result = bucket2.Insert(document);
                        if (result.Success)
                        {
                            Console.WriteLine("Inserted document '{0}'", document.Id);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
