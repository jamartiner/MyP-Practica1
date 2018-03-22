using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;

namespace WSPing.Business
{
    public static class Productor
    {
        private static KafkaOptions options;
        private static BrokerRouter router;
        private static KafkaNet.Producer client;

        static Productor()
        {
            options = new KafkaOptions(new Uri("http://localhost:9092"));
            router = new BrokerRouter(options);
            client = new KafkaNet.Producer(router);
        }

        public static void ProducirMsg(string msg, string idMsg)
        {            
            Message message = new Message(msg, idMsg);
            client.SendMessageAsync("PingPongTopic", new[] { message });
            //client.Stop();
        }
    }
}