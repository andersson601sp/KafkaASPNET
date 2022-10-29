using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using application.Entities;
using application.Interface;
using application.Infra;
using Confluent.Kafka;

namespace application.Service
{
    public class ProductService : IProductService
    {
        private readonly string _host = EnvConfig.KafkaHost();
        public ProductService()
        {
            
        }

        public async Task<int> GenerateAsync(Product request)
        {
            string bootstrapServers = _host;
            string nomeTopic = "Product";
            try
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = bootstrapServers
                };
                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {

                        var result = await producer.ProduceAsync(
                            nomeTopic,
                            new Message<Null, string>
                            { Value = request.Description });
                }

                return 200;
            }
            catch (Exception)
            {

                return 404;
            }
        }

        public void Receive()
        {           

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
        }
    }
}
