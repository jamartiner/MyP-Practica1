using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using KafkaNet;
using KafkaNet.Model;

namespace WSPong.Business
{
    public static class Consumidor
    {
        public static BackgroundWorker backgrounWorker = new BackgroundWorker();
        public static int ContadorMensajesRecibidos { get; set; }
        
        public static void IniciarBackgrounWorker()
        {
            if (!backgrounWorker.IsBusy)
            {
                backgrounWorker.DoWork += new DoWorkEventHandler(bw_DoWork);
                backgrounWorker.RunWorkerAsync();
            }
        }

        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ConsumirMsg();
        }

        public static void ConsumirMsg()
        {
            var options = new KafkaOptions(new Uri("http://localhost:9092")/*, new Uri("http://localhost:9092")*/);
            //var router = new BrokerRouter(options);
            var consumer = new KafkaNet.Consumer(new ConsumerOptions("PingPongTopic", new BrokerRouter(options)));

            //Consume returns a blocking IEnumerable (ie: never ending stream)
            foreach (var message in consumer.Consume())
            {
                ContadorMensajesRecibidos++;
                Console.WriteLine("Response: P{0},O{1} : {2}, key: " + Encoding.UTF8.GetString(message.Key) + ", ConsumerTaskAccount: " + consumer.ConsumerTaskCount, message.Meta.PartitionId, message.Meta.Offset, Encoding.UTF8.GetString(message.Value));
                Productor.ProducirMsg("Pong_Message", Encoding.UTF8.GetString(message.Key));
            }
        }        
    }
}