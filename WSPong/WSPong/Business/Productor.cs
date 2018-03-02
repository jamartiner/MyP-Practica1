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
        public static int ContadorMensajesAtendidos { get; set; }
        public static void ProducirMsg(string msg, string idMsg)
        {
            var options = new KafkaOptions(new Uri("http://localhost:9092"));
            var router = new BrokerRouter(options);

            var client = new KafkaNet.Producer(router);
            Message message = new Message(msg, idMsg);
            //System.Threading.Thread.Sleep(2000);
            client.BatchDelayTime = TimeSpan.FromSeconds(2);
            client.SendMessageAsync("PongPingTopic", new[] { message });
            ContadorMensajesAtendidos++;
            client.Stop();
        }
    }
}