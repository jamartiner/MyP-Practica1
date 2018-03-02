using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;

namespace WSPing.Business
{
    public class Productor
    {
        public static void ProducirMsg(string msg, string idMsg)
        {
            var options = new KafkaOptions (new Uri("http://localhost:9092"));
            var router = new BrokerRouter(options);

            var client = new KafkaNet.Producer(router);
            Message message = new Message(msg, idMsg);
            client.SendMessageAsync("PingPongTopic", new[] { message });
            client.Stop();
        }
    }
}