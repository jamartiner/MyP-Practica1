using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSPong.Business
{
    public static class Productor
    {
        private static KafkaOptions options;
        private static BrokerRouter router;
        private static KafkaNet.Producer client;
        public static int ContadorMensajesAtendidos { get; set; }

        static Productor()
        {
            options = new KafkaOptions(new Uri("http://localhost:9092"));
            router = new BrokerRouter(options);
            client = new KafkaNet.Producer(router);
            client.BatchDelayTime = TimeSpan.FromSeconds(2);
        }
        public static void ProducirMsg(string msg, string idMsg)
        {            
            Message message = new Message(msg + "_" + idMsg, idMsg);
            //System.Threading.Thread.Sleep(2000);            
            client.SendMessageAsync("PongPingTopic", new[] { message });
            ContadorMensajesAtendidos++;
            //client.Stop();
        }
    }
}