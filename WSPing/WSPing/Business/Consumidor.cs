using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;

namespace WSPing.Business
{
    public static class Consumidor
    {
        public static string Consumir(string idMsg)
        {
            var options = new KafkaOptions(new Uri("http://localhost:9092")/*, new Uri("http://localhost:9092")*/);
            var router = new BrokerRouter(options);
            var consumer = new KafkaNet.Consumer(new ConsumerOptions("PongPingTopic", new BrokerRouter(options)));

            //Consume returns a blocking IEnumerable (ie: never ending stream)
            foreach (var message in consumer.Consume())
            {
                //Console.WriteLine("Response: P{0},O{1} : {2}, key: " + Encoding.UTF8.GetString(message.Key) + ", ConsumerTaskAccount: " + consumer.ConsumerTaskCount, message.Meta.PartitionId, message.Meta.Offset, Encoding.UTF8.GetString(message.Value));
                if (Encoding.UTF8.GetString(message.Key).Equals(idMsg))
                {
                    return Encoding.UTF8.GetString(message.Value);
                }                
            }

            return string.Empty;
        }
    }
}